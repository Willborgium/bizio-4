namespace BlackPlain.Bizio.App
{
    internal static class Navigator
    {
        public static void Initialize(INavigationHandler navigationHandler, IServiceProvider serviceProvider)
        {
            _navigationHandler = navigationHandler;
            _serviceProvider = serviceProvider;
        }

        public static void NavigateTo<TView>()
            where TView : View
        {
            NavigationHandler.NavigateTo(ServiceProvider.GetRequiredService<TView>());
        }

        private static INavigationHandler NavigationHandler => _navigationHandler ?? throw new InvalidOperationException("No navigation handler set!");
        private static IServiceProvider ServiceProvider => _serviceProvider ?? throw new InvalidOperationException("No service provider set!");

        private static INavigationHandler? _navigationHandler;
        private static IServiceProvider? _serviceProvider;
    }
}
