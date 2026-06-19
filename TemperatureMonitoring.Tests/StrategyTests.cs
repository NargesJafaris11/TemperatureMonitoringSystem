using TemperatureMonitoring.Api.Patterns.Strategy;

namespace TemperatureMonitoring.Tests;

public class StrategyTests
{
    [Fact]
    public void TempSensorParser_Should_Parse_Temperature()
    {
        var parser = new TempSensorParser();
        string line = "temp:1920";

        double result = parser.ParseTemperature(line);

        Assert.Equal(19.2, result);
    }

    [Fact]
    public void HumiditySensorParser_Should_Parse_Humidity()
    {
        var parser = new HumiditySensorParser();
        string line = "hum:45";

        double result = parser.ParseHumidity(line);

        Assert.Equal(4.5, result);
    }
}