namespace TemperatureMonitoring.Api.Models;

public class Aggregation
{
    public TemperatureAggregation Temperature { get; set; } = new();
    public HumidityAggregation Humidity { get; set; } = new();
}