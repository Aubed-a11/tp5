using System;

namespace Test
{
    class Program
    {
        static int[] tableau = new int[] { 17, 12, 15, 38, 29, 157, 89, -22, 0, 5 }; //Déclaration de tableau de 10 valeurs 

        static int division(int indice, int diviseur)
        {
            return tableau[indice] / diviseur; 
        }

        public static void Main(string[] args)
        {
            bool succes = false;

            while (!succes)
            {
                try
                {
                    Console.WriteLine("Entrez l’indice de l’entier à diviser: ");
                    int x = int.Parse(Console.ReadLine());

                    Console.WriteLine("Entrez le diviseur: ");
                    int y = int.Parse(Console.ReadLine());

                    int resultat = division(x, y);
                    Console.WriteLine($"Le résultat de la division est: {resultat}");
                    succes = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erreur : Vous devez entrer un nombre entier !");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Erreur : L’indice saisi n’existe pas dans le tableau !");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Erreur : Division par zéro impossible !");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur inattendue : {ex.Message}");
                }
            }
        }
    }
}

