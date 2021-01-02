using System;
using System.Collections.Generic;
using System.Text;

namespace Electrical_Network
{
    public class Meteo
    {
        public string name;
        public int Solar;
        public int Wind;
        public int Heat;
        public Dictionary<string, int> Dico_Impact = new Dictionary<string, int>();
        public readonly Random _random = new Random();

        public Meteo(string name_meteo)
        {
            this.name = name_meteo;
            this.Dico_Impact.Add("Solar", this.Solar);
            this.Dico_Impact.Add("Wind", this.Wind);
            this.Dico_Impact.Add("Heat", this.Heat);
        }

        
        public int Update(string param)
        {
            this.Check_Weather();
            return this.Dico_Impact[param];
        }

        public int GetValue(string param)
        {
            return this.Dico_Impact[param];
        }

        public void Check_Weather()
        {
            this.Dico_Impact["Solar"] = _random.Next(30, 80);
            this.Dico_Impact["Wind"] = _random.Next(30, 80);
            this.Dico_Impact["Heat"] = _random.Next(30, 80);
        }
    }
}
