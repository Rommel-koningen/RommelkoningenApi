namespace RommelkoningenApi.Models
{
    public class CurrentWeather
    {
        public int temperature { get; set; }
        public List<string> weather_descriptions { get; set; }
        public string wind_dir { get; set; }
    }
}
