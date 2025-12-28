using System;

namespace OperationApp
{
    class Program
    {
  
        public delegate double Operation(double a, double b);

      
        public class Calculatrice
        {
            public double Addition(double a, double b)
            {
                return a + b;
            }

            public double Soustraction(double a, double b)
            {
                return a - b;
            }

            public double Multiplication(double a, double b)
            {
                return a * b;
            }

            public double Division(double a, double b)
            {
                if (b == 0)
                {
                    Console.WriteLine("Erreur : division par zéro !");
                    return double.NaN;
                }
                return a / b;
            }
        }
       
     
        static void Main(string[] args)
        {
            Console.WriteLine("=== Mini Calculatrice avec Délégué ===\n");

            
            Console.Write("Saisissez le premier nombre : ");
            double a = double.Parse(Console.ReadLine());

            Console.Write("Saisissez le deuxième nombre : ");
            double b = double.Parse(Console.ReadLine());

            
            Console.WriteLine("\nChoisissez une opération :");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Soustraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.Write("Entrez votre choix : ");
            int choice = int.Parse(Console.ReadLine());

            Calculatrice calc = new Calculatrice();

           
            Operation op = null;

          
            switch (choice)
            {
                case 1:
                    op = calc.Addition;
                    break;
                case 2:
                    op = calc.Soustraction;
                    break;
                case 3:
                    op = calc.Multiplication;
                    break;
                case 4:
                    op = calc.Division;
                    break;
                default:
                    Console.WriteLine("Aucune opération ne correspond.");
                    return;
            }

            
            double resultat = op(a, b);
            Console.WriteLine($"\nRésultat = {resultat}");
        }
    }
}
