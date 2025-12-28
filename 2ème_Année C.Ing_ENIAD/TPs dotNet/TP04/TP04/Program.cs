using System;

namespace ExerciceGeneriques
{
   
    public class Boite<T>
    {
        private T contenu; 

        public void Ajouter(T element)
        {
            contenu = element;
        }

        public T Lire()
        {
            return contenu;
        }
    }

    public class Personne
    {
        public string Nom { get; set; }
        public int Age { get; set; }

        public Personne(string nom, int age)
        {
            Nom = nom;
            Age = age;
        }

        public override string ToString()
        {
            return $"Nom : {Nom}, Âge : {Age}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Boite<int> boiteInt = new Boite<int>();
            boiteInt.Ajouter(123);
            Console.WriteLine($"Boîte d'entier contient : {boiteInt.Lire()}");

            Boite<string> boiteString = new Boite<string>();
            boiteString.Ajouter("Bonjour ");
            Console.WriteLine($"Boîte de chaîne contient : {boiteString.Lire()}");

            Boite<Personne> boitePersonne = new Boite<Personne>();
            boitePersonne.Ajouter(new Personne("Ali", 25));
            Console.WriteLine($"Boîte de personne contient : {boitePersonne.Lire()}");
        }
    }
}




