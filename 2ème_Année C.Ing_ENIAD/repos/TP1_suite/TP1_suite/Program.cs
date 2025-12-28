using System;
using System.Collections.Generic;

namespace GestionEtudiants
{
    public class Personne
    {
        private int numero;
        private string nom;
        private string prenom;

        public int Numero { get => numero; set => numero = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }

        // Constructeurs ajoutés pour permettre l'héritage
        public Personne() { }
        public Personne(int numero, string nom, string prenom)
        {
            this.numero = numero;
            this.nom = nom;
            this.prenom = prenom;
        }

        public override string ToString()
        {
            return $"Numéro: {numero}, Nom: {nom}, Prénom: {prenom}";
        }
    }

    public class Etudiant : Personne
    {
        private string filiere;
        private float[] notes;

        public string Filiere { get => filiere; set => filiere = value; }
        public float[] Notes
        {
            get => notes;
            set => notes = value;
        }

        public Etudiant() : base()
        {
            filiere = "";
            notes = new float[5]; // Fixé à 5 notes par défaut
        }

        public Etudiant(int numero, string nom, string prenom) : base(numero, nom, prenom)
        {
            filiere = "";
            notes = new float[5]; // Fixé à 5 notes
        }

        public float CalculMoy()
        {
            if (notes == null || notes.Length == 0)
                return 0;

            float somme = 0;
            foreach (float n in notes)
                somme += n;

            return somme / notes.Length;
        }

        public override string ToString()
        {
            return base.ToString() + $", Filière: {Filiere}, Moyenne: {CalculMoy():0.00}";
        }
    }

    class Filiere
    {
        private string nomFil;
        private List<Etudiant> listeEtudiants;

        public string NomFil { get => nomFil; set => nomFil = value; }
        public List<Etudiant> ListeEtudiants => listeEtudiants;

        public Filiere()
        {
            nomFil = "";
            listeEtudiants = new List<Etudiant>();
        }

        public int GetNbrEtudiants() => listeEtudiants.Count;

        public void AddEtudiant(Etudiant e)
        {
            e.Filiere = NomFil;
            listeEtudiants.Add(e);
        }

        public Etudiant Chercher(string nom, string prenom)
        {
            foreach (Etudiant e in listeEtudiants)
            {
                if (e.Nom.Equals(nom, StringComparison.OrdinalIgnoreCase) &&
                    e.Prenom.Equals(prenom, StringComparison.OrdinalIgnoreCase))
                {
                    return e;
                }
            }
            return null;
        }

        public bool DeleteEtudiant(string nom, string prenom)
        {
            Etudiant etu = Chercher(nom, prenom);
            if (etu != null)
            {
                listeEtudiants.Remove(etu); // corrigé : ListeEtudiants → listeEtudiants
                return true;
            }
            return false;
        }

        public void AfficherListeEtudiants()
        {
            Console.WriteLine($"\n=== Filière : {NomFil} ({GetNbrEtudiants()} étudiant(s)) ===");
            foreach (Etudiant e in listeEtudiants)
            {
                Console.WriteLine(e);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            Filiere info = new Filiere() { NomFil = "Informatique" };
            Filiere math = new Filiere() { NomFil = "Mathématiques" };

            Etudiant e1 = new Etudiant(1, "Dupont", "Jean");
            Etudiant e2 = new Etudiant(2, "Durand", "Sophie");
            Etudiant e3 = new Etudiant(3, "Benali", "Youssef");
            Etudiant e4 = new Etudiant(4, "Nguyen", "Thi");
            Etudiant e5 = new Etudiant(5, "Diallo", "Aminata");

            Etudiant[] etudiants = { e1, e2, e3, e4, e5 };

            foreach (Etudiant e in etudiants)
            {
                for (int i = 0; i < e.Notes.Length; i++)
                    e.Notes[i] = rnd.Next(1, 21); // Next(1,21) pour inclure 20

                Console.WriteLine($"La moyenne de {e.Nom} {e.Prenom} est : {e.CalculMoy():0.00}");
            }

            info.AddEtudiant(e1);
            info.AddEtudiant(e3);
            info.AddEtudiant(e4);

            math.AddEtudiant(e2);
            math.AddEtudiant(e5);

            info.AfficherListeEtudiants();
            math.AfficherListeEtudiants();

            Console.WriteLine("\nTest de recherche");
            var etuCherche = info.Chercher("Benali", "Youssef");
            Console.WriteLine(etuCherche != null ? $"Étudiant trouvé : {etuCherche}" : "Étudiant introuvable.");

            Console.WriteLine("\nSuppression d'un étudiant");
            bool supprime = info.DeleteEtudiant("Nguyen", "Thi");
            Console.WriteLine(supprime ? "Étudiant supprimé avec succès." : "Échec de la suppression.");

            info.AfficherListeEtudiants();

            Console.WriteLine("Appuyez sur une touche pour quitter");
            Console.ReadKey();
        }
    }
}
