using TemperatureMonitoring.Api.Patterns.State;

namespace TemperatureMonitoring.Tests;

public class StateTests
{
    [Fact]
    public void OnlineState_Should_Return_Online()
    {
        var context = new SensorStateContext();
        context.SetState(new OnlineState());
        Assert.Equal("Online", context.GetCurrentState());
    }
}