using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace QuantumSimulatorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuantumSimulatorController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //private readonly ILogger<QuantumSimulatorController> _logger;

        //public QuantumSimulatorController(ILogger<QuantumSimulatorController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet]
        public IEnumerable<QuantumSimulatorModel> Get()
        {
            var qs = new QuantumSimulatorModel { };
            qs.QuantumTest();


            return Enumerable.Range(1, 5).Select(index => new QuantumSimulatorModel
            {
                //Date = DateTime.Now.AddDays(index),
                //TemperatureC = rng.Next(-20, 55),
                //Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
