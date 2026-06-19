namespace TemperatureMonitoring.Api.Models;

public class Sensor
{
    public int Id { get; set; }

    public string SerialNumber { get; set; } = "";

    public string Name { get; set; } = "";

    public List<Measurement> LastMeasurements { get; set; } = new();

    public Aggregation Aggregations { get; set; } = new();

    public DateTime LastMeasurementTimestamp { get; set; }

    public string State { get; set; } = "";  
}