using Xunit;

namespace WeatherApp.UI.Tests
{
    public class GeocodingExtensionsTests
    {
        [Fact]
        public async void ReturnValidCoordinates()
        {
            string lat = "51.50732";
            string lon = "-0.1276474";

            (string _lat, string _lon) = await GeocodingExtensions.GetCoordinatesAsync("London");

            Assert.True(_lat.Equals(lat) && _lon.Equals(lon));
        }
    }
}