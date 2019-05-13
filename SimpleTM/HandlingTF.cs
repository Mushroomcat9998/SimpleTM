using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTM
{
    public abstract class HandlingTF
    {
        // TM = O(transitionFunctions.Count * input.Length)
        public void ReadInput(char[] input, string initialState, int curPosition, IList<TransitionFunction> transitionFunctions)
        {
            string direction = string.Empty;
            string state = initialState;
            int count = 1;
            while (direction != "E" && curPosition < input.Length)
            {
                foreach (TransitionFunction func in transitionFunctions)
                {
                    if (string.Equals(state, func.CurrentState) && input[curPosition] == func.CurrentLetter)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(count);
                        Console.ResetColor();
                        Console.WriteLine(". Current Position: " + (curPosition + 1) + ", Current State: "+ state
                            + ", Reading Letter: " + input[curPosition] + ", Next State: " + func.NextState
                            + ", Alternate Letter: " + func.AlternateLetter + ", Direction: " + func.Direction);

                        Console.Write("OLD: ");                        
                        int left = Console.CursorLeft + curPosition; // Get position of the reading letter to set the column position of the cursor
                        Display(input, left, curPosition);

                        state = func.NextState;
                        input[curPosition] = func.AlternateLetter;
                        
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("NEW: ");
                        Console.ResetColor();
                        Display(input, left, curPosition);

                        switch(func.Direction)
                        {
                            case "R": curPosition++; break; // Right
                            case "L": curPosition--; break; // Left
                            case "E": direction = "E"; break; // End
                            case "N": break; // No change
                        }
                        break;
                    }
                }
                count++;
            }          
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nEND");
        }

        public void Display(char[] input, int left, int curPosition)
        {
            Console.Write(input);
            Console.SetCursorPosition(left, Console.CursorTop); // Set the cursor right on the reading letter
            Console.BackgroundColor = ConsoleColor.DarkCyan; // Set the background of the reading letter to Dark Cyan color
            Console.WriteLine(input[curPosition]);
            Console.ResetColor();
        }
    }
}
