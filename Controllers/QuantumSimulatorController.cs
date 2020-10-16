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
        [HttpGet()]
        public ActionResult<int[]> GetResult()
        {
            Console.WriteLine("Get request");

            var instructions = new string[]
            {
                "SET(q1,One)", "SET(q2,Zero)", "SET(q3,Zero)", "H(q3)",
                "CNOT(q3,q2)", "CNOT(q1,q2)", "H(q1)", "IFM(q2,One)",
                "X(q3)", "IFM(q1,One)", "Z(q3)"
            };

            var (operations, parameters) = DataPreparer.QSInstructionsToParams(instructions);

            Console.WriteLine($"{string.Join(' ', operations)} {string.Join(' ', parameters)}");

            var qs = new QuantumSimulatorOps();
            // Console.WriteLine(qs.QuantumCalculating(3, 1, operations, parameters));

            return new ObjectResult(qs.QuantumCalculating(3, 1000, operations, parameters));
        }
    }
}