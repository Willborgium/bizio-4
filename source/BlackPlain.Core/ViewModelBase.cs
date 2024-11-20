using System.Collections.Concurrent;
using System.Windows.Input;

namespace BlackPlain.Core
{
    public class ViewModelBase : NotifyOnPropertyChanged
    {
        public bool IsBusy
        {
            get
            {
                return GetField<bool>();
            }
            set
            {
                SetField(value);
            }
        }

        public ICommand LoadViewModelCommand => _canLoadAsync ? GetAsyncCommand(LoadViewModel, true) : GetCommand(LoadViewModel);

        protected ViewModelBase()
            : this(true)
        {
        }

        protected ViewModelBase(bool canLoadAsync)
        {
            _commands = new();

            _canLoadAsync = canLoadAsync;
        }

        protected virtual void LoadViewModel(object? state) { }

        protected ICommand GetCommand(Action<object?> execute, Predicate<object?> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            if (canExecute == null)
            {
                throw new ArgumentNullException(nameof(canExecute));
            }

            var candidates = _commands.GetOrAdd(execute, k => new ConcurrentDictionary<Predicate<object?>, ICommand>());

            return candidates.GetOrAdd(canExecute, k => new RelayCommand(execute, canExecute));
        }

        protected ICommand GetCommand(Action execute, Predicate<object?> canExecute) => GetCommand(x => execute(), canExecute);

        protected ICommand GetCommand(Action execute, Func<bool> canExecute) => GetCommand(execute, x => canExecute());

        protected ICommand GetCommand(Action<object?> execute) => GetCommand(execute, NullPredicate);

        protected ICommand GetCommand(Action execute) => GetCommand(x => execute(), NullPredicate);

        protected ICommand GetAsyncCommand(Action<object?> execute, Predicate<object?> canExecute, bool isBusy) => GetCommand(async x => await ExecuteAsync(x, execute, isBusy), canExecute);

        protected ICommand GetAsyncCommand(Action<object?> execute, Predicate<object?> canExecute) => GetCommand(async x => await ExecuteAsync(x, execute, false), canExecute);

        protected ICommand GetAsyncCommand(Action execute, Predicate<object?> canExecute, bool isBusy) => GetAsyncCommand(x => execute(), canExecute, isBusy);

        protected ICommand GetAsyncCommand(Action execute, Predicate<object?> canExecute) => GetAsyncCommand(x => execute(), canExecute);

        protected ICommand GetAsyncCommand(Action execute, Func<bool> canExecute, bool isBusy) => GetAsyncCommand(execute, x => canExecute(), isBusy);

        protected ICommand GetAsyncCommand(Action execute, Func<bool> canExecute) => GetAsyncCommand(execute, x => canExecute());

        protected ICommand GetAsyncCommand(Action<object?> execute, bool isBusy) => GetAsyncCommand(execute, NullPredicate, isBusy);

        protected ICommand GetAsyncCommand(Action<object?> execute) => GetAsyncCommand(execute, NullPredicate);

        protected ICommand GetAsyncCommand(Action execute, bool isBusy) => GetAsyncCommand(x => execute(), NullPredicate, isBusy);

        protected ICommand GetAsyncCommand(Action execute) => GetAsyncCommand(x => execute(), NullPredicate);

        protected static bool NullPredicate(object? data) => true;

        private async Task ExecuteAsync(object? data, Action<object?> execute, bool isBusy)
        {
            if (isBusy)
            {
                IsBusy = true;
            }

            await Task.Factory.StartNew(() =>
            {
                execute(data);

                if (isBusy)
                {
                    IsBusy = false;
                }
            });
        }

        private readonly ConcurrentDictionary<Action<object?>, ConcurrentDictionary<Predicate<object?>, ICommand>> _commands;

        protected readonly bool _canLoadAsync;
    }
}
