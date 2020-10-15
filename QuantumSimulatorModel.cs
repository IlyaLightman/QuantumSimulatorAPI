using System;

using Microsoft.Quantum.Simulation.Simulators;
using Microsoft.Quantum.Simulation.Core;

namespace QuantumSimulatorAPI
{
    public class QuantumSimulatorModel
    {
        //public DateTime Date { get; set; }

        //public int TemperatureC { get; set; }

        //public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        //public string Summary { get; set; }

        public void QuantumTest()
        {
            var sim = new QuantumSimulator();

            var teleportation_ops = new QArray<string>(new[] { "SET", "SET", "SET", "H", "CNOT", "CNOT", "H", "IFM", "X", "IFM", "Z" });
            var teleportation_prm = new QArray<long>(new long[] { 0, 1, 1, 0, 2, 0, 2, 2, 1, 0, 1, 0, 1, 1, 2, 0, 1, 2 });

            Console.WriteLine(Constructor.Run(sim, 3, 1, teleportation_ops, teleportation_prm).Result);
        }
    }
}
