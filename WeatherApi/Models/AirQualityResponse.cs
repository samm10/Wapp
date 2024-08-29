namespace WeatherApi.Models
{
    public class AirQualityResponse
    {
        public Coord Coord { get; set; }
        public List<AirQualityItem> List { get; set; }
    }

    public class AirQualityItem
    {
        public long Dt { get; set; }
        public AirQualityMain Main { get; set; }
        public AirQualityComponents Components { get; set; }
    }

    public class AirQualityMain
    {
        public int Aqi { get; set; } // Air Quality Index
    }

    public class AirQualityComponents
    {
        public double Co { get; set; } // Carbon Monoxide
        public double No { get; set; } // Nitric Oxide
        public double No2 { get; set; } // Nitrogen Dioxide
        public double O3 { get; set; } // Ozone
        public double So2 { get; set; } // Sulfur Dioxide
        public double Pm2_5 { get; set; } // Fine Particulate Matter
        public double Pm10 { get; set; } // Coarse Particulate Matter
        public double Nh3 { get; set; } // Ammonia
    }
}
