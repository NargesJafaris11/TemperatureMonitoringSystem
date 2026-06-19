namespace TemperatureMonitoring.Api.Models;

public class TemperatureAggregation
{
    public double MaxToday { get; set; }
    public double MinToday { get; set; }
    public string Unit { get; set; } = "Celsius";
}