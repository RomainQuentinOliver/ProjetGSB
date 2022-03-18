using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothèque
{
    public class Secteur
    {
        private int codeSecteur;
        private string libelleSecteur; 

        public Secteur(int unSecteur, string unLibelle)
        {
            CodeSecteur = unSecteur;
            LibelleSecteur = unLibelle;
        }

        public int CodeSecteur { get => codeSecteur; set => codeSecteur = value; }
        public string LibelleSecteur { get => libelleSecteur; set => libelleSecteur = value; }
    }
}
