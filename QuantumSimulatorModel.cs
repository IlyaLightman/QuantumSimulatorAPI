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

            Console.WriteLine(DataPreparer.QSInstructionsToParams(new string[] { "SET(q1,One)", "SET(q2,Zero)", "SET(q3,Zero)", "H(q3)", "CNOT(q3,q2)", "CNOT(q1,q2)", "H(q1)", "IFM(q2,One)", "X(q3)", "IFM(q1,One)", "Z(q3)" }));

            Console.WriteLine(Constructor.Run(sim, 3, 1, teleportation_ops, teleportation_prm).Result);
        }

        public void QuantumCalculating(int qubits, int repeats, string[] operations, long[] parameters)
        {
            var sim = new QuantumSimulator();

            var prepared_operations = new QArray<string>(operations);
            var preapred_parameters = new QArray<long>(parameters);

            Console.WriteLine(Constructor.Run(sim, qubits, repeats, prepared_operations, preapred_parameters));
        }
    }
}
