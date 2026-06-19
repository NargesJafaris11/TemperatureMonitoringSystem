namespace TemperatureMonitoring.Api.Patterns.Observer;

public interface ISensorObserver
{
    void Update(string line);
}