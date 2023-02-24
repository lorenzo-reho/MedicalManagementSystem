using MedicalManagementSystem.Model;
using MedicalManagementSystem.Repository;
using MedicalManagementSystem.Stores;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MedicalManagementSystem.ViewModel
{

    internal class UserManageModel : BaseViewModel
    {

        public static ObservableCollection<BaseUserModel> PatientList { get; set; }
        private BaseViewModel _currentLateralPanel;
        private bool _isCheckedFilterButton;
        private bool _isCheckedAddButton;
        private bool _isEnabledFilterButton;
        private bool _isEnabledAddButton;
        private bool _isEnabledEditButton;


        public bool IsCheckedFilterButton
        {
            get { return _isCheckedFilterButton; }
            set { _isCheckedFilterButton = value; OnPropertyChanged(nameof(IsCheckedFilterButton)); }
        }

        public bool IsCheckedAddButton
        {
            get { return _isCheckedAddButton; }
            set { _isCheckedAddButton = value; OnPropertyChanged(nameof(IsCheckedAddButton)); }
        }

        public BaseViewModel CurrentLateralPanel
        {
            get { return _currentLateralPanel; }
            set { _currentLateralPanel = value; OnPropertyChanged(nameof(CurrentLateralPanel)); }
        }

        public bool IsEnabledFilterButton
        {
            get { return _isEnabledFilterButton; }
            set { _isEnabledFilterButton = value; OnPropertyChanged(nameof(IsEnabledFilterButton)); }
        }

        public bool IsEnabledAddButton
        {
            get { return _isEnabledAddButton; }
            set { _isEnabledAddButton = value; OnPropertyChanged(nameof(IsEnabledAddButton)); }
        }
        public bool IsEnabledEditButton
        {
            get { return _isEnabledEditButton; }
            set { _isEnabledEditButton = value; OnPropertyChanged(nameof(IsEnabledEditButton)); }
        }

        public NavigationCommand AddButtonCommand { get; }
        public ICommand SearchButtonCommand { get; }
        public NavigationCommand EditButtonCommand { get; }

        private readonly NavigationStore _navigationStore;

        private BaseUserModel _selectedUserModel;

        public BaseUserModel SelectedUserModel
        {
            get { return _selectedUserModel; }
            set { _selectedUserModel = value; OnPropertyChanged(nameof(SelectedUserModel)); }
        }

        private UserRepository _userRepository;

        public UserManageModel(NavigationStore navigationStore, Func<object, UserDetailViewModel> CreateUserDetailViewModel)
        {
            _navigationStore = navigationStore;

            PatientList = new ObservableCollection<BaseUserModel>();

            SelectedUserModel = new BaseUserModel();

            _userRepository = new UserRepository();
            _userRepository.FiltroUtenti(new BaseUserModel { Role = "Paziente" }, PatientList);


            AddButtonCommand = new NavigationCommand(_navigationStore, ExecuteAddCommand, CreateUserDetailViewModel);
            SearchButtonCommand = new CommandViewModel(ExecuteSearchButton, CanExecuteSearchButton);

            EditButtonCommand = new NavigationCommand(_navigationStore, ExecuteEditCommand, CreateUserDetailViewModel);


            IsEnabledFilterButton = true;
            IsEnabledAddButton = true;
            IsEnabledEditButton = true;
        }

        private void ExecuteEditCommand(object obj)
        {

            EditButtonCommand.Obj = _userRepository.GetUserByCodiceFiscale(SelectedUserModel.CodiceFiscale);

            EditButtonCommand.Navigate();
        }

        private void ExecuteAddCommand(object obj)
        {
            AddButtonCommand.Navigate();
        }

        private void ExecuteSearchButton(object obj)
        {

            if (!(CurrentLateralPanel is SearchFilterViewModel))
                CurrentLateralPanel = new SearchFilterViewModel();
        }

        private bool CanExecuteSearchButton(object obj)
        {
            return true;
        }

    }
}
