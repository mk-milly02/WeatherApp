// See https://aka.ms/new-console-template for more information
using WeatherApp.UI;
using Spectre.Console;

Console.OutputEncoding = System.Text.Encoding.UTF8;

AnsiConsole.Write(new FigletText("Weather App").Centered().Color(Color.Pink1));

string location = AnsiConsole.Ask<string>("[gold1]Where[/] are you?");

WeatherApiResponse response = new();

await AnsiConsole.Status().Spinner(Spinner.Known.Weather).SpinnerStyle("blue")
    .StartAsync("Fetching weather conditions...", async ctx => 
    {
        response = await ApiExtensions.GetWeatherConditionsAsync(location);
        Thread.Sleep(5000);
    });
    
AnsiConsole.WriteLine("\n");

AnsiConsole.Write(new Rule($"{location} Weather Conditions").RuleStyle("blue"));

var root = new Tree($"Description: [green]{response.Weather.FirstOrDefault().Description.ToUpperInvariant()}[/]").Guide(TreeGuide.DoubleLine);

var temp = root.AddNode("Temperature");

temp.AddNode($"{Emoji.Known.Thermometer}" + $"Main: {response.Main.Temp}°C / {Temperature.ConvertToFahrenheit(response.Main.Temp)}°F");

temp.AddNode($"{Emoji.Known.Thermometer}" + $"Min: {response.Main.TempMin}°C / {Temperature.ConvertToFahrenheit(response.Main.TempMin)}°F");

temp.AddNode($"{Emoji.Known.Thermometer}" + $"Max: {response.Main.TempMax}°C / {Temperature.ConvertToFahrenheit(response.Main.TempMax)}°F");

root.AddNode($"Humidity: {response.Main.Humidity}");

var wind = root.AddNode("Wind");

wind.AddNode($"{Emoji.Known.WindFace}" + $"Speed: {response.Wind.Speed}km//h");

wind.AddNode($"{Emoji.Known.WindFace}" + $"Direction: {WindDirection.GetWindDirection(response.Wind.Deg)}");

AnsiConsole.Write(root);

Console.ReadKey();