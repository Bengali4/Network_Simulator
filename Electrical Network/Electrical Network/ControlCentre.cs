using System;
using System.Collections.Generic;
using System.Text;

namespace Electrical_Network
{
    public class ControlCentre
    {
        public List<Producer> producers;

        public List<Consumer> consumers;

        public List<Distributor> distributors;

        public List<Concentrator> concentrators;

        public List<Line> lines;

        public ControlCentre(List<Producer> pProducers, List<Consumer> pConsumers, List<Distributor> pDistributors, List<Concentrator> pConcentrators, List<Line> pLines)
        {
            this.producers = pProducers;
            this.consumers = pConsumers;
            this.distributors = pDistributors;
            this.concentrators = pConcentrators;
            this.lines = pLines;
        }

        public void ShowPanel(string pevent)
        {
            string littleStep = "-------------------------------------------------------------------------------";
            string bigStep = "*******************************************************************************";
            Console.Clear();
            Console.WriteLine(bigStep);
            Console.WriteLine(pevent);
            Console.WriteLine(bigStep);
            Console.WriteLine();
            Console.WriteLine("Producteurs   | Production [GW] | Coût [EUR] | CO2 [kg]");
            Console.WriteLine(littleStep);
            foreach (Producer producer in producers)
            {
                Console.WriteLine(String.Format("{0,-13} | {1,-15} | {2,-10} | {3,-9}", producer.GetName(), producer.GetCurrentPower(), producer.GetProductionCost(), producer.GetProductionCO2()));
            }
            Console.WriteLine(littleStep);
            Console.WriteLine();
            Console.WriteLine(littleStep);
            Console.WriteLine("Consommateurs | Puissance reçue [GW] | Consommation [GW] | Prix [EUR]");
            Console.WriteLine(littleStep);
            foreach (Consumer consumer in consumers)
            {
                Console.WriteLine(String.Format("{0,-13} | {1,-20} | {2,-16} | {3,-9}", consumer.GetName(),consumer.GetCurrentPower(), consumer.GetPowerConsumed(), consumer.GetConsumptionCost()));
            }
            Console.WriteLine(littleStep);
            Console.WriteLine();
            Console.WriteLine(bigStep);
            Console.WriteLine("Messages :");
            foreach (string message in Verify())
            {
                Console.WriteLine(message);
            }
            Console.WriteLine(bigStep);
        }
        public List<string> Verify()
        {
            List<string> warnings = new List<string>() { };
            foreach (Line line in lines)
            {
                if (line.GetCurrentPower() > line.GetMaxPower())
                {
                    warnings.Add("Attention il y a une surcharge de " + (line.GetCurrentPower() - line.GetMaxPower()) + " GW sur la " + line.GetName() + " de puissance maximum " + line.GetMaxPower() + " GW");
                }
                if (line.GetCurrentPower() == 0)
                {
                    warnings.Add("Attention il y a un black out sur la " + line.GetName());
                }
            }
            foreach (Consumer consumer in consumers)
            {
                if (consumer.GetPowerConsumed() > consumer.GetCurrentPower())
                {
                    warnings.Add("Attention sous-production : le consommateur " + consumer.GetName() + " consomme " + (consumer.GetPowerConsumed() - consumer.GetCurrentPower()) + " [GW] de plus que la puissance reçue");
                }
                if (consumer.GetPowerConsumed() < consumer.GetCurrentPower())
                {
                    warnings.Add("Attention sur-production : le consommateur " + consumer.GetName() + " consomme " + (consumer.GetCurrentPower() - consumer.GetPowerConsumed()) + " [GW] de moins que la puissance reçue");
                }
            }
            foreach (Producer producer in producers)
            {
                // Rien à détecter (demander au prof si sur et sous production est bien à vérifier sur les consommateurs
            }

            return warnings;
        }

        public void AutoAdapt(string action)
        {
              // Les messages d'alertes sont trouver grâce à la fonction Verify() et il faudrait que cette méthode soit appelé
              // lors d'une sur ou sous production pour faire varier les producteurs ou résoudre le problème d'une autre manière

              // Ancien code test :
        //    List<Line> pInputLines = pNode.GetInputLines();
        //    foreach (Line pLine in pInputLines)
        //    {
                //Node previusNode = pLine.GetInputNode();
                //if (previusNode is GasCentral)
                //{
                //    GasCentral pGasCentral = (GasCentral)previusNode;
                //    pGasCentral.SetPowerTo();
        //        }
        //    }
        }
    }
}
