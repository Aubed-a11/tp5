using System;

namespace SimulationAlarme
{
    
    public delegate void TemperatureDepasseeEventHandler(double temperature);

   
    public class Capteur
    {
        public double Temperature { get; private set; }

       
        public event TemperatureDepasseeEventHandler TemperatureDepassee;

        public void Mesurer(double valeur)
        {
            Temperature = valeur;
            Console.WriteLine($"Température mesurée : {Temperature} °C");

            if (Temperature > 30)
            {
                TemperatureDepassee?.Invoke(Temperature);
            }
        }
    }

    public class Alerte
    {
        
        public void AfficherAlerte(double t)
        {
            Console.WriteLine($"⚠️ Alerte : température élevée ({t} °C) !");
        }
    }

  
    class Program
    {
        static void Main(string[] args)
        {
            Capteur capteur = new Capteur();
            Alerte alerte = new Alerte();

            capteur.TemperatureDepassee += alerte.AfficherAlerte;

            /
            capteur.Mesurer(28);  
            capteur.Mesurer(32);  
            capteur.Mesurer(35);  
    }
}
