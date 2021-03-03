using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerHW.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IWeatherService weatherService;
        public IEnumerable<WeatherForecast> WeatherData;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration config, IWeatherService weatherService)
        {
            _logger = logger;
            this.weatherService = weatherService;
        }

        public async Task OnGet()
        {
            WeatherData = await weatherService.GetWeatherAsync();
        }
    }
    public interface IWeatherService
    {
        [Get("/weatherforecast")]
        Task<IEnumerable<WeatherForecast>> GetWeatherAsync();
    }

    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
