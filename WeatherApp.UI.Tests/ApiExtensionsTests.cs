using System.Threading.Tasks;
using Xunit;

namespace WeatherApp.UI.Tests
{
    public class ApiExtensionsTests
    {
        [Fact]
        public void ShouldPass_GetApiKey()
        {
            // Given
            string expectedKey = "1234567890";
            // When
            string actualKey = ApiExtensions.GetApiKey();
            // Then
            Assert.NotEqual(expectedKey, actualKey);
        }

        [Fact]
        public async Task ShouldPass_GetCoordinatesAsync()
        {
            // Given
            (string eLat, string eLon) = ("51.50732", "-0.1276474");
            // When
            (string aLat, string aLon) = await ApiExtensions.GetCoordinatesAsync("London");
            // Then
            Assert.True(eLat.Equals(aLat) && eLon.Equals(aLon));
        }
    }
}