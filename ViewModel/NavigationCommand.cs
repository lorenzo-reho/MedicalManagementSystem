using MedicalManagementSystem.Stores;
using System;
using System.Diagnostics;
using System.Windows.Input;

namespace MedicalManagementSystem.ViewModel
{
    internal class NavigationCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly NavigationStore _navigationStore;
        private readonly Func<object, BaseViewModel> _createViewModel;
     
        private readonly object _obj;
        public object Obj { get; set; }

        private readonly Action<object> _ExecuteCommand;


        public NavigationCommand(NavigationStore navigationStore, Action<object> ExecuteCommand, Func<object, BaseViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _ExecuteCommand = ExecuteCommand;
        }

        public NavigationCommand(NavigationStore navigationStore, Action<object> ExecuteCommand, Func<object,BaseViewModel> createViewModel, object obj) { 
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            Obj = obj;
            _ExecuteCommand = ExecuteCommand;
        }

        public void Navigate() {
            _navigationStore.CurrentViewModel = _createViewModel(Obj);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _ExecuteCommand(parameter);
        }
    }
}
