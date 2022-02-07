using Newtonsoft.Json;

public class ApiExtensions
{
    public static async Task<T> GetDataAsync<T>(string uri)
    {
        HttpClient client = new();

        var responseBody = await client.GetStringAsync(uri);

        T response = JsonConvert.DeserializeObject<T>(responseBody);
        
        return response;
    }
}