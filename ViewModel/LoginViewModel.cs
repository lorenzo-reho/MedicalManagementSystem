using MedicalManagementSystem.Repository;
using System;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Threading;
using System.Windows.Input;

namespace MedicalManagementSystem.ViewModel
{

    internal class LoginViewModel : BaseViewModel
    {

        // definizione dati dinamici della view
        private string _username;
        private SecureString _password;
        private bool _isViewVisible = true;
        private String _errorText;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public SecureString Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public bool IsViewVisible
        {
            get { return _isViewVisible; }
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        public String ErrorText
        {
            get { return _errorText; }
            set
            {
                _errorText = value;
                OnPropertyChanged(nameof(ErrorText));
            }

        }


        public ICommand LoginCommand { get; }
        public UserRepository userRepository;


        public LoginViewModel()
        {

            LoginCommand = new CommandViewModel(ExecuteLoginCommand, CanExecuteLoginCommand);
            userRepository = new UserRepository();
        }

        public bool CanExecuteLoginCommand(object obj)
        {
            return Password != null && Password.Length >= 8 && Username != null && Username.Length > 0;
        }

        public void ExecuteLoginCommand(object obj)
        {
            Tuple<string, string> res = userRepository.AutenticazioneUtente(new NetworkCredential(Username, Password));

            if (res.Item1 == null || res.Item2 == null)
            {
                ErrorText = "Username o Password errati!";
                return;
            }
            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(res.Item1), new string[] { res.Item2 });

            IsViewVisible = false;

        }

    }
}
