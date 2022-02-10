namespace WeatherApp.UI
{
    public class WindDirection
    {
        public static string GetWindDirection(double degree)
        {
            if (degree >= 348.75 && degree <= 11.25)
            {
                return "North";
            }
            else if (degree >= 11.25 && degree <= 33.75)
            {
                return "North-northeast";
            }
            else if (degree >= 33.75 && degree <= 56.25)
            {
                return "North-east";
            }
            else if (degree >= 56.25 && degree <= 78.75)
            {
                return "East-northeast";
            }
            else if (degree >= 78.75 && degree <= 101.25)
            {
                return "East";
            }
            else if (degree >= 101.25 && degree <= 123.75)
            {
                return "East-southeast";
            }
            else if (degree >= 123.75 && degree <= 146.25)
            {
                return "South-east";
            }
            else if (degree >= 146.25 && degree <= 168.75)
            {
                return "South-southeast";
            }
            else if (degree >= 168.75 && degree <= 191.25)
            {
                return "South";
            }
            else if (degree >= 191.25 && degree <= 213.75)
            {
                return "South-southwest";
            }
            else if (degree >= 213.75 && degree <= 236.25)
            {
                return "South-west";
            }
            else if (degree >= 236.25 && degree <= 258.75)
            {
                return "West-southwest";
            }
            else if (degree >= 258.75 && degree <= 281.25)
            {
                return "West";
            }
            else if (degree >= 281.25 && degree <= 303.75)
            {
                return "West-northwest";
            }
            else if (degree >= 303.75 && degree <= 326.25)
            {
                return "North-west";
            }
            else
            {
                return "North-northwest";
            }
        }
    }
}