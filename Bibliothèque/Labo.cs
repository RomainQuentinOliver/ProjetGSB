using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothèque
{
    public class Labo
    {
        private int codeLab;
        private string nomLab;
        private string chefVente; 

        public Labo(int unCode, string unNom, string unChefVente)
        {
            CodeLab = unCode;
            NomLab = unNom;
            ChefVente = unChefVente; 
        }

        public int CodeLab { get => codeLab; set => codeLab = value; }
        public string NomLab { get => nomLab; set => nomLab = value; }
        public string ChefVente { get => chefVente; set => chefVente = value; }
    }
}
