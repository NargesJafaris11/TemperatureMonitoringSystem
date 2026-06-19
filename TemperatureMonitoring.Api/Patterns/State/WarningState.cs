namespace TemperatureMonitoring.Api.Patterns.State;

public class WarningState : ISensorState
{
    public string GetStateName()
    {
        return "Warning";
    }
}