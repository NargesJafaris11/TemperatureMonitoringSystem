namespace TemperatureMonitoring.Api.Patterns.Observer;

public interface ISensorSubject
{
    void Attach(ISensorObserver observer);

    void Detach(ISensorObserver observer);

    void Notify(string line);
}