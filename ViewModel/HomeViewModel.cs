using MedicalManagementSystem.Stores;
using System;

namespace MedicalManagementSystem.ViewModel
{
    internal class HomeViewModel : BaseViewModel
    {

        // private BaseViewModel _currentViewModel;

        private NavigationStore _navigationStore;

        public BaseViewModel CurrentViewModel
        {
            get { return _navigationStore.CurrentViewModel; }
        }


        public NavigationCommand UserManageCommand { get; }
        public NavigationCommand DashboardCommand { get; }

        public HomeViewModel(NavigationStore navigationStore, Func<object, DashboardViewModel> CreateDashboardViewModel, Func<object, UserManageModel> CreateUserManageViewModel)
        {
            _navigationStore = navigationStore;
            // CurrentViewModel = new UserManageModel();
            UserManageCommand = new NavigationCommand(_navigationStore, ExecuteUserManageCommand, CreateUserManageViewModel, null);
            // DashboardCommand = new CommandViewModel(ExecuteDashboardCommand, CanExecuteDashboardCommand);

            DashboardCommand = new NavigationCommand(_navigationStore, ExecuteDashboardCommand, CreateDashboardViewModel, null);

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void ExecuteDashboardCommand(object obj)
        {
            DashboardCommand.Navigate();
        }

        private bool CanExecuteUserManageCommand(object obj)
        {
            return (!(CurrentViewModel is UserManageModel));
        }

        private void ExecuteUserManageCommand(object obj)
        {
            UserManageCommand.Navigate();
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
