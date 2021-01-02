using System;
using System.Collections.Generic;
using System.Text;

namespace Electrical_Network
{
    public class Node
    {
        public string name;

        public double currentPower;

        public List<Line> outputLines;

        public List<Line> inputLines;

        public Node(string pname)
        {
            this.name = pname;
        }

        public string GetName()
        {
            return this.name;
        }

        public double GetCurrentPower()
        {
            return this.currentPower;
        }

        public virtual void TransferPower(double power)
        {
            this.currentPower = power;
            this.outputLines[0].TransferPower(this.currentPower);
        }
    }
}
