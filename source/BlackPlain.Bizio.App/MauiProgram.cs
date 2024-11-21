using BlackPlain.Bizio.Core;
using BlackPlain.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Microsoft.Maui.Platform;

namespace BlackPlain.Bizio.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("KeepCalm-Medium.ttf", "KeepCalmMedium");
                    fonts.AddFont("Blacksword.otf", "Blacksword");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services
                .RegisterCore()
                .RegisterBizioCore()
                .RegisterBizioApp();

            return builder.Build();
        }
    }
}
