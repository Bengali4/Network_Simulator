using System;
using System.Collections.Generic;
using System.Text;

namespace Electrical_Network
{
    public class Distributor : Node
    {
        public List<double> distribRatio;

        public Distributor(string name, Line pInputLine, List<Line> pOutputLines, List<double> pDistribRatio) : base(name)
        {
            this.distribRatio = pDistribRatio;
            this.inputLines = new List<Line>() { pInputLine }; ;
            this.outputLines = pOutputLines;
        }

        public void Show()
        {
            Console.WriteLine("\n" + this.name);
            Console.WriteLine("Puissance courante : " + this.currentPower);
        }
        public override void TransferPower(double power)
        {
            this.currentPower = power;
            for (int index = 0; index < this.outputLines.Count; index++)
            {
                this.outputLines[index].TransferPower(this.currentPower * this.distribRatio[index]);
            }
        }
    }
}
