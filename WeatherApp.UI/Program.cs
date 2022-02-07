// See https://aka.ms/new-console-template for more information
using WeatherApp.UI;

Console.WriteLine("Hello, World!");

Console.Write("Where are you? ");
string city = Console.ReadLine();

WeatherApiResponse response = await ApiExtensions.GetWeatherConditionsAsync(city);

Console.WriteLine($"\n{city} weather: {response.Main.Temp} degrees Celsius.");

Console.ReadKey();