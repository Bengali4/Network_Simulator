using System;
using System.Collections.Generic;
using System.Text;

namespace Electrical_Network
{
    public class Concentrator : Node
    {
        public Concentrator(string name, List<Line> pInputLines,Line pOutputLine) : base(name)
        {
            this.inputLines = pInputLines;
            this.outputLines = new List<Line>() { pOutputLine };
        }

        public override void TransferPower(double power)
        {
            this.currentPower = 0;
            foreach (Line inputLine in inputLines)
            {
                this.currentPower += inputLine.GetCurrentPower();
            }
            this.outputLines[0].TransferPower(this.currentPower);
        }
    }
}
