using System;
using System.Windows.Input;

namespace MedicalManagementSystem.ViewModel
{
    internal class CommandViewModel : ICommand
    {
        private Action<object> _execute;
        private Predicate<object> _canExecute;

        public CommandViewModel(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        // EventHandler che notifica se una determinata operazione ha modificato il suo stato di CanExecute.
        public event EventHandler CanExecuteChanged
        {
            // CommandManager.RequerySuggested è un event che consente di aggiungere o rimuovere
            // un comando dal set di comandi eseguibili
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
