using System.Collections.Generic;
using System.Text;

namespace TM.Models
{
    public class Tape
    {
        private Dictionary<int, char> cells;
        public int HeadPosition { get; private set; }
        public char BlankSymbol { get; }

        public Tape(string input, char blank)
        {
            cells = new Dictionary<int, char>();
            for (int i = 0; i < input.Length; i++)
                cells[i] = input[i];
            HeadPosition = 0;
            BlankSymbol = blank;
        }

        public char Read() => cells.ContainsKey(HeadPosition) ? cells[HeadPosition] : BlankSymbol;

        public void Write(char symbol) => cells[HeadPosition] = symbol;

        public void MoveHead(MoveDirection move)
        {
            if (move == MoveDirection.Left) HeadPosition--;
            else if (move == MoveDirection.Right) HeadPosition++;
        }

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
