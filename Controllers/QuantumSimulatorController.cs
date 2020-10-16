using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace QuantumSimulatorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuantumSimulatorController : ControllerBase
    {
        [HttpPost()]
        public ActionResult<int[]> CalculateResult([FromBody] object data)
        {
            // Console.WriteLine(data.ToString());

            // QSForDeserialize deserializedData = JsonSerializer.Deserialize<QSForDeserialize>($"{data}");
            QSForDeserialize deserializedData = JsonConvert.DeserializeObject<QSForDeserialize>($"{data}");

            Console.WriteLine($"Post calculate request. Qubits: {deserializedData.Qubits}, Repeats: {deserializedData.Repeats}, Instructions: {string.Join(',', deserializedData.Instructions)}");

            var TestInstructions = new string[]
            {
                "SET(q1,One)", "SET(q2,Zero)", "SET(q3,Zero)", "H(q3)",
                "CNOT(q3,q2)", "CNOT(q1,q2)", "H(q1)", "IFM(q2,One)",
                "X(q3)", "IFM(q1,One)", "Z(q3)"
            };

            var (operations, parameters) = DataPreparer.QSInstructionsToParams(deserializedData.Instructions);

            var qs = new QuantumSimulatorOps();

            return new ObjectResult(qs.QuantumCalculating(deserializedData.Qubits, deserializedData.Repeats, operations, parameters));
        }
    }

    public class QSForDeserialize
    {
        public string[] Instructions { get; set; } = new string[0];

        public int Qubits { get; set; } = 1;

        public int Repeats { get; set; } = 1;

        public QSForDeserialize(string[] instructions, int qubits, int repeats)
        {
            Instructions = instructions;
            Qubits = qubits;
            Repeats = repeats;
        }
        public QSForDeserialize() { }
    }
}