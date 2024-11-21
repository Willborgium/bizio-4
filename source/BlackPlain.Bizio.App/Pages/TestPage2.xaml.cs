using BlackPlain.Bizio.App.ViewModels;

namespace BlackPlain.Bizio.App.Pages;

public partial class TestPage2 : ContentView
{
    public TestPage2(IServiceProvider provider)
    {
        InitializeComponent();

        BindingContext = provider.GetRequiredService<ITestPage2ViewModel>();
    }
}