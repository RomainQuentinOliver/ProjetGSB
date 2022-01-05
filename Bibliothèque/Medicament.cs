using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothèque
{
    public class Medicament
    {
        private int depotLegalMed;
        private string nomCommercialMed;
        private Famille codeFamille;
        private string compositionMed;
        private string effetsMed;
        private string contreIndicMed;
        private double prixEchantillonMed;
        private List<Medicament> lesPerturbateurs;

        public Medicament(int unDepotLegal, string unNomCommercial, Famille unCode, string uneComposition, string desEffets, string desContreIndic, double unPrix)
        {
            DepotLegalMed = unDepotLegal;
            NomCommercialMed = unNomCommercial;
            CodeFamille = unCode;
            CompositionMed = uneComposition;
            EffetsMed = desEffets;
            ContreIndicMed = desContreIndic;
            PrixEchantillonMed = unPrix;
            LesPerturbateurs = new List<Medicament>();
        }

        public int DepotLegalMed { get => depotLegalMed; set => depotLegalMed = value; }
        public string NomCommercialMed { get => nomCommercialMed; set => nomCommercialMed = value; }
        public string CompositionMed { get => compositionMed; set => compositionMed = value; }
        public string EffetsMed { get => effetsMed; set => effetsMed = value; }
        public string ContreIndicMed { get => contreIndicMed; set => contreIndicMed = value; }
        public double PrixEchantillonMed { get => prixEchantillonMed; set => prixEchantillonMed = value; }
        public Famille CodeFamille { get => codeFamille; set => codeFamille = value; }
        internal List<Medicament> LesPerturbateurs { get => lesPerturbateurs; set => lesPerturbateurs = value; }
    }
}
