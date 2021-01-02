using System;
using System.Collections.Generic;
using System.Text;

namespace Electrical_Network
{
    public class Line
    {
        public string name;

        public double maxPower;

        public Node inputNode;

        public Node outputNode;

        public double currentPower;

        public Line(string pName, double pMaxPower)
        {
            this.name = pName;
            this.maxPower = pMaxPower;
        }
        public void SetNodes(Node pInputNode, Node pOutputNode)
        {
            this.inputNode = pInputNode;
            this.outputNode = pOutputNode;
        }
        public double GetCurrentPower()
        {
            return this.currentPower;
        }

        public double GetMaxPower()
        {
            return this.maxPower;
        }

        public string GetName()
        {
            return this.name;
        }

        public void TransferPower(double power)
        {
            this.currentPower = power;
            outputNode.TransferPower(this.currentPower);
        }
        public void Show()
        {
            Console.WriteLine();
            Console.WriteLine(this.name);
            Console.WriteLine("Puissance courante : " + this.currentPower);
        }
    }
}
