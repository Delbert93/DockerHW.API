using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerHW.API.Data
{
    public class EfCoreRepository : IRepository
    {
        private readonly ApplicationDbContext context;
        public EfCoreRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
 
        public IQueryable<WeatherForecast> Weather => throw new NotImplementedException();

        public async Task AddWeatherForecast(WeatherForecast weather)
        {
            context.Weather.Add(weather);
            await context.SaveChangesAsync();
        }
    }
}
