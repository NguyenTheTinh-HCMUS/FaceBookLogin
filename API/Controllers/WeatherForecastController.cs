using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
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
        private readonly IFaceBookService _faceBookService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IFaceBookService faceBookService)
        {
            _logger = logger;
            _faceBookService = faceBookService;
        }

        
        
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
        [HttpGet("a")]
        public IEnumerable<WeatherForecast> Get1()
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
        [HttpPost("test")]
        public async Task<IActionResult> Test( string accessToken)
        {
            var rs = await _faceBookService.GetUserInforAsync("EAAPC1BpdLooBAFe6ZCv5P0slCEZCohkcuPwcZCHAcKnUCN5tyPtMEy2zafs7xFJ6uZCFehjBv2Xl2ZA76jAoVsSUmnkBkhUzXWyjYZBPImT9pa6NYSOCBR2bZBMGjOxrd2qwGhT81zafhZCCh91PNgxEhZBVB2Rl8X1RHMFOBMAZBLG8HCXoqEEEKIGdM9SRydhRBjwPEYHZC9bCQZDZD");
            return Ok(rs);
        }
    }
}
