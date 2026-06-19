namespace TemperatureMonitoring.Api.Patterns.State;

public class OfflineState : ISensorState
{
    public string GetStateName()
    {
        return "Offline";
    }
}