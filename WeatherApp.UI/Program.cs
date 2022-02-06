// See https://aka.ms/new-console-template for more information
using WeatherApp.UI;

Console.WriteLine("Hello, World!");

Console.Write("\nWhere are you? ");
string city = Console.ReadLine();

Console.WriteLine(await WeatherExtensions.GetWeatherConditionsAsync(city));

Console.ReadKey();