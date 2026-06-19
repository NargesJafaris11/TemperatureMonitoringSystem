using TemperatureMonitoring.Api.Patterns.Singleton;

namespace TemperatureMonitoring.Tests;

public class SingletonTests
{
    [Fact]
    public void SensorManager_Should_Return_Same_Instance()
    {
        // Arrange
        var instance1 = SensorManager.Instance;
        var instance2 = SensorManager.Instance;

        // Assert
        Assert.Same(instance1, instance2);
    }
}