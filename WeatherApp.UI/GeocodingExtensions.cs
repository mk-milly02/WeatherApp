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

        public static async Task<(string latitude, string longitude)> GetCoordinatesAsync(string city)
        {
            string key = GetApiKey();

            HttpClient client = new();

            var response = await client.GetAsync($"http://api.openweathermap.org/geo/1.0/direct?q={city}&limit=1&appid={key}");

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            List<Location> x = JsonConvert.DeserializeObject<List<Location>>(responseBody);

            Location y = x.FirstOrDefault();

            return (y.Lat.ToString(), y.Lon.ToString());
        }
    }
}
