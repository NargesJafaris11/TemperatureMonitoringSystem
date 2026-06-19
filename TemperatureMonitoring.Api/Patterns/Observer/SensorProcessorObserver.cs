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

        Sensor sensor = new()
        {
            Id = Random.Shared.Next(),
            SerialNumber = "Unknown",
            Name = "Sensor",
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

        SensorManager.Instance.AddSensor(sensor);
    }
}