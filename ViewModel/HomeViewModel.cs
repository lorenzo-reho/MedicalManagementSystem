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

        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public ICommand UserManageCommand { get; } 
        public ICommand DashboardCommand { get; }

        public HomeViewModel() {
            CurrentViewModel = new UserManageModel();
            UserManageCommand = new CommandViewModel(ExecuteUserManageCommand, CanExecuteUserManageCommand);
            DashboardCommand = new CommandViewModel(ExecuteDashboardCommand, CanExecuteDashboardCommand);
        }

        private bool CanExecuteDashboardCommand(object obj)
        {
            return !(CurrentViewModel is DashboardViewModel);
        }

        private void ExecuteDashboardCommand(object obj)
        {
            CurrentViewModel = new DashboardViewModel();
        }

        private bool CanExecuteUserManageCommand(object obj)
        {
            return (!(CurrentViewModel is UserManageModel)) ;
        }

        private void ExecuteUserManageCommand(object obj)
        {
            CurrentViewModel = new UserManageModel();
        }
    }
}
