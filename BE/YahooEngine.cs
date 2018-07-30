using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class YahooEngine : SearchEngine 
    {

        public YahooEngine(string sName)
        {
            NomSearch = sName; 
        }

        Random rnd = new Random();
        static int iaux = 22;
        static int faux = 101;
        public override int GetResults(string sPrgLang)
        {
            //Mocking results
            int x = 0;
            x = rnd.Next(iaux, faux);
            iaux++;
            faux--;
            return x; 
        }
    }
}
