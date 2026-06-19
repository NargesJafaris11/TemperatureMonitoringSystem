namespace TemperatureMonitoring.Api.Models;

public class HumidityAggregation
{
    public double MaxToday { get; set; }
    public double MinToday { get; set; }
    public string Unit { get; set; } = "Percent";
}