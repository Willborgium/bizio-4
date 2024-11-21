using BlackPlain.Bizio.App.ViewModels;
using BlackPlain.Bizio.App.Views;

namespace BlackPlain.Bizio.App
{
    public static class Package
    {
        public static IServiceCollection RegisterBizioApp(this IServiceCollection services)
        {
            return services
                .AddSingleton<IAppViewModel, AppViewModel>()
                .AddTransient<IMainMenuViewModel, MainMenuViewModel>()
                .AddTransient<MainMenuView>();
        }
    }
}
