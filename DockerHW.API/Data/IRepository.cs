using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerHW.API.Data
{
    interface IRepository
    {
        IQueryable<WeatherForecast> Weather { get; }

        Task AddWeatherForecast(WeatherForecast weather);
    }
}
