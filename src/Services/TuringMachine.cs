using System;
using System.Collections.Generic;
using TM.Models;

namespace TM.Services
{
    public class TuringMachine
    {
        private Dictionary<(string, char), Transition> transitions;
        private HashSet<string> states;
        private HashSet<string> acceptStates;
        private string currentState;
        private char blankSymbol;
        public Tape Tape { get; private set; }

        public void Initialize(string startState, List<string> allStates, List<string> acceptStatesList, char blank, List<Transition> transitionList, string inputTape)
        {
            currentState = startState;
            states = new HashSet<string>(allStates);
            acceptStates = new HashSet<string>(acceptStatesList);
            blankSymbol = blank;
            Tape = new Tape(inputTape, blank);

            transitions = new Dictionary<(string, char), Transition>();
            foreach (var t in transitionList)
                transitions[(t.CurrentState, t.ReadSymbol)] = t;
        }

        public (string finalTape, string finalState, bool halted, bool accepted, int steps) Run(int maxSteps = 10000)
        {
            int step = 0;
            while (!acceptStates.Contains(currentState) && step < maxSteps)
            {
                if (!TryStep()) break;
                step++;
            }

            return (Tape.GetTapeContents(), currentState, step < maxSteps, acceptStates.Contains(currentState), step);
        }

        private bool TryStep()
        {
            char read = Tape.Read();
            if (!transitions.TryGetValue((currentState, read), out var transition))
                return false;

            Tape.Write(transition.WriteSymbol);
            Tape.MoveHead(transition.Move);
            currentState = transition.NextState;
            return true;
        }
    }
}
