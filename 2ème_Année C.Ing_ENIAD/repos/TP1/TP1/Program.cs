using System;
namespace ProgrammeTest
{
    class Program
    {
        static void Main()
        {
            Console.Write("Entrez une chaîne : ");
            string chaine = Console.ReadLine();
            int longueur = 0;
            foreach (char c in chaine)
            {
                longueur++;
            }
            Console.WriteLine("La longueur de la chaîne est : " + longueur);

            Console.WriteLine("Les caractères dans l'ordre inverse sont :");

            for (int i = chaine.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(chaine[i]);
            }

            Console.Write("Entrez la taille du tableau (N) : ");
            int N = int.Parse(Console.ReadLine());

            Console.Write("Entrez la valeur à insérer (X) : ");
            int X = int.Parse(Console.ReadLine());

            Console.Write("Entrez la position d’insertion (pos partir de 0) : ");
            int pos = int.Parse(Console.ReadLine());

            if (pos < 0 || pos > N)
            {
                Console.WriteLine("❌ Position invalide !");
                return;
            }
            int[] tableau = new int[N];
            Random rand = new Random();

            for (int k = 0; k < N; k++)
            {
                tableau[k] = rand.Next(0, 100);
            }

            Console.WriteLine("\nTableau avant insertion :");
            AfficherTableau(tableau);

            int[] nouveauTableau = new int[N + 1];

            for (int k = 0; k < pos; k++)
            {
                nouveauTableau[k] = tableau[k];
            }

            nouveauTableau[pos] = X;

            for (int k = pos; k < N; k++)
            {
                nouveauTableau[k + 1] = tableau[k];
            }

            Console.WriteLine("\nTableau après insertion :");
            AfficherTableau(nouveauTableau);
        }

        static void AfficherTableau(int[] tab)
        {
            foreach (int val in tab)
            {
                Console.Write(val + " ");
            }
            Console.WriteLine();
        }

    }
}

