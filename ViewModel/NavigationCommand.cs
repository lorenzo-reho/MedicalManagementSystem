using MedicalManagementSystem.Stores;
using System;
using System.Windows.Input;

namespace MedicalManagementSystem.ViewModel
{
    internal class NavigationCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly NavigationStore _navigationStore;
        private readonly Func<BaseViewModel> _createViewModel;

        public NavigationCommand(NavigationStore navigationStore, Func<BaseViewModel> createViewModel) { 
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
