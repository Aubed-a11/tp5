using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

public class Etudiant
{
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public int Age { get; set; }
    public double Moyenne { get; set; }

    public override string ToString()
    {
        return $"{Prenom} {Nom}, {Age} ans, Moyenne: {Moyenne}";
    }
}

class Program
{
    static void Main()
    {
        List<Etudiant> etudiants = new List<Etudiant>();

        // --- Saisie des étudiants ---
        for (int i = 0; i < 2; i++)
        {
            Etudiant e = new Etudiant();
            Console.WriteLine($"\nÉtudiant {i + 1}:");
            Console.Write("Nom: "); e.Nom = Console.ReadLine();
            Console.Write("Prénom: "); e.Prenom = Console.ReadLine();
            Console.Write("Âge: "); e.Age = int.Parse(Console.ReadLine());
            Console.Write("Moyenne: "); e.Moyenne = double.Parse(Console.ReadLine());
            etudiants.Add(e);
        }

        // --- Sérialisation JSON (remplace BinaryFormatter) ---
        string jsonPath = "etudiants.json";
        string json = JsonSerializer.Serialize(etudiants, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(jsonPath, json);

        // --- Désérialisation JSON ---
        string jsonLu = File.ReadAllText(jsonPath);
        List<Etudiant> etudiantsJson = JsonSerializer.Deserialize<List<Etudiant>>(jsonLu);

        Console.WriteLine("\nÉtudiants chargés depuis le fichier JSON :");
        etudiantsJson.ForEach(e => Console.WriteLine(e));

        // --- Sérialisation XML ---
        XmlSerializer xs = new XmlSerializer(typeof(List<Etudiant>));
        using (FileStream fs = new FileStream("etudiants.xml", FileMode.Create))
        {
            xs.Serialize(fs, etudiants);
        }

        // --- Désérialisation XML ---
        List<Etudiant> etudiantsXml;
        using (FileStream fs = new FileStream("etudiants.xml", FileMode.Open))
        {
            etudiantsXml = (List<Etudiant>)xs.Deserialize(fs);
        }

        Console.WriteLine("\nÉtudiants chargés depuis le fichier XML :");
        etudiantsXml.ForEach(e => Console.WriteLine(e));
    }
}


