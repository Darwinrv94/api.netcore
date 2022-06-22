using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private static List<WeatherForecast> ListWeatherForeCast = new List<WeatherForecast>();

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        if (ListWeatherForeCast == null || !ListWeatherForeCast.Any())
        {
            ListWeatherForeCast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    //[Route("Get/GetWeatherForecast")]
    //[Route("Get/GetWeatherForecast2")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogDebug("Retornando la lista de WeatherForecast");
        return ListWeatherForeCast;
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        ListWeatherForeCast.Add(weatherForecast);

        return Ok();
    }

    [HttpDelete("{index}")]
    public IActionResult Delete(int index)
    {
        if (ListWeatherForeCast.ElementAtOrDefault(index) == null)
        {
            return NotFound(new { message = "WeatherForecast not found" });
        }

        ListWeatherForeCast.RemoveAt(index);

        return Ok();
    }
}
