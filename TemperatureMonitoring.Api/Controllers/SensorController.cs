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

        return Ok(sensors);
    }
}