using System;

using Microsoft.Quantum.Simulation.Simulators;
using Microsoft.Quantum.Simulation.Core;
using System.Linq;

namespace QuantumSimulatorAPI
{
    public class QuantumSimulatorOps
    {
        #region whatthefuck
        //private int Qubits {
        //    get { return Qubits; }
        //    set
        //    {
        //        if (value > 10)
        //        {
        //            Qubits = 10;
        //        }
        //        else if (value < 1)
        //        {
        //            Qubits = 1;
        //        }
        //        else
        //        {
        //            Qubits = value;
        //        }
        //    }
        //}

        //private int Repeats
        //{
        //    get { return Repeats; }
        //    set
        //    {
        //        if (value > 1000)
        //        {
        //            Repeats = 1000;
        //        }
        //        else if (value < 1)
        //        {
        //            Repeats = 1;
        //        }
        //        else
        //        {
        //            Repeats = value;
        //        }
        //    }
        //}

        //private QArray<string> Operations { get; set; }

        //private QArray<long> Parameters { get; set; }

        //public QuantumSimulatorModel(int qubits, int repeats, string[] operations, long[] parameters)
        //{
        //    Qubits = qubits;
        //    Repeats = repeats;

        //    Operations = new QArray<string>(operations);
        //    Parameters = new QArray<long>(parameters);
        //}

        //public int[] QuantumCalculating()
        //{
        // Console.WriteLine($"{Qubits}, {Repeats}, {Operations}, {Parameters}");

        //var sim = new QuantumSimulator();

        //var returnedArray = Constructor.Run(sim, Qubits, Repeats, Operations, Parameters)
        //    .Result.Select(x => (int)x).ToArray();

        //return returnedArray;
        //Console.WriteLine(returnedArray);
        //Result = returnedArray;
        //}
        #endregion

        public void QuantumTest()
        {
            var sim = new QuantumSimulator();

            var teleportation_ops = new QArray<string>(new[] { "SET", "SET", "SET", "H", "CNOT", "CNOT", "H", "IFM", "X", "IFM", "Z" });
            var teleportation_prm = new QArray<long>(new long[] { 0, 1, 1, 0, 2, 0, 2, 2, 1, 0, 1, 0, 1, 1, 2, 0, 1, 2 });

            Console.WriteLine(DataPreparer.QSInstructionsToParams(new string[] { "SET(q1,One)", "SET(q2,Zero)", "SET(q3,Zero)", "H(q3)",
                "CNOT(q3,q2)", "CNOT(q1,q2)", "H(q1)", "IFM(q2,One)", "X(q3)", "IFM(q1,One)", "Z(q3)" }));

            Console.WriteLine(Constructor.Run(sim, 3, 1, teleportation_ops, teleportation_prm).Result);
        }

        

        public int[] QuantumCalculating(int qubits, int repeats, string[] operations, long[] parameters)
        {
            var oprs = new QArray<string>(operations);
            var prms = new QArray<long>(parameters);

            var sim = new QuantumSimulator();

            var returnedArray = Constructor.Run(sim, qubits, repeats, oprs, prms)
                .Result.Select(x => (int)x).ToArray();

            return returnedArray;
        }
    }
}
