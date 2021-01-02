using System;
using System.Collections.Generic;
using System.Text;

namespace Electrical_Network
{
    public class Consumer : Node
    {
        public double powerConsumed;

        public double costConsumptionRatio;

        public Consumer(string name, Line pInputLine, double costRatio) : base(name)
        {
            this.costConsumptionRatio = costRatio;
            this.inputLines = new List<Line>() { pInputLine };
        }

        public double GetPowerConsumed()
        {
            return this.powerConsumed;
        }

        public double GetConsumptionCost()
        {
            return (this.currentPower * this.costConsumptionRatio);
        }

        public void SetPowerConsumed(double power)
        {
            this.powerConsumed = power;
        }

        public override void TransferPower(double power)
        {
            this.currentPower = power;
        }
    }
}