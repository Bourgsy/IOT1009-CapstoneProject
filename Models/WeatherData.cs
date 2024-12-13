public class WeatherData
{
    public List<WeatherCondition> Weather { get; set; }
    public WeatherMain Main { get; set; }
}

// For greeting message
public class WeatherCondition
{
    public string Main { get; set; }
    public string Description { get; set; }
}

// Temperature
public class WeatherMain
{
    public double Temp { get; set; }

}


