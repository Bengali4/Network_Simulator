using System;
using System.Collections.Generic;
using System.Text;

namespace Electrical_Network
{
    public class Producer : Node
    {
        public double costProductionRatio;

        public double co2ProductionRatio;

        public Producer(string name, Line pOutputLine, double costRatio, double co2Ratio) : base(name)
        {
            this.outputLines = new List<Line>() { pOutputLine };
            this.costProductionRatio = costRatio;
            this.co2ProductionRatio = co2Ratio;
        }

        public double GetProductionCost()
        {
            return (this.currentPower * this.costProductionRatio);
        }

        public double GetProductionCO2()
        {
            return (this.currentPower * this.co2ProductionRatio);
        }

        public void Show()
        {
            Console.WriteLine();
            Console.WriteLine(this.name);
            Console.WriteLine("Puissance courante : " + this.currentPower);
        }

        public void On(double pCurrentPower)
        {
            this.currentPower = pCurrentPower;
            this.outputLines[0].TransferPower(this.currentPower);
        }

        public void Off()
        {
            this.currentPower = 0;
            this.outputLines[0].TransferPower(this.currentPower);
        }
    }
}
