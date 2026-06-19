namespace TemperatureMonitoring.Api.Patterns.State;

public class CriticalState : ISensorState
{
    public string GetStateName()
    {
        return "Critical";
    }
}