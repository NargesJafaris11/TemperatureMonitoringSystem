namespace TemperatureMonitoring.Api.Patterns.State;

public class SensorStateContext
{
    private ISensorState _state = new OnlineState();

    public void SetState(ISensorState state)
    {
        _state = state;
    }

    public string GetCurrentState()
    {
        return _state.GetStateName();
    }
}