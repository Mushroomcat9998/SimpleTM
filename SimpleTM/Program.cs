using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTM
{
    class Program
    {
        public static bool CheckInput(string input)
        {
            foreach (var c in input.ToCharArray())
            {
                if (c != '1' && c != '0' && c != 'B') return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            string input = string.Empty;
            do
            {
                Console.Write("Please enter a string only including 0 and (or) 1 and (or) B (Blank): ");
                input = Console.ReadLine();
            }
            while (!CheckInput(input));

            AddingTF addingTF = new AddingTF();
            addingTF.FillTF();
            try
            {
                addingTF.ReadInput(input.ToCharArray(), "0", 0, addingTF.AddTF);
            }
            catch(Exception e)
            {
                Console.WriteLine("Turing Machine can't read your input!");
            }
            Console.ReadLine();
        }
    }
}
