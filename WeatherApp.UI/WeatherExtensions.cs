using Newtonsoft.Json;

namespace WeatherApp.UI
{
    public class WeatherExtensions
    {
        public static async Task<string> GetWeatherConditionsAsync(string city)
        {
            string key = GeocodingExtensions.GetApiKey();
            (string lat, string lon) = await GeocodingExtensions.GetCoordinatesAsync(city);

            HttpClient client = new();

            var response = await client.GetAsync($"http://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={key}&units=metric");

            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            WeatherApiResponse conditions = JsonConvert.DeserializeObject<WeatherApiResponse>(responseBody);

            return conditions.Main.Temp.ToString();
        }
    }
}