using System.Text.Json.Serialization;

namespace WeatherApp.UI
{
    public class GeocodingApiResponse
    {
        public string Name { get; set; }

        public LocalNames LocalNames { get; set; }

        public float Lat { get; set; }

        public float Lon { get; set; }

        public string Country { get; set; }

        public string State { get; set; }
    }
}
