using Microsoft.AspNetCore.Mvc;
using YannikG.PageableData.SampleAPI.Models;
using YannikG.PageableData.SampleAPI.Repositories;

namespace YannikG.PageableData.SampleAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherForecastRepository _repository;
    
    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IDataPage<WeatherForecast> Get([FromQuery] Pageable pageable)
    {
        return _repository.GetWeatherForecast(pageable);
    }
}

