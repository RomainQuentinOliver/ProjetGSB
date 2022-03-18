using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothèque
{
    public class Region
    {
        private int codeReg;
        private Secteur codeSec;
        private string nomReg;

        public Region(int unCodeReg, Secteur unCodeSec, string unNomReg)
        {
            CodeReg = unCodeReg;
            CodeSec = unCodeSec;
            NomReg = unNomReg;
        }

        public int CodeReg { get => codeReg; set => codeReg = value; }
        public Secteur CodeSec { get => codeSec; set => codeSec = value; }
        public string NomReg { get => nomReg; set => nomReg = value; }
    }
}
