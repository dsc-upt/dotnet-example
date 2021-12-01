namespace DotnetExample.Views;

public class WeatherForecastRequestView : WeatherForecastModel
{
    public DateTime Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }
}