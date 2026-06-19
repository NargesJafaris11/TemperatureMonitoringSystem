using System.Text.RegularExpressions;

namespace TemperatureMonitoring.Api.Patterns.Strategy;

public class HumiditySensorParser : ISensorParserStrategy
{
    public bool CanHandle(string line)
    {
        return line.Contains("hum:");
    }

    public double ParseTemperature(string line)
    {
        return 0;
    }

    public double ParseHumidity(string line)
    {
        var match = Regex.Match(line, @"hum:(\d+)");
        
        if (!match.Success)
            return 0;

        return double.Parse(match.Groups[1].Value) / 10;
    }
}