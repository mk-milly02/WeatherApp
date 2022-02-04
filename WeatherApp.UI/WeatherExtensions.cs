namespace WeatherApp.UI
{
    public class WeatherExtensions
    {
        public static async Task GetConditionsAsync(string city)
        {
            string key = GeocodingExtensions.GetApiKey();
            (string lat, string lon) = await GeocodingExtensions.GetCoordinatesAsync(city);

            HttpClient client = new();

            var response =
                await client.GetAsync($"api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={key}");

            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseBody);
        }
    }
}