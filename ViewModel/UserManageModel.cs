using MedicalManagementSystem.Model;
using MedicalManagementSystem.Repository;
using MedicalManagementSystem.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        public bool IsCheckedFilterButton
        {
            get { return _isCheckedFilterButton; }
            set { _isCheckedFilterButton = value;  OnPropertyChanged(nameof(IsCheckedFilterButton)); }
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


        public ICommand AddButtonCommand { get; }
        public ICommand SearchButtonCommand { get; }

        private readonly NavigationStore _navigationStore;

        public UserManageModel(NavigationStore navigationStore, Func<UserDetailViewModel> CreateUserDetailViewModel) {
            _navigationStore = navigationStore;

            PatientList = new ObservableCollection<BaseUserModel>();

            UserRepository userRepository = new UserRepository();
            userRepository.FiltroUtenti(new BaseUserModel { Role="Paziente" }, PatientList);

            AddButtonCommand = new NavigationCommand(_navigationStore, CreateUserDetailViewModel);
            SearchButtonCommand = new CommandViewModel(ExecuteSearchButton, CanExecuteSearchButton);

            IsEnabledFilterButton = true;
            IsEnabledAddButton = true;
        }

        private void ExecuteSearchButton(object obj)
        {
            IsEnabledAddButton = !IsCheckedFilterButton;
            if (!(CurrentLateralPanel is SearchFilterViewModel))
                CurrentLateralPanel = new SearchFilterViewModel();
        }

        private bool CanExecuteSearchButton(object obj)
        {
            return true;
        }

        private bool CanExecuteAddButton(object obj) {return true;}

        private void ExecuteAddButton(object obj)
        {

            IsEnabledFilterButton = !IsCheckedAddButton;

            _navigationStore.CurrentViewModel = new DashboardViewModel(_navigationStore);

            /*
            if(!(CurrentLateralPanel is CreateNewUserViewModel))
                CurrentLateralPanel = new CreateNewUserViewModel();
            */
        }
    }
}
