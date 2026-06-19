using TemperatureMonitoring.Api.Patterns.Observer;

namespace TemperatureMonitoring.Tests;

public class ObserverTests
{
    [Fact]
    public void SensorReader_Should_Attach_Observer()
    {
        var reader = new SensorReader();
        var observer = new SensorLogger();

        reader.Attach(observer);

        Assert.Single(reader.Observers);
    }

    [Fact]
    public void SensorReader_Should_Detach_Observer()
    {
        var reader = new SensorReader();
        var observer = new SensorLogger();

        reader.Attach(observer);
        reader.Detach(observer);

        Assert.Empty(reader.Observers);
    }
}