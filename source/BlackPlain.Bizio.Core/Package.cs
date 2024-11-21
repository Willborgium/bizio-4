namespace BlackPlain.Bizio.Core
{
    public interface ISampleService
    {
        public int Value { get; set; }
    }

    public class SampleService : ISampleService
    {
        public int Value { get; set; } = 1234;
    }

    public static class Package
    {
        public static IServiceCollection RegisterBizioCore(this IServiceCollection services)
        {
            return services.AddTransient<ISampleService, SampleService>();
        }
    }
}
