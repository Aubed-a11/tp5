using System;
using System.IO;

class Program
{
    static void CCP_TEST(int numeroCompte, int controle)
    {
        int reste = numeroCompte % 97;

        if ((reste != 0 && reste == controle) || (reste == 0 && controle == 97))
            Console.WriteLine($"{numeroCompte}-{controle} : correct");
        else
            Console.WriteLine($"{numeroCompte}-{controle} : incorrect");
    }

    static void Main()
    {
        string fichier = "CCP.txt";

        // 1️⃣ Vérifier si le fichier existe, sinon le créer
        if (!File.Exists(fichier))
        {
            string[] lignesACreer = {
                "15742-28",
                "72270-5",
                "22610-10",
                "50537-0",
                "50537-97"
            };
            File.WriteAllLines(fichier, lignesACreer);
            Console.WriteLine("Fichier CCP.txt créé automatiquement !");
        }

        // 2️⃣ Lire le fichier **après sa création**
        string[] lignes = File.ReadAllLines(fichier);

        // 3️⃣ Parcourir chaque ligne
        foreach (var ligne in lignes)
        {
            if (string.IsNullOrWhiteSpace(ligne))
                continue; // ignorer les lignes vides

            string[] parties = ligne.Split('-');
            if (parties.Length == 2 &&
                int.TryParse(parties[0], out int numCompte) &&
                int.TryParse(parties[1], out int numControle))
            {
                CCP_TEST(numCompte, numControle);
            }
            else
            {
                Console.WriteLine($"{ligne} : format invalide");
            }
        }
    }
}

