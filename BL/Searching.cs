using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public class Searching
    {
        public List<ProgLang> ListProgLangs { get; set; }
        public List<SearchEngine> ListEngines { get; set; }
        public bool SearchOk { get; set; }

        public List<Search> ListSearchs { get; set; }
        public ProgLang TotalWinner { get; set; }

        public string Message { get; set; }

        public Searching()
        {
            ListEngines = new List<SearchEngine>();
            ListProgLangs = new List<ProgLang>(); 
            ListSearchs = new List<Search>();
        }

        public Searching(List<string> ListaElms)
        {
            ListEngines = new List<SearchEngine>(); 

            SearchEngine GE = new GoogleEngine("Google"); // using Polymorphism
            ListEngines.Add(GE);

            SearchEngine YE = new YahooEngine("Yahoo"); // using Polymorphism
            ListEngines.Add(YE);

            ListSearchs = new List<Search>(); 

            ListProgLangs = LisStringToLisProgLang(ListaElms);
            SearchOk = bSearchNumElmsOk();
            if (SearchOk)
            {
                try {
                    //BuildSearchs
                    foreach (ProgLang oPr in ListProgLangs)
                    {
                        Search oSearch = new Search(GE, oPr, 0);
                        oSearch.NumResults = GE.GetResults(oPr.NomLang);    
                        ListSearchs.Add(oSearch);
                    }                  
                    foreach (ProgLang oPr in ListProgLangs)
                    {
                        Search oSearch = new Search(YE, oPr, 0);
                        oSearch.NumResults = YE.GetResults(oPr.NomLang);   
                        ListSearchs.Add(oSearch);
                    }
                    // Doing calculations
                    Calc();
                    // Showing results
                    Message = ShowAllResults();
                }
                catch
                {
                    SearchOk = false;
                    Message = "Error in performing search in Search Engine";
                }
                
            }
            else
            {
                Message = "In order to perform a comparison, must be at least 2 items to be compared";
            }
        }

        string ShowAllResults()
        {
            string r = "";
            foreach (ProgLang oPL in ListProgLangs)
            {
                List<Search> L = ListSearchs.Where(x => x.Lang.NomLang== oPL.NomLang).ToList();
                string s = "";
                foreach (Search oSea in L)
                {
                    s = s + " " + oSea.Engine.NomSearch + ": " + oSea.NumResults.ToString();
                }
                r = r + oPL.NomLang + ": " + s + " * Tot. Res. of prog. lang.: " + oPL.TotResults +  Environment.NewLine;
            }
            string w = "";
            foreach (SearchEngine oSeEng in ListEngines)
            {
                w = w + "\n" + oSeEng.NomSearch + " Winner: "  + oSeEng.Winner.NomLang +  Environment.NewLine;  
            }
            return r + w + "\n" + "Total Winner: " + this.TotalWinner.NomLang;
        }


        List<ProgLang> LisStringToLisProgLang(List<string> LS)
        {
            List<ProgLang> LPL = new List<ProgLang>();
            foreach (string s in LS)
            {
                ProgLang PL = new ProgLang(s);
                LPL.Add(PL); 
            }
            return LPL;    
        }

        public void SetLisSearchs()
        {
            ListSearchs = new List<Search>();
            foreach (SearchEngine SE in ListEngines)
            {
                foreach (ProgLang PL in ListProgLangs)
                {
                    Search Sea = new Search(SE, PL, 0);
                }
            }
        }

        public void Calc()
        {
            SetWinnersOfEachEngine();
            SetTotResOfEachProgLang();
            SetTotalWinner();
        }

        public void SetWinnersOfEachEngine()
        {
            foreach (SearchEngine o in ListEngines)
            {
                o.Winner = ProgLangWinnerOfEngine(o); 
            }
        }

        public void SetTotResOfEachProgLang()
        {
            foreach (ProgLang o in ListProgLangs)
            {
                o.TotResults = TotResultsOfProgLang(o); 
            }
        }

        public void SetTotalWinner()
        {
            int nMax = 0;
            ProgLang AuxWinner = new ProgLang(); 
            foreach (ProgLang o in ListProgLangs)
            {
                if (o.TotResults > nMax)
                {
                    AuxWinner = o;
                    nMax = AuxWinner.TotResults;   
                }
            }
            TotalWinner = AuxWinner; 
        }

        ProgLang ProgLangWinnerOfEngine(SearchEngine oEng)
        {
            ProgLang PrgLng = new ProgLang();
            List<Search> L = ListSearchs.Where(x => x.Engine.NomSearch == oEng.NomSearch).ToList();
            int nMax = 0;
            ProgLang PrgAux = new ProgLang(); 
            foreach (Search o in L)
            {
                if (o.NumResults > nMax)
                {
                    PrgAux = new ProgLang(o.Lang.NomLang);
                    nMax = o.NumResults; 
                }             
            }
            PrgLng = PrgAux; 
            return PrgLng;
        }

        int TotResultsOfProgLang(ProgLang oPr)
        {
            int Sum = 0;
            List<Search> L = ListSearchs.Where(x => x.Lang.NomLang == oPr.NomLang).ToList();
            foreach (Search o in L)
            {
                Sum = Sum + o.NumResults; 
            }
            return Sum;
        }

        bool bSearchNumElmsOk()
        {
            bool bLangOK = ((2 <= ListProgLangs.Count)); // PDT for app makes sense ther must be agt least 2 langs to COMPARE
            bool bEngineOK = ((2 <= ListEngines.Count)); 
            return bLangOK && bEngineOK;
        }

    
    }
}
