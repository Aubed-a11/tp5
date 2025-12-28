using System;
using System.IO;

class Program
{
    static void Main()
    {
        string fichier = "nombres.txt";

        // Écriture des nombres 1 à 1000
        using (StreamWriter sw = new StreamWriter(fichier))
        {
            for (int i = 1; i <= 1000; i++)
            {
                sw.WriteLine(i);
            }
        }
        Console.WriteLine("Fichier créé avec succès !");

        // Lecture du fichier et comptage des caractères
        string contenu = File.ReadAllText(fichier);
        Console.WriteLine($"Le fichier contient {contenu.Length} caractères.");
    }
}
