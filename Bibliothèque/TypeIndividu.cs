using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothèque
{
    public class TypeIndividu
    {
        private int codeTypeInd;
        private string libelleTypeInd;

        public TypeIndividu(int unCode, string unLibelle)
        {
            CodeTypeInd = unCode;
            LibelleTypeInd = unLibelle;
        }

        public int CodeTypeInd { get => codeTypeInd; set => codeTypeInd = value; }
        public string LibelleTypeInd { get => libelleTypeInd; set => libelleTypeInd = value; }
    }
}
