using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTM
{
    public class AddingTF : HandlingTF
    {
        public IList<TransitionFunction> AddTF = new List<TransitionFunction>();
        //{
        //    new TransitionFunction("0", '0', "0", '0', "R"),
        //    new TransitionFunction("0", '1', "1", '1', "R"),
        //    new TransitionFunction("1", '0', "2", '1', "R"),
        //    new TransitionFunction("1", '1', "1", '1', "R"),
        //    new TransitionFunction("2", '0', "3", '0', "L"),
        //    new TransitionFunction("2", '1', "2", '1', "R"),
        //    new TransitionFunction("3", '0', " ", ' ', "E"),
        //    new TransitionFunction("3", '1', "0", '0', "N")
        //};

        public void FillTF()
        {
            List<string> FileLines = File.ReadAllLines("D:\\CSharp\\TMSimulation\\SimpleTM\\matrix.txt", Encoding.Default).ToList();
            foreach (string line in FileLines)
            {
                if (line == FileLines[0]) continue;
                string[] items = line.Split(' ');
                TransitionFunction TF = new TransitionFunction();

                TF.CurrentState = items[0];
                TF.CurrentLetter = Convert.ToChar(items[1]);

                if (items[2] == "-") TF.NextState = " ";
                else TF.NextState = items[2];

                if (items[3] == "-") TF.AlternateLetter = ' ';
                else TF.AlternateLetter = Convert.ToChar(items[3]);

                TF.Direction = items[4];

                AddTF.Add(TF);
            }
        }
    }
}
