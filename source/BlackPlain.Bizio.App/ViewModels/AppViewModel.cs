using BlackPlain.Core;

namespace BlackPlain.Bizio.App.ViewModels
{
    public interface IAppViewModel : INavigationHandler
    {
        View CurrentContent { get; }
    }

    public class AppViewModel : ViewModelBase, IAppViewModel
    {
        public View CurrentContent
        {
            get => GetField<View>();
            set => SetField(value);
        }

        public AppViewModel()
        {
        }

        public void NavigateTo(View view) => CurrentContent = view;
    }
}
