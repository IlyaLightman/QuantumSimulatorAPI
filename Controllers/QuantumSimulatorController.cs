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

            var instructions = new string[]
            {
                "SET(q1,One)", "SET(q2,Zero)", "SET(q3,Zero)", "H(q3)",
                "CNOT(q3,q2)", "CNOT(q1,q2)", "H(q1)", "IFM(q2,One)",
                "X(q3)", "IFM(q1,One)", "Z(q3)"
            };

            var (operations, parameters) = DataPreparer.QSInstructionsToParams(instructions);

            qs.QuantumCalculating(3, 1, operations, parameters);

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