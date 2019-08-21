using Microsoft.Extensions.Configuration;

namespace DI
{
    public static class SettingUtility
    {
        public static T Get<T>(string filename)
        {
            var builder = new ConfigurationBuilder()
                .AddInMemoryCollection()
            .AddJsonFile(filename);
            var cfg = builder.Build();
            var setting = cfg.Get<T>();

            return setting;
        }
    }
}
