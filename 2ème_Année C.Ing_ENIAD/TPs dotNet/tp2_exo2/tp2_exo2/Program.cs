using System;

namespace RechercheTableau
{
    class NoSuchElementException : Exception
    {
        public NoSuchElementException(string message) : base(message) { }
    }

    class Program
    {
        static int Recherche(int[] tableau, int valeur)
        {
            for (int i = 0; i < tableau.Length; i++)
            {
                if (tableau[i] == valeur)
                    return i;
            }
            throw new NoSuchElementException($"L’élément {valeur} n’existe pas dans le tableau !");
        }

        static void Main()
        {
            int[] tab = { 10, 5, 7, 12, 20 };

            try
            {
                Console.Write("Entrez la valeur à rechercher : ");
                int v = int.Parse(Console.ReadLine());
                int pos = Recherche(tab, v);
                Console.WriteLine($"Valeur trouvée à la position {pos}");
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Veuillez entrer un nombre valide !");
            }
            finally
            {
                Console.WriteLine("Au revoir !");
            }
        }
    }
}
