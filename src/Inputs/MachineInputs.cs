using System.Collections.Generic;
using TM.Models;

namespace TM.Inputs
{
    /// <summary>
    /// Defines a sample Turing machine with states, transitions, and input tape.
    /// </summary>
    public static class MachineInputs
    {
        /// <summary>
        /// Initial tape input for the machine.
        /// This input belongs to the language L = {a^n b^n : n ≥ 1}.
        /// Example: "aaaabbbb" (n=4).
        /// </summary>
        public static string Tape => "aaaabbbb";

        // Transition rules for this machine.
        public static List<Transition> Transitions => new()
        {
            new Transition("q0", 'a', "q1", 'x', MoveDirection.Right),
            new Transition("q1", 'a', "q1", 'a', MoveDirection.Right),
            new Transition("q1", 'y', "q1", 'y', MoveDirection.Right),
            new Transition("q1", 'b', "q2", 'y', MoveDirection.Left),
            new Transition("q2", 'y', "q2", 'y', MoveDirection.Left),
            new Transition("q2", 'a', "q2", 'a', MoveDirection.Left),
            new Transition("q2", 'x', "q0", 'x', MoveDirection.Right),
            new Transition("q0", 'y', "q3", 'y', MoveDirection.Right),
            new Transition("q3", 'y', "q3", 'y', MoveDirection.Right),
            new Transition("q3", '_', "q_accept", '_', MoveDirection.Left)
        };

        // All states of the machine.
        public static List<string> States => new() { "q0", "q1", "q2", "q3", "q_accept" };

        // Accepting states of the machine.
        public static List<string> AcceptStates => new() { "q_accept" };

        // Start state of the machine.
        public static string StartState => "q0";

        // Blank symbol used on the tape.
        public static char BlankSymbol => '_';
    }
}
