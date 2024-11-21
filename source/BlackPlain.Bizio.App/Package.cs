using BlackPlain.Bizio.App.Pages;
using BlackPlain.Bizio.App.ViewModels;

namespace BlackPlain.Bizio.App
{
    public static class Package
    {
        public static IServiceCollection RegisterBizioApp(this IServiceCollection services)
        {
            return services
                .AddSingleton<IAppViewModel, AppViewModel>()
                .AddTransient<ITestPageViewModel, TestPageViewModel>()
                .AddTransient<ITestPage2ViewModel, TestPage2ViewModel>()
                .AddTransient<TestPage>()
                .AddTransient<TestPage2>();
        }
    }
}
