using MedicalManagementSystem.Model;
using MedicalManagementSystem.Repository;
using MedicalManagementSystem.Stores;
using MedicalManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

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
        

        public ICommand UserManageCommand { get; } 
        public ICommand DashboardCommand { get; }

        public HomeViewModel(NavigationStore navigationStore, Func<DashboardViewModel> CreateDashboardViewModel, Func<UserManageModel> CreateUserManageViewModel) {
            _navigationStore = navigationStore;
            // CurrentViewModel = new UserManageModel();
            UserManageCommand = new NavigationCommand(_navigationStore, CreateUserManageViewModel);
            // DashboardCommand = new CommandViewModel(ExecuteDashboardCommand, CanExecuteDashboardCommand);

            DashboardCommand = new NavigationCommand(_navigationStore, CreateDashboardViewModel);

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private bool CanExecuteUserManageCommand(object obj)
        {
            return (!(CurrentViewModel is UserManageModel)) ;
        }

        private void ExecuteUserManageCommand(object obj)
        {
            // CurrentViewModel = new UserManageModel();
            // _navigationStore.CurrentViewModel = new UserManageModel(_navigationStore);

        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
