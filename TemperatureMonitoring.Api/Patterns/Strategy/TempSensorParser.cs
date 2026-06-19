using System.Text.RegularExpressions;

namespace TemperatureMonitoring.Api.Patterns.Strategy;

public class TempSensorParser : ISensorParserStrategy
{
    public bool CanHandle(string line)
    {
        return line.Contains("temp:");
    }

    public double ParseTemperature(string line)
    {
        var match = Regex.Match(line, @"temp:(\d+)");
        
        if (!match.Success)
            return 0;

        return double.Parse(match.Groups[1].Value) / 100;
    }

    public double ParseHumidity(string line)
    {
        return 0;
    }
}