using MedicalManagementSystem.Model;
using MedicalManagementSystem.Repository;
using MedicalManagementSystem.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MedicalManagementSystem.ViewModel
{
    internal class UserDetailViewModel : BaseViewModel
    {

        private readonly NavigationStore _navigationStore;
        
        public UserRepository userRepository;
        public ObservableCollection<String> ResidenceList { get; set; }


        // Codice Fiscale
        private String _textCodiceFiscale;

        public String TextCodiceFiscale
        {
            get { return _textCodiceFiscale; }
            set { _textCodiceFiscale = value; OnPropertyChanged(nameof(TextCodiceFiscale)); }
        }

        // Nome
        private String _textNome;

        public String TextNome
        {
            get { return _textNome; }
            set { _textNome = value; OnPropertyChanged(nameof(TextNome)); }
        }

        // Cognome
        private String _textCognome;

        public String TextCognome
        {
            get { return _textCognome; }
            set { _textCognome = value; OnPropertyChanged(nameof(TextCognome)); }
        }

        // Residenza
        private String _textResidenza;

        public String TextResidenza
        {
            get { return _textResidenza; }
            set { _textResidenza = value; OnPropertyChanged(nameof(TextResidenza)); }
        }

        // Data Di Nascita
        private DateTime _selectedDataDiNascita;

        public DateTime SelectedDataDiNascita
        {
            get { return _selectedDataDiNascita; }
            set { _selectedDataDiNascita = value; OnPropertyChanged(nameof(SelectedDataDiNascita)); }
        }

        // Sesso        
        private bool _isCheckedF;
        public bool IsCheckedF
        {
            get { return _isCheckedF; }
            set { _isCheckedF = value; OnPropertyChanged(nameof(IsCheckedF)); }
        }

        private bool _isCheckedM;
        public bool IsCheckedM
        {
            get { return _isCheckedM; }
            set { _isCheckedM = value; OnPropertyChanged(nameof(_isCheckedM)); }
        }

        // Email
        private String _textEmail;
        public String TextEmail
        {
            get { return _textEmail; }
            set { _textEmail = value; OnPropertyChanged(nameof(TextEmail)); }
        }

        // Telefono
        private String _textTelefono;

        public String TextTelefono
        {
            get { return _textTelefono; }
            set { _textTelefono = value; OnPropertyChanged(nameof(TextTelefono)); }
        }

        // Residenza
        private String _textPrefisso;

        public String TextPrefisso
        {
            get { return _textPrefisso; }
            set { _textPrefisso = value; OnPropertyChanged(nameof(TextPrefisso)); }
        }


        public ICommand CancelCommand { get; }
        public ICommand CreateCommand { get; }

        public UserDetailViewModel(NavigationStore navigationStore, Func<UserManageModel> CreateUserManageViewModel) {
            _navigationStore = navigationStore;

            userRepository = new UserRepository();
            ResidenceList = userRepository.EstrazioneResidenze();

            CreateCommand = new CommandViewModel(ExecuteCreateCommand, CanExecuteCreateCommand);
            CancelCommand = new NavigationCommand(_navigationStore, CreateUserManageViewModel);

            SelectedDataDiNascita = System.DateTime.Now;

        }

        private bool CanExecuteCreateCommand(object obj)
        {
            String Telefono = TextPrefisso + TextTelefono;

            return (

                UsefulChecks.CheckTelefono(Telefono) &&
                UsefulChecks.CheckEmail(TextEmail) &&
                UsefulChecks.CheckCodiceFiscale(TextCodiceFiscale)

                );
        }

        private void ExecuteCreateCommand(object obj)
        {


            string messageBoxText = "Vuoi salvare le modifiche?";
            string caption = "Avviso";
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result;

            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

            if (result == MessageBoxResult.No || result == MessageBoxResult.Cancel) return;

            bool success = userRepository.AggiungiUtente(new BaseUserModel
            {
                CodiceFiscale = TextCodiceFiscale,
                Nome = TextNome,
                UserName = TextNome,
                Cognome = TextCognome,
                Residenza = TextResidenza,
                Role = "Paziente",
                DataDiNascita = SelectedDataDiNascita.Date.ToString("g"),
                Sex = IsCheckedF ? 'F' : (IsCheckedM ? 'M' : '\0'),
                Telefono = TextPrefisso + TextTelefono,
                Email = TextEmail
            });


            if (!success) {
                MessageBox.Show("Qualcosa è andato storto", "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else {
                MessageBox.Show("Salvataggio avvenuto con successo", "OK", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}
