using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace WeatherApp.UI
{
    public class GeocodingExtensions
    {
        public static string GetApiKey()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            return config.GetSection("apikey").Value;
        }

    }
}
