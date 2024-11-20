using System.Collections.Concurrent;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace BlackPlain.Core
{
    public class NotifyOnPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public async void OnPropertyChanged([CallerMemberName] string property = "")
        {
            var args = _args.GetOrAdd(property, x => new PropertyChangedEventArgs(x));


            await UIManager.ExecuteAsync(() =>
            {
                PropertyChanged?.Invoke(this, args);
            });
        }

        protected NotifyOnPropertyChanged()
        {
            _args = new ConcurrentDictionary<string, PropertyChangedEventArgs>();

            _fields = new ConcurrentDictionary<string, object?>();
        }

        protected T? GetField<T>([CallerMemberName] string name = "")
        {
            return GetField<T>(default, name);
        }

        protected T? GetField<T>(T? defaultValue, [CallerMemberName] string name = "")
        {
            var output = defaultValue;

            if (_fields.TryGetValue(name, out var value))
            {
                try
                {
                    output = (T?)value;
                }
                catch
                {
                    Debug.WriteLine($"Failed to convert field '{name}' with value '{value}' of type '{value?.GetType()}' to type '{typeof(T)}'.");
                }
            }

            return output;
        }

        protected bool SetField(object? value, bool doNotify = true, [CallerMemberName] string property = "")
        {
            var didChange = true;

            _fields.AddOrUpdate(property, value, (key, oldValue) =>
            {
                didChange = oldValue != value;
                return value;
            });

            if (didChange && doNotify)
            {
                OnPropertyChanged(property);
            }

            return didChange;
        }

        private readonly ConcurrentDictionary<string, PropertyChangedEventArgs> _args;

        private readonly ConcurrentDictionary<string, object?> _fields;
    }
}
