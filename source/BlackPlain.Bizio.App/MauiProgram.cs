using BlackPlain.Bizio.Core;
using BlackPlain.Core;
using Microsoft.Extensions.Logging;

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
