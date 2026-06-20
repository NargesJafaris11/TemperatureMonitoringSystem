using Microsoft.AspNetCore.Mvc;
using TemperatureMonitoring.Api.Patterns.Facade;

namespace TemperatureMonitoring.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SensorController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var facade = new SensorFacade();
        var sensors = facade.LoadSensors();

        var response = new
        {
            items = sensors.Select(sensor => new
            {
                id = sensor.Id,
                serial_number = sensor.SerialNumber,
                name = sensor.Name,
                last_measurements = sensor.LastMeasurements.Select(measurement => new
                {
                    type = measurement.Type,
                    value = measurement.Value,
                    unit = measurement.Unit,
                    timestamp = measurement.Timestamp
                }),
                aggregations = new
                {
                    temperature = new
                    {
                        max_today = sensor.Aggregations.Temperature.MaxToday,
                        min_today = sensor.Aggregations.Temperature.MinToday,
                        unit = sensor.Aggregations.Temperature.Unit
                    },
                    humidity = new
                    {
                        max_today = sensor.Aggregations.Humidity.MaxToday,
                        min_today = sensor.Aggregations.Humidity.MinToday,
                        unit = sensor.Aggregations.Humidity.Unit
                    }
                },
                last_measurement_timestamp = sensor.LastMeasurementTimestamp,
                state = sensor.State
            })
        };

        return Ok(response);
    }
}