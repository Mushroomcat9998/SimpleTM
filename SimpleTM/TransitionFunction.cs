using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTM
{
    public class TransitionFunction
    {
        public string CurrentState { get; set; }
        public char CurrentLetter { get; set; }
        public string NextState { get; set; }
        public char AlternateLetter { get; set; }
        public string Direction { get; set; }

        public TransitionFunction() { }
        public TransitionFunction(string curState, char curLetter, string nextState, char altLetter, string direction)
        {
            CurrentState = curState;
            CurrentLetter = curLetter;
            NextState = nextState;
            AlternateLetter = altLetter;
            Direction = direction;
        }
    }
}
