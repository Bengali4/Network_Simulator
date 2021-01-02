using System;
using System.Collections.Generic;
using System.Text;

namespace Electrical_Network
{
    public class City : Consumer
    {
        public City(string name, Line pInputLine, double costRatio) : base(name, pInputLine, costRatio)
        {
        }
    }
}
