using System;
using System.Collections.Generic;
using System.Text;

namespace Electrical_Network
{
    public class GasCentral : Producer
    {
        public double gasQuantity;

        public GasCentral(string name, Line pOutputLine, double costRatio, double co2Ratio, double pGasQuant) : base(name, pOutputLine, costRatio, co2Ratio)
        {
            this.gasQuantity = pGasQuant;
        }

        public void SetPowerTo(double power)
        {
            this.currentPower = power;
            this.outputLines[0].TransferPower(this.currentPower);
        }
    }
}
