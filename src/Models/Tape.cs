using System.Collections.Generic;
using System.Text;

namespace TM.Models
{
    /// <summary>
    /// Represents the tape of a Turing machine, including tape cells, 
    /// head position, and blank symbol management.
    /// </summary>
    public class Tape
    {
        private Dictionary<int, char> cells;
    
        // Current position of the tape head.
        public int HeadPosition { get; private set; }

        // Symbol used to represent an empty cell on the tape.
        public char BlankSymbol { get; }

        // Initializes the tape with an input string and a blank symbol.
        public Tape(string input, char blank)
        {
            cells = new Dictionary<int, char>();
            for (int i = 0; i < input.Length; i++)
                cells[i] = input[i];
            HeadPosition = 0;
            BlankSymbol = blank;
        }

        // Reads the symbol at the current head position.
        public char Read() => cells.ContainsKey(HeadPosition) ? cells[HeadPosition] : BlankSymbol;

        // Writes a symbol at the current head position.
        public void Write(char symbol) => cells[HeadPosition] = symbol;

        // Moves the head left, right, or stays based on the given direction.
        public void MoveHead(MoveDirection move)
        {
            if (move == MoveDirection.Left) HeadPosition--;
            else if (move == MoveDirection.Right) HeadPosition++;
        }

        // Returns a string showing the tape contents, head position, and blank symbol.
        public string GetTapeContents()
        {
            int min = int.MaxValue, max = int.MinValue;
            foreach (var key in cells.Keys)
            {
                if (key < min) min = key;
                if (key > max) max = key;
            }

            var tapeSb = new StringBuilder();
            var headSb = new StringBuilder();
            for (int i = min; i <= max; i++)
            {
                char c = cells.ContainsKey(i) ? cells[i] : BlankSymbol;
                tapeSb.Append(c);
                headSb.Append(i == HeadPosition ? '^' : ' ');
            }

            return $"Tape contents: {tapeSb}\nHead at: {HeadPosition} (shown with ^ below)\n{tapeSb}\n{headSb}\nBlank symbol: '{BlankSymbol}'";
        }
    }
}
