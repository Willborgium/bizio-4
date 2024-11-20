using System.Windows.Input;

namespace BlackPlain.Core
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public RelayCommand(Action<object?> execute)
            : this(execute, DefaultCanExecute)
        {
        }

        public RelayCommand(Action<object?> execute, Predicate<object?> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));

            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) => _canExecute(parameter);

        public void Execute(object? parameter) => _execute(parameter);

        private static bool DefaultCanExecute(object? sender) => true;

        private readonly Action<object?> _execute;

        private readonly Predicate<object?> _canExecute;
    }
}
