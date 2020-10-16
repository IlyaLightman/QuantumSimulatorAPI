using System;
using System.Collections.Generic;
using System.Linq;

namespace QuantumSimulatorAPI
{
    public static class DataPreparer
    {
        public static (string[], long[]) QSInstructionsToParams(string[] instructions)
        {
            var insts = instructions;

            List<string> returnedOperations = new List<string>() { };
            List<long> returnedParams = new List<long>() { };

            foreach (var inst in insts)
            {
                var instruction = inst.Trim();

                int zeroIndx = instruction.IndexOf("Zero");
                if (zeroIndx > 0)
                {
                    instruction = instruction.Remove(zeroIndx, 4);
                    instruction = instruction.Insert(zeroIndx, "0");
                }
                else
                {
                    int oneIndx = instruction.IndexOf("One");
                    if (oneIndx > 0)
                    {
                        instruction = instruction.Remove(oneIndx, 3);
                        instruction = instruction.Insert(oneIndx, "1");
                    }
                }

                int q = instruction.LastIndexOf("q");
                while (q > 0)
                {
                    if (instruction[q + 1] != ',' || instruction[q + 1] != ')')
                    {
                        int toInsert = (int)(Math.Truncate(Char.GetNumericValue(instruction[q + 1])) - 1);
                        instruction = instruction.Remove(q, 2);
                        instruction = instruction.Insert(q, $"{toInsert}");
                        
                    } 
                    else
                    {
                        int toInsert = (int)(Math.Truncate(Char.GetNumericValue(instruction[q + 2])) + 10 - 1);
                        instruction = instruction.Remove(q, 3);
                        instruction = instruction.Insert(q, $"{toInsert}");
                    }
                    q = instruction.LastIndexOf("q");
                }

                int first = instruction.IndexOf("(");
                int last = instruction.IndexOf(")");

                string operation = instruction.Substring(0, first);
                string numbers = instruction.Substring(first + 1, last - first - 1);

                long[] prms = numbers.Split(",").
                    Where(x => !string.IsNullOrWhiteSpace(x)).
                    Select(x => long.Parse(x)).ToArray();

                returnedOperations.Add(operation);
                returnedParams.AddRange(prms);
            }

            return (returnedOperations.ToArray<string>(), returnedParams.ToArray<long>());
        }
    }
}