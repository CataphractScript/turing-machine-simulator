using System.Collections.Generic;
using TM.Models;

namespace TM.Inputs
{
    public static class MachineInputs
    {
        // Input example: aaaabbbb
        public static string Tape => "aaaabbbb";

        // Transitions for unary increment
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

        public static List<string> States => new() { "q0", "q1", "q2", "q3", "q_accept" };

        public static List<string> AcceptStates => new() { "q_accept" };

        public static string StartState => "q0";

        public static char BlankSymbol => '_';
    }
}
