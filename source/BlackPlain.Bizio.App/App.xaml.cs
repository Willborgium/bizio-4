using BlackPlain.Bizio.App.Pages;
using BlackPlain.Bizio.App.ViewModels;
using BlackPlain.Core;

namespace BlackPlain.Bizio.App
{
    public partial class App : Application
    {
        public App(IServiceProvider provider)
        {
            UIManager.SetTaskScheduler();

            var vm = provider.GetRequiredService<IAppViewModel>();

            BindingContext = vm;

            Navigator.Initialize(vm, provider);

            InitializeComponent();

            Navigator.NavigateTo<TestPage>();
        }
    }
}
