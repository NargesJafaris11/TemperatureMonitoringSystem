using TemperatureMonitoring.Api.Patterns.Facade;

namespace TemperatureMonitoring.Tests;

public class FacadeTests
{
    [Fact]
    public void SensorFacade_Should_Load_Sensors()
    {
        var facade = new SensorFacade();
        
        var sensors = facade.LoadSensors();
        
        Assert.NotEmpty(sensors);
    }
}