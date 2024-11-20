using BlackPlain.Bizio.Core;
using BlackPlain.Core;

namespace BlackPlain.Bizio.App
{
    public static class Package
    {
        public static IServiceCollection RegisterBizioApp(this IServiceCollection services)
        {
            return services
                .RegisterBizioCore()
                .RegisterCore();
        }
    }
}
