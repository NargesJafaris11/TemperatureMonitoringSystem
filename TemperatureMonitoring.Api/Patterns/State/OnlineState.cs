namespace TemperatureMonitoring.Api.Patterns.State;

public class OnlineState : ISensorState
{
    public string GetStateName()
    {
        return "Online";
    }
}