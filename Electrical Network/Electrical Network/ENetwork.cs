using System;
using System.Collections.Generic;
using System.Text;

namespace Electrical_Network
{
    public class ENetwork
    {
        GasCentral amercoeur;
        Line line1;
        Distributor distribMons;
        Line line2;
        City tournai;
        Line line3;
        GasCentral izegem;
        Line line4;
        Concentrator concentAth;
        Line line5;
        City charleroi;
        ControlCentre controlCentreBelgium;
        List<Producer> producers;
        List<Consumer> consumers;
        List<Distributor> distributors;
        List<Concentrator> concentrators;
        List<Line> lines;

        public string Initialize()
        {
            this.line1 = new Line("Ligne Amercoeur-DistribMons", 11);
            this.amercoeur = new GasCentral("Amercoeur", line1, 5000, 12000, 100000);
            this.line2 = new Line("Ligne DistribMons-Tournai", 10);
            this.tournai = new City("Tournai", line2, 5000);
            this.line3 = new Line("Ligne DistribMons-ConcentAth", 10);
            this.distribMons = new Distributor("Distributeur de Mons", line1, new List<Line>() { line2, line3 }, new List<double>() { 0.5, 0.5 });
            this.line4 = new Line("Ligne Izegem-ConcentAth", 10);
            this.izegem = new GasCentral("Izegem", line4, 5000, 12000, 10000);
            this.line5 = new Line("Ligne ConcentAth-Charleroi", 10);
            this.charleroi = new City("Charleroi", line5, 7000);
            this.concentAth = new Concentrator("Concentrateur d'Ath", new List<Line>() { line3, line4 }, line5);

            this.line1.SetNodes(amercoeur, distribMons);
            this.line2.SetNodes(distribMons, tournai);
            this.line3.SetNodes(distribMons, concentAth);
            this.line4.SetNodes(izegem, concentAth);
            this.line5.SetNodes(concentAth, charleroi);

            this.producers = new List<Producer>() { amercoeur, izegem };
            this.consumers = new List<Consumer>() { tournai, charleroi };
            this.distributors = new List<Distributor>() { distribMons };
            this.concentrators = new List<Concentrator>() { concentAth };
            this.lines = new List<Line>() { line1, line2, line3, line4, line5 };

            this.controlCentreBelgium = new ControlCentre(producers, consumers, distributors, concentrators, lines);

            return ("Réseau initailisé");
        }

        public string Start()
        {
            amercoeur.On(10);
            izegem.On(4);
            tournai.SetPowerConsumed(5);
            charleroi.SetPowerConsumed(9);
            return "La centrale à gaz Amercoeur est allumée avec une puissance de 10 GW";
        }

        public string Change1()
        {
            amercoeur.SetPowerTo(12);
            return "La puissance de la centrale à gaz Amercoeur changée à 12 GW";
        }

        public string Stop()
        {
            amercoeur.Off();
            izegem.Off();
            tournai.SetPowerConsumed(0);
            charleroi.SetPowerConsumed(0);
            return "La centrale à gaz Amercoeur est éte doublee";
        }

        public void ShowPanel(string pevent)
        {
            controlCentreBelgium.ShowPanel(pevent);
        }
    }
}
