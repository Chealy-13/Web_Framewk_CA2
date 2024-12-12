
namespace Web_Framewk_CA2.Components.Model
{
    public class WeatherData
    {
        public Main Main { get; set; }
        public Weather[] Weather { get; set; }
        public string Name { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public double Feels_Like { get; set; }
        public int Humidity { get; set; }
    }

    public class Weather
    {
        public string Description { get; set; }
    }
}
