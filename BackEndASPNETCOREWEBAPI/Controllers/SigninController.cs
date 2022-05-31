using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREWEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SigninController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<SigninController> _logger;

        public SigninController(ILogger<SigninController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<Signin> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Signin
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}