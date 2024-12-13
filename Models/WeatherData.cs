using System.Text.Json.Serialization;
namespace NicksApp.Models
{
    public class WeatherData
    {
        [JsonPropertyName("weather")]
        public List<WeatherCondition>? Weather { get; set; }
        [JsonPropertyName("main")]
        public WeatherMain? Main { get; set; }
    }

    // For greeting message
    public class WeatherCondition
    {
        [JsonPropertyName("main")]
        public string? Main { get; set; }
        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }

    // Temperature
    public class WeatherMain
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }
    }
}