using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothèque
{
    public class Famille
    {
        private int codeFamille;
        private string libelleFamille;

        public Famille(int unCode, string unLibelle)
        {
            CodeFamille = unCode;
            LibelleFamille = unLibelle;
        }

        public int CodeFamille { get => codeFamille; set => codeFamille = value; }
        public string LibelleFamille { get => libelleFamille; set => libelleFamille = value; }
    }
}
