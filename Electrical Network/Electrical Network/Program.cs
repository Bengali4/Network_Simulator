using System;

namespace Electrical_Network
{
    class Program
    {
        static void Main(string[] args)
        {
            ENetwork BelgiumNetwork = new ENetwork();
            BelgiumNetwork.ShowPanel(BelgiumNetwork.Initialize());
            System.Threading.Thread.Sleep(5000);
            BelgiumNetwork.ShowPanel(BelgiumNetwork.Start());
            System.Threading.Thread.Sleep(5000);
            BelgiumNetwork.ShowPanel(BelgiumNetwork.Change1());
            System.Threading.Thread.Sleep(5000);
            BelgiumNetwork.ShowPanel(BelgiumNetwork.Stop());
            System.Threading.Thread.Sleep(5000);

            //notes :
            // Dans la classe centrale nucléaire, faire une surcharge (méthode) on() avec appel de la méthode de l'ancêtre producer base.on
            //vérifier qu'il n'y a pas 2 producteurs connecter à une même ligne
            //Ne pas pouvoir instancier une classe noeud
            //Utiliser des notions de classe abstraite
            //définir des variables noeuds pour recevoir des objets centrale gaz, ville, etc
        }
    }
}
