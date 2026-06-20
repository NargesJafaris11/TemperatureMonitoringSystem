using System.Text.RegularExpressions;
using TemperatureMonitoring.Api.Models;
using TemperatureMonitoring.Api.Patterns.Singleton;
using TemperatureMonitoring.Api.Patterns.State;
using TemperatureMonitoring.Api.Patterns.Strategy;

namespace TemperatureMonitoring.Api.Patterns.Observer;

public class SensorProcessorObserver : ISensorObserver
{
    private readonly List<ISensorParserStrategy> _strategies =
    [
        new TempSensorParser(),
        new HumiditySensorParser()
    ];

    public void Update(string line)
    {
        var strategy = _strategies.FirstOrDefault(s => s.CanHandle(line));

        if (strategy == null)
            return;

        var temperature = 0.0;
        var humidity = 0.0;
        var serialNumber = ExtractSerialNumber(line);
        var manufacturer = ExtractManufacturer(line);

        Sensor sensor = new()
        {
            Id = Random.Shared.Next(),
            SerialNumber = serialNumber,
            Name = $"{manufacturer} Sensor",
            State = "Unknown",
            LastMeasurementTimestamp = DateTime.UtcNow
        };

        if (line.Contains("temp:"))
        {
            temperature = strategy.ParseTemperature(line);

            sensor.LastMeasurements.Add(new Measurement
            {
                Type = "Temperature",
                Value = temperature,
                Unit = "Celsius",
                Timestamp = DateTime.UtcNow
            });
        }

        if (line.Contains("hum:"))
        {
            humidity = strategy.ParseHumidity(line);

            sensor.LastMeasurements.Add(new Measurement
            {
                Type = "Humidity",
                Value = humidity,
                Unit = "Percent",
                Timestamp = DateTime.UtcNow
            });
        }

        SensorStateContext context = new();

        if (line.Contains("offline"))
            context.SetState(new OfflineState());
        else if (line.Contains("critical") || temperature > 40)
            context.SetState(new CriticalState());
        else if (line.Contains("warning") || temperature > 30)
            context.SetState(new WarningState());
        else
            context.SetState(new OnlineState());

        sensor.State = context.GetCurrentState();
        if (!sensor.LastMeasurements.Any(m => m.Type == "Temperature"))
        {
            sensor.LastMeasurements.Add(new Measurement
            {
                Type = "Temperature",
                Value = 0,
                Unit = "Celsius",
                Timestamp = DateTime.UtcNow
            });
        }

        if (!sensor.LastMeasurements.Any(m => m.Type == "Humidity"))
        {
            sensor.LastMeasurements.Add(new Measurement
            {
                Type = "Humidity",
                Value = 0,
                Unit = "Percent",
                Timestamp = DateTime.UtcNow
            });
        }

        if (!sensor.LastMeasurements.Any(m => m.Type == "Battery"))
        {
            sensor.LastMeasurements.Add(new Measurement
            {
                Type = "Battery",
                Value = 100,
                Unit = "Percent",
                Timestamp = DateTime.UtcNow
            });
        }

        sensor.LastMeasurements = sensor.LastMeasurements
            .OrderBy(m => m.Type == "Temperature" ? 0 :
                m.Type == "Humidity" ? 1 :
                m.Type == "Battery" ? 2 : 3)
            .ToList();

        SensorManager.Instance.AddSensor(sensor);
    }
    
    private string ExtractSerialNumber(string line)
    {
        var match = Regex.Match(line, @"(?:serial|serialnumber):(\d+)");
        return match.Success ? match.Groups[1].Value : "Unknown";
    }

    private string ExtractManufacturer(string line)
    {
        var match = Regex.Match(line, @"(?:manu|manufac):([a-zA-Z0-9_]+)");
        return match.Success ? match.Groups[1].Value : "Unknown";
    }
}