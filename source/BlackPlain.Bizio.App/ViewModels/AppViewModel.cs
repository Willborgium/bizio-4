using BlackPlain.Core;

namespace BlackPlain.Bizio.App.ViewModels
{
    public interface IAppViewModel
    {
        View? CurrentContent { get; set; }
    }

    public class AppViewModel : ViewModelBase, IAppViewModel
    {
        public View? CurrentContent
        {
            get => GetField<View>();
            set => SetField(value);
        }
    }
}
