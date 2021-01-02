using System;
using System.Collections.Generic;
using System.Text;

namespace Electrical_Network
{
    public class Environmental_Producer : Producer
    {
        public string status;
        public double conversionRatio;

        public Environmental_Producer(string name, Line pOutputLine, double costRatio, double co2Ratio, string _status, double _conversionRatio) : base(name, pOutputLine, costRatio, co2Ratio)
        {
            this.status = _status;
            this.conversionRatio = _conversionRatio;
        }

        public void Update(int param)
        {
            this.currentPower = param*this.conversionRatio;
            this.outputLines[0].TransferPower(this.currentPower);
        }
    }
}
