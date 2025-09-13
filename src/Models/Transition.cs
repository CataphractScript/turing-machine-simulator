namespace TM.Models
{
    /// <summary>
    /// Represents a single transition rule of a Turing machine.
    /// </summary>
    public class Transition
    {
        public string CurrentState { get; set; }
        public char ReadSymbol { get; set; }
        public string NextState { get; set; }
        public char WriteSymbol { get; set; }
        public MoveDirection Move { get; set; }

        // Initializes a transition rule.
        public Transition(string currentState, char readSymbol, string nextState, char writeSymbol, MoveDirection move)
        {
            CurrentState = currentState;
            ReadSymbol = readSymbol;
            NextState = nextState;
            WriteSymbol = writeSymbol;
            Move = move;
        }
    }
}
