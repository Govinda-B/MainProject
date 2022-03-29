using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NetCoreConcepts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly TestModelNew testModel;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IHttpClientServiceImplementation _httpClientService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, TestModelNew testModel,
            IHttpClientServiceImplementation httpClientService)
        {
            this.testModel = testModel;
            _logger = logger;
            _httpClientService = httpClientService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetPosition")]
        public object GetPosition()
        {
            return testModel.OnGet();

        }

        [HttpGet("GetDepartments")]
        public async Task<IEnumerable<DepartmentDto>> GetDepartments()
        {
            return await _httpClientService.Execute();

        }
    }
}
