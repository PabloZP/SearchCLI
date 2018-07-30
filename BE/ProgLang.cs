using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ProgLang
    {
        public string NomLang { get; set; }
        public int TotResults { get; set; }

        public ProgLang()
        {  }

        public ProgLang(string Nom)
        {
            NomLang = Nom;
        }

        public ProgLang(string Nom, int nTotResults)
        {
            NomLang = Nom;
            TotResults = nTotResults; 
        }

    }
}
