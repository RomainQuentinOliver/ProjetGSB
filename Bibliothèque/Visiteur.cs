using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothèque
{
    public class Visiteur
    {
        private int matricule;
        private string nomVis;
        private string prenomVis;
        private string adresseVis;
        private int codePostal;
        private string ville;
        private string dateEmbaucheVis;
        private Secteur codeSecteurVis;
        private Labo codeLaboVis; 

        public Visiteur(int unMatricule, string unNom, string unPrenom, string uneAdresse, int unCodePostal, string uneVille, string uneDate, Secteur unCodeSecteur, Labo unCodeLabo)
        {
            Matricule = unMatricule;
            NomVis = unNom;
            PrenomVis = unPrenom;
            AdresseVis = uneAdresse;
            CodePostal = unCodePostal;
            Ville = uneVille;
            DateEmbaucheVis = uneDate;
            CodeSecteurVis = unCodeSecteur;
            CodeLaboVis = unCodeLabo; 
        }

        public int Matricule { get => matricule; set => matricule = value; }
        public string NomVis { get => nomVis; set => nomVis = value; }
        public string PrenomVis { get => prenomVis; set => prenomVis = value; }
        public string AdresseVis { get => adresseVis; set => adresseVis = value; }
        public int CodePostal { get => codePostal; set => codePostal = value; }
        public string Ville { get => ville; set => ville = value; }
        public string DateEmbaucheVis { get => dateEmbaucheVis; set => dateEmbaucheVis = value; }
        public Secteur CodeSecteurVis { get => codeSecteurVis; set => codeSecteurVis = value; }
        public Labo CodeLaboVis { get => codeLaboVis; set => codeLaboVis = value; }
    }
}
