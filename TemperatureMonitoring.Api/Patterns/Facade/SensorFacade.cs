using Microsoft.AspNetCore.SignalR;
using TemperatureMonitoring.Api.Hubs;
using TemperatureMonitoring.Api.Models;
using TemperatureMonitoring.Api.Patterns.Observer;
using TemperatureMonitoring.Api.Patterns.Singleton;

namespace TemperatureMonitoring.Api.Patterns.Facade;

public class SensorFacade
{
    private readonly IHubContext<SensorHub> _hubContext;

    public SensorFacade(IHubContext<SensorHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public List<Sensor> LoadSensors()
    {
        SensorManager.Instance.Clear();

        var reader = new SensorReader();

        reader.Attach(new SensorLogger());
        reader.Attach(new SensorProcessorObserver(_hubContext));

        reader.ReadLines("Data/sensor_data.txt");

        return SensorManager.Instance.GetSensors();
    }
}