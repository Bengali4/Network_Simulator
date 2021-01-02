using System;
using System.Collections.Generic;
using System.Text;

namespace Electrical_Network
{
    public class Market
    {
        public string name;
        public int Buy_cost;
        public int Sell_cost;
        public readonly Random _random = new Random();
        public Market(string _name) { this.name = _name; }

        public int GetBuyCost()
        {
            this.Check_costs();
            return this.Buy_cost;
        }
        public int GetSellCost()
        {
            this.Check_costs();
            return this.Sell_cost;
        }
        
        public void Check_costs()
        {
            this.Buy_cost = _random.Next(30, 80);
            this.Sell_cost = _random.Next(30, 80);
        }
    }
}
