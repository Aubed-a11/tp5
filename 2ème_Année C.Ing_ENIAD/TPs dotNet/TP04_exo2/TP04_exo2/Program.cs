using System;
using System.Threading.Tasks;

namespace ExerciceAsyncAwait
{
    class Program
    {
       
        static async Task<string> TéléchargerDonnéesAsync()
        {
            Console.WriteLine("Téléchargement en cours...");
            await Task.Delay(3000); 
            return "Données téléchargées !";
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Test sans await ===");
            Console.WriteLine("Début du programme");

            // Appel SANS await
            Task<string> tache = TéléchargerDonnéesAsync();
            
            Console.WriteLine("Fin du programme\n");

            await Task.Delay(3000);

            Console.WriteLine("=== Test avec await ===");
            Console.WriteLine("Début du programme");

            // Appel AVEC await
            string resultat = await TéléchargerDonnéesAsync();
            Console.WriteLine(resultat);
            Console.WriteLine("Fin du programme");
        }
    }
}
