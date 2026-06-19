namespace TemperatureMonitoring.Api.Models;

public class Measurement
{
    public string Type { get; set; } = "";
    public double Value { get; set; }
    public string Unit { get; set; } = "";
    public DateTime Timestamp { get; set; }
}