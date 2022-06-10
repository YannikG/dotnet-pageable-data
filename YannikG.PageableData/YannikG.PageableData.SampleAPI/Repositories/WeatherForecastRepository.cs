using System;
using YannikG.PageableData.SampleAPI.Models;

namespace YannikG.PageableData.SampleAPI.Repositories
{
	public class WeatherForecastRepository : IWeatherForecastRepository
	{
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly string[] Cities = new[]
        {
            "Bern", "Zürich", "Lausanne", "Sion", "Basel", "Biel", "Neuchâtel", "Genf", "Brig", "St. Gallen", "Aarau", "Olten", "Solothurn", "Frauenfeld", "Winterthur", "Chur", "St. Moritz", "Thun", "Luzern", "Lugano", "Zug", "Schaffhauasen", "Freiburg", "La Chaux-de-Fonds", "Le Locle", "Andermatt", "Kandersteg", "Göschenen", "Airolo", "Thun", "Brienz", "Interlaken", "Sursee", "Brugg AG"
        };

        public WeatherForecastRepository()
		{
		}

        public IDataPage<WeatherForecast> GetWeatherForecast(IPageable pageable)
        {

            long totalCount = Cities.Count();
            var content = getWeatherForecastsFromCities();

            // ** Mocking Database behavior **
            if (pageable.IsSorted)
            {
                switch (pageable.SortByField)
                {
                    case nameof(WeatherForecast.City):
                        if (pageable.SortDirection == SortDirectionEnum.Ascending)
                            content = content.OrderBy(w => w.City).ToArray();
                        else
                            content = content.OrderByDescending(w => w.City).ToArray();
                        break;
                    case nameof(WeatherForecast.Date):
                        if (pageable.SortDirection == SortDirectionEnum.Ascending)
                            content = content.OrderBy(w => w.Date).ToArray();
                        else
                            content = content.OrderByDescending(w => w.Date).ToArray();
                        break;
                    case nameof(WeatherForecast.TemperatureC):
                        if (pageable.SortDirection == SortDirectionEnum.Ascending)
                            content = content.OrderBy(w => w.TemperatureC).ToArray();
                        else
                            content = content.OrderByDescending(w => w.TemperatureC).ToArray();
                        break;
                    case nameof(WeatherForecast.Summary):
                        if (pageable.SortDirection == SortDirectionEnum.Ascending)
                            content = content.OrderBy(w => w.Summary).ToArray();
                        else
                            content = content.OrderByDescending(w => w.Summary).ToArray();
                        break;
                }
            }

            content = content.Skip(pageable.Skip).Take(pageable.Take).ToArray();

            // ***********

            return new DataPage<WeatherForecast>(content, totalCount, pageable);
        }

        private ICollection<WeatherForecast> getWeatherForecastsFromCities()
        {
            return Cities.Select(c => new WeatherForecast
            {
                City = c,
                Date = DateTime.Now.AddDays(1),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();
        }
    }
}

