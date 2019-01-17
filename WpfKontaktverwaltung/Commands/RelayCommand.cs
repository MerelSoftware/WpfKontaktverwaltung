using System;
using System.Windows.Input;

namespace WpfKontaktverwaltung.Commands
{
    /// <summary>
    /// Generische Command-Klasse, der ein Predicate und eine Action übergeben werden kann.
    /// </summary>
    /// <remarks>
    /// Quelle: https://www.codeproject.com/Articles/32101/Exploring-a-Model-View-ViewModel-Application-WPF-P
    /// Abschnitt RelayCommand
    /// </remarks>
    public class RelayCommand : ICommand
    {

        private Predicate<object> _canExecute;
        private Action<object> _execute;

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }

        }

        public RelayCommand(Predicate<object> canExecute, Action<object> execute)
        {
            this._canExecute = canExecute;
            this._execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
