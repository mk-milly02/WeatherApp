// See https://aka.ms/new-console-template for more information
using WeatherApp.UI;

Console.WriteLine("Hello, World!");

Console.Write("Where are you? ");
string city = Console.ReadLine();

WeatherApiResponse response = await ApiExtensions.GetWeatherConditionsAsync(city);

Console.WriteLine($"\n{city} weather: {response.Main.Temp} degrees Celsius.");

Console.ForegroundColor = ConsoleColor.DarkBlue;

Console.Write($"\nSunrise time: {response.Sys.Sunrise}");
Console.Write($"\tSunset time: {response.Sys.Sunset}");

Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.Write($"\t\tHumidity: {response.Main.Humidity}");

Console.ForegroundColor = ConsoleColor.Gray;
Console.WriteLine($"\n\nDescription: {response.Weather.FirstOrDefault().Description}");

Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.WriteLine($"\nWind: {response.Wind.Speed}km\\h \tDirection: {WindDirection.GetWindDirection(response.Wind.Deg)}");

Console.ReadKey();