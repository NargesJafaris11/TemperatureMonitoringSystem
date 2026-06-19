namespace TemperatureMonitoring.Api.Patterns.Strategy;

public interface ISensorParserStrategy
{
    bool CanHandle(string line);

    double ParseTemperature(string line);

    double ParseHumidity(string line);
}