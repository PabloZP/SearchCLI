using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Search
    {
        public SearchEngine Engine { get; set; }
        public ProgLang Lang { get; set; }
        public int NumResults { get; set; }

        public Search()
        { }

        public Search(SearchEngine engine, ProgLang lang)
        {
            Engine = engine;
            Lang = lang;
        }

        public Search(SearchEngine engine, ProgLang lang, int numResults)
        {
            Engine = engine;
            Lang = lang;
            NumResults = numResults;
        }
    }
}
