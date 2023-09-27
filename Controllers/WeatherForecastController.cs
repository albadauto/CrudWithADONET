using CrudWithADONET.DAL;
using CrudWithADONET.DAL.Interface;
using CrudWithADONET.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudWithADONET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ITestInsertDAL _dal;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, ITestInsertDAL dal)
        {
            _logger = logger;
            _dal = dal;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("/InsertUser")]
        public ActionResult InsertTest([FromBody] UserModel model)
        {
            _dal.InsertUser(model);
            return Ok();
        }
    }
}