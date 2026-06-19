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
    
    [Fact]
    public void WarningState_Should_Return_Warning()
    {
        var context = new SensorStateContext();

        context.SetState(new WarningState());

        Assert.Equal("Warning", context.GetCurrentState());
    }

    [Fact]
    public void CriticalState_Should_Return_Critical()
    {
        var context = new SensorStateContext();

        context.SetState(new CriticalState());

        Assert.Equal("Critical", context.GetCurrentState());
    }
}