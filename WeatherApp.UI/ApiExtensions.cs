using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WeatherApp.UI;

public class ApiExtensions
{
    public static string GetApiKey()
    {
        IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            return config.GetSection("apikey").Value;
    }

    public static async Task<T> GetDataAsync<T>(string uri)
    {
        HttpClient client = new();

        var responseBody = await client.GetStringAsync(uri);

        T response = JsonConvert.DeserializeObject<T>(responseBody);
        
        return response;
    }

    public static async Task<(string latitude, string longitude)> GetCoordinatesAsync(string city)
    {
        string key = GetApiKey();
        string uri = $"http://api.openweathermap.org/geo/1.0/direct?q={city}&limit=1&appid={key}";

        List<GeocodingApiResponse> response = await GetDataAsync<List<GeocodingApiResponse>>(uri);

        var responseCity = response.FirstOrDefault();

        return (responseCity.Lat.ToString(), responseCity.Lon.ToString());
    }

    public static async Task<WeatherApiResponse> GetWeatherConditionsAsync(string city)
    {
        string key = GetApiKey();
        (string lat, string lon) = await GetCoordinatesAsync(city);
        string uri = $"http://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={key}&units=metric";

        WeatherApiResponse response = await GetDataAsync<WeatherApiResponse>(uri);

        return response;
    }
}