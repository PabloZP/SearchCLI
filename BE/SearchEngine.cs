using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class SearchEngine
    {
        public string NomSearch { get; set; }
        public ProgLang Winner { get; set; }

        public SearchEngine()
        {  }

        public SearchEngine(string Nom)
        {
            NomSearch = Nom; 
        }

        Random rnd = new Random();
        static int iaux = 22;
        static int faux = 101;
        public virtual int GetResults(string sPrgLang)
        {
            //Mocking results
            int x = 0;
            x = rnd.Next(iaux, faux);
            iaux++;
            faux++; 
            return x; // 
        }


    }
}
