using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DockerHW.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IWeatherService weatherService;
        public IEnumerable<WeatherForecast> WeatherData;

        private readonly HttpClient client;

        public IndexModel(HttpClient client)
        {
            this.client = client;
        }

        public IndexModel(ILogger<IndexModel> logger, IWeatherService weatherService)
        {
            _logger = logger;
            this.weatherService = weatherService;
        }

        public async Task OnGet()
        {
            WeatherData = await weatherService.GetWeatherAsync();
            foreach(var weather in WeatherData)
            {
                await client.PostAsJsonAsync("/weatherforecast/AddWeatherForecast", weather);
            }
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
