using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothèque
{
    public class Dosage
    {
        private int codeDose;
        private int quantiteDose;
        private string uniteDose; 

        public Dosage(int unCode, int uneQuantite, string uneUnite)
        {
            CodeDose = unCode;
            QuantiteDose = uneQuantite;
            UniteDose = uneUnite; 
        }

        public int CodeDose { get => codeDose; set => codeDose = value; }
        public int QuantiteDose { get => quantiteDose; set => quantiteDose = value; }
        public string UniteDose { get => uniteDose; set => uniteDose = value; }
    }
}
