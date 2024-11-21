using BlackPlain.Bizio.App.ViewModels;
using BlackPlain.Bizio.App.Views;
using BlackPlain.Core;
#if WINDOWS
using Microsoft.UI.Windowing;
using Microsoft.UI;
#endif
using Microsoft.Maui.Handlers;

namespace BlackPlain.Bizio.App
{
    public partial class App : Application
    {
        public App(IServiceProvider provider)
        {
            UIManager.SetTaskScheduler();

            BindingContext = provider.GetRequiredService<IAppViewModel>();

            Navigator.Initialize(provider);

            InitializeComponent();

            Navigator.NavigateTo<MainMenuView>();

            SetWinNoResizable();
        }

        private static void SetWinNoResizable()
        {
#if WINDOWS
            WindowHandler.Mapper.AppendToMapping(nameof(IWindow), SetWindowNotResizable);
#endif
        }

        private static void SetWindowNotResizable(IWindowHandler handler, IWindow window)
        {
#if WINDOWS
                var nativeWindow = handler.PlatformView;
                IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
                WindowId WindowId = Win32Interop.GetWindowIdFromWindow(windowHandle);
                AppWindow appWindow = AppWindow.GetFromWindowId(WindowId);
                var presenter = appWindow.Presenter as OverlappedPresenter;
                presenter.IsResizable = false;
#endif
        }
    }
}
