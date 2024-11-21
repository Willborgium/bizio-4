using BlackPlain.Bizio.App.ViewModels;

namespace BlackPlain.Bizio.App.Pages;

public partial class TestPage : ContentView
{
    public TestPage(IServiceProvider provider)
    {
        InitializeComponent();

        BindingContext = provider.GetRequiredService<ITestPageViewModel>();
    }
}