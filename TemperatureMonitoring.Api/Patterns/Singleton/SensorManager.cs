using TemperatureMonitoring.Api.Models;

namespace TemperatureMonitoring.Api.Patterns.Singleton;

public sealed class SensorManager
{
    private static readonly SensorManager _instance = new();

    public static SensorManager Instance => _instance;

    private readonly List<Sensor> _sensors = new();

    private SensorManager()
    {
    }

    public List<Sensor> GetSensors()
    {
        return _sensors;
    }

    public void AddSensor(Sensor sensor)
    {
        _sensors.Add(sensor);
    }

    public void Clear()
    {
        _sensors.Clear();
    }
}