// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using WeatherApp.UI;

Console.WriteLine("Hello, World!");

string key = GeocodingExtensions.GetApiKey();

string city = "London";

HttpClient client = new();

var response = await client.GetAsync($"http://api.openweathermap.org/geo/1.0/direct?q={city}&limit=1&appid={key}");

response.EnsureSuccessStatusCode();

var responseBody = await response.Content.ReadAsStringAsync();

Location x = JsonConvert.DeserializeObject<Location>(responseBody);

Console.ReadKey();