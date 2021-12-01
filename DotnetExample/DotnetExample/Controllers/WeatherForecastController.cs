using System.ComponentModel.DataAnnotations.Schema;
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

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecastResponseView> Get()
    {
        return database.Select(weatherForecast => new WeatherForecastResponseView
            {
                Id = weatherForecast.Id,
                Created = weatherForecast.Created,
                Updated = weatherForecast.Updated,
                Date = weatherForecast.Updated,
                TemperatureC = weatherForecast.TemperatureC,
                Summary = weatherForecast.Summary,
            }
            ); 
    }

    [HttpGet("{id}")]
    public WeatherForecastResponseView Get(int id)
    {
        var entity = database.Find(item => item.Id == id);
        if (entity == null)
        {
            throw new ArgumentException("Id not found");
        }
        return new WeatherForecastResponseView
        {
            Id = entity.Id,
            Date = entity.Date,
            TemperatureC = entity.TemperatureC,
            Summary = entity.Summary,
        };
    }
    
    [HttpPost]
    public WeatherForecastResponseView Post(WeatherForecastRequestView entity)
    {
        var weatherForecast = new WeatherForecastModel
        {
            Id = Random.Shared.Next(10000000),
            Created = DateTime.Now,
            Updated = DateTime.Now,
            Date = entity.Date,
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
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
    
    [HttpDelete]
    public WeatherForecastResponseView Delete(int id)
    {
        var entity = database.Find(item => item.Id == id);
        if (entity == null)
        {
            throw new ArgumentException("Id not found");
        }
        database.Remove(entity);
        return new WeatherForecastResponseView
        {
            Id = entity.Id,
            Date = entity.Date,
            TemperatureC = entity.TemperatureC,
            Summary = entity.Summary,
        };
    }
    private static List<WeatherForecastModel> GenerateWf()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecastModel
            {
                Id = Random.Shared.Next(1000000),
                Created = DateTime.Now,
                Updated = DateTime.Now,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
    }
}