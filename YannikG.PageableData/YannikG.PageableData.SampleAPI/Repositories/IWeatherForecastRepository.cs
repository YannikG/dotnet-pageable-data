using System;
using YannikG.PageableData.SampleAPI.Models;

namespace YannikG.PageableData.SampleAPI.Repositories
{
	public interface IWeatherForecastRepository
	{
		IDataPage<WeatherForecast> GetWeatherForecast(IPageable pageable);
	}
}

