namespace TemperatureMonitoring.Api.Patterns.Observer;

public class SensorReader : ISensorSubject
{
    private readonly List<ISensorObserver> _observers = new();
    public List<ISensorObserver> Observers => _observers;

    public void Attach(ISensorObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(ISensorObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify(string line)
    {
        foreach (var observer in _observers)
        {
            observer.Update(line);
        }
    }

    public void ReadLines(string path)
    {
        var lines = File.ReadAllLines(path);

        foreach (var line in lines)
        {
            Notify(line);
        }
    }
}