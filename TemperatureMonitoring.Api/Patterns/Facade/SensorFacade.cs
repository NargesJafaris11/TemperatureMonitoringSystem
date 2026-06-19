using TemperatureMonitoring.Api.Models;
using TemperatureMonitoring.Api.Patterns.Observer;
using TemperatureMonitoring.Api.Patterns.Singleton;

namespace TemperatureMonitoring.Api.Patterns.Facade;

public class SensorFacade
{
    public List<Sensor> LoadSensors()
    {
        SensorManager.Instance.Clear();

        var reader = new SensorReader();

        reader.Attach(new SensorLogger());
        reader.Attach(new SensorProcessorObserver());

        reader.ReadLines("Data/sensor_data.txt");

        return SensorManager.Instance.GetSensors();
    }
}