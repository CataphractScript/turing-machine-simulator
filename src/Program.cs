using System;
using TM.Models;
using TM.Services;
using TM.Inputs;

namespace TM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tm = new TuringMachine();

            // Load machine from Inputs (hard-coded)
            tm.Initialize(
                MachineInputs.StartState,
                MachineInputs.States,
                MachineInputs.AcceptStates,
                MachineInputs.BlankSymbol,
                MachineInputs.Transitions,
                MachineInputs.Tape
            );

            var result = tm.Run();

            Console.WriteLine("******************************");
            Console.WriteLine("Final tape (trimmed): " + result.finalTape);
            Console.WriteLine("Halted: " + result.halted);
            Console.WriteLine("Accepted: " + result.accepted);
            Console.WriteLine("Final state: " + result.finalState);
            Console.WriteLine("Steps: " + result.steps);
            Console.WriteLine("Full tape with head:");
            Console.WriteLine("******************************");

        }
    }
}
