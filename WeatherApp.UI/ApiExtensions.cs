using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

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
}