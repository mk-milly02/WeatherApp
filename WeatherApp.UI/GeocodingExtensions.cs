using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace WeatherApp.UI
{
    public class GeocodingExtensions
    {
        private string GetApiKey()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            return config.GetSection("apikey").Value;
        }

        public async Task<(string latitude, string longitude)> GetCoordinatesAsync(string city)
        {
            string key = GetApiKey();

            HttpClient client = new();

            var response = 
                await client.GetAsync($"http://api.openweathermap.org/geo/1.0/direct?q={city}&appid={key}");

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            City x = JsonConvert.DeserializeObject<City>(responseBody);

            return (x.Latitude, x.Longitude);
        }
    }
}
