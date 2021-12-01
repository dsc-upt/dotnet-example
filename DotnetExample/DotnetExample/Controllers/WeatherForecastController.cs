using DotnetExample.Models;
using DotnetExample.Views;
using Microsoft.AspNetCore.Mvc;

namespace DotnetExample.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static List<WeatherForecastModel> database = GenerateWf();

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<WeatherForecastResponseView> Get()
    {
        return database.Select(weatherForecast => new WeatherForecastResponseView
        {
            Id = weatherForecast.Id,
            Date = weatherForecast.Date,
            Summary = weatherForecast.Summary,
            TemperatureC = weatherForecast.TemperatureC,
        });
    }

    // these are attributes
    [HttpPost]
    public WeatherForecastResponseView Post(WeatherForecastRequestView entity)
    {
        var weatherForecast = new WeatherForecastModel
        {
            Id = Random.Shared.Next(1_000_000_000),
            Created = DateTime.Now,
            Updated = DateTime.Now,
            Date = entity.Date,
            TemperatureC = entity.TemperatureC,
            Summary = entity.Summary
        };
        database.Add(weatherForecast);

        weatherForecast = database.Find(item => item == weatherForecast);
        return new WeatherForecastResponseView
        {
            Id = weatherForecast.Id,
            Date = weatherForecast.Date,
            TemperatureC = weatherForecast.TemperatureC,
        };
    }

    private static List<WeatherForecastModel> GenerateWf()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecastModel
            {
                Id = Random.Shared.Next(1_000_000_000),
                Created = DateTime.Now,
                Updated = DateTime.Now,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
           .ToList();
    }
}
