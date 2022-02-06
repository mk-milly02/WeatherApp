// See https://aka.ms/new-console-template for more information
using WeatherApp.UI;

Console.WriteLine("Hello, World!");

Console.Write("\nWhere are you? ");
string city = Console.ReadLine();

var conditions = await WeatherExtensions.GetWeatherConditionsAsync(city);

var temp = conditions.Main.Temp;

Console.WriteLine($"{temp} degrees Celsius.");

Console.ReadKey();