using BlackPlain.Bizio.App.ViewModels;

namespace BlackPlain.Bizio.App
{
    internal static class Navigator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static void NavigateTo<TView>()
            where TView : View
        {
            ServiceProvider.GetRequiredService<IAppViewModel>().CurrentContent = ServiceProvider.GetRequiredService<TView>();
        }

        private static IServiceProvider ServiceProvider => _serviceProvider ?? throw new InvalidOperationException("No service provider set!");

        private static IServiceProvider? _serviceProvider;
    }
}
