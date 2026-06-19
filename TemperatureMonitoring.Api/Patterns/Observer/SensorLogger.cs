namespace TemperatureMonitoring.Api.Patterns.Observer;

public class SensorLogger : ISensorObserver
{
    public void Update(string line)
    {
        Console.WriteLine($"Nieuwe sensorregel: {line}");
    }
}