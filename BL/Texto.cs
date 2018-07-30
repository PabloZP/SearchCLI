using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BE;

namespace BL
{
    public class Texto
    {
        public string TxtToBeParsed { get; set; }
        public List<string> Words { get; set; }
        public string Message { get; set; }
        public bool ParsedOK { get; set; }

        public Texto()
        {
            Words = new List<string>();
        }

        public Texto(string Txt)
        {
            Words = new List<string>();
            TxtToBeParsed = Txt; 
        }

        public void ParsingText()
        {
            TxtToBeParsed = TxtToBeParsed.Trim(); 
            TxtToBeParsed = StringWithoutAdditionalSpaces(TxtToBeParsed);
            if (TxtToBeParsed.Length > 0)
            {
                ParsedOK = bTextOk(TxtToBeParsed.Trim());
                if (ParsedOK)
                {
                    if (HasSpaceBetweenQuotes(Words))
                    {
                        ParsedOK = false;
                        Message = "One or more elements Has One Space Between Quotes";
                    }
                }
            }
            else
            {
                Message = "You entered Empty String";
                ParsedOK = false; 
            }
        }

        bool bTextOk(string s)
        {
            bool b = false;
            int NumQuo = NumQuotes(s);
            if (NumQuo == 0)
            {
                b = true;
                Message = "Parsed OK -> No Quotes";
                // 1.A. OK Numero de Comillas = 0  --> caso facil, se usa Split
                Words = ListWordsNoQuotes(s); 
            }
            else
            {
                if ((NumQuo % 2) == 0)
                {
                    // NUM COMILLAS PAR:
                    if (HasQuotesContiguas(s))
                    {
                        Message = "ERR -> Double quotes can not be together";
                    }
                    else
                    {
                        if (StringWithQuotesWithStickLetter(s))
                        {
                            Message = "ERR -> Character together to double quotes";
                        }
                        else
                        {
                            b = true;
                            Message = "Parsed OK -> With Double Quotes";
                            // 1.B. OK Numero de Comillas > 0 y Par y OK 
                            int contgral = 0;
                            List<string> L = new List<string>();    
                            ListWordsQuotes(s, contgral, ref L);
                            Words = L;
                        }
                    }

                }
                else
                {
                    // 1.E.ERR Numero de Comillas > 0 e Impar  --> ERROR
                    Message = "ERR -> Odd number of double quotes";
                }
            }
            return b;
        }

        // 0. Trim
        // 1. check 
        // 1.A. Parsed OK -> Without quotes
        // 1.B. Parsed OK -> With quotes y OK  --> ANALISIS
        // 1.C. ERR--> Wiyth even number of  quotes but with character together with quotes
        //  .... Example  "C Sharp"Java 
        //  .... Example   Java"C Sharp" 
        // 1.D. ERR -> Even number of quotes but contiguosu quotes -->  ERROR ... Exm  "C Sharp""Ruby Rails"
        // 1.E. ERR -> Odd number of quotes
        // OJO: Before Analizing all extra contiguous spaces are reduced to one space
        //    EJM:   "A  B" CD    EF   --->   "A B" CD EF

        public bool StringWithQuotesWithStickLetter(string s)
        // detecta err 1.C
        // Rule1: After closing quote (Even) must be space (unless closing quote is the last char)
        // Rule2: Before opening quote (Odd) must be space (unless opening quote is the first char)
        // PreCondition: String enters with even number of quotes (WELL FORMED)
        {
            bool b = false; 
            //  1. get list of 1.A if it0s OP OR CL and its **abs pos* in the string
            //  2. lopp list and check rules 1 and 2 foreach elm
            string OpenOrClose = "OPE"; // OPE or CLO
            for (int i = 0; i <= s.Length - 1; i++)
            {
                if (s.Substring(i, 1) == "\"" && OpenOrClose == "OPE")
                {

                    if ((i > 0) && (s.Substring(i - 1, 1) != " "))
                    {
                        b = true; 
                    }
                    OpenOrClose = "CLO";
                }
                else
                {
                    if (s.Substring(i, 1) == "\"" && OpenOrClose == "CLO")
                    {

                        if ((i < (s.Length - 1)) && (s.Substring(i + 1, 1) != " "))
                        {
                            b = true; 
                        }
                        OpenOrClose = "OPE";
                    }
                }
            }
            return b;
        }

        public bool HasQuotesContiguas(string s) 
        {
            bool b = false;
            if (s.Contains("\"\"") || s.Contains("\"\"\"") || s.Contains("\"\"\"\""))
            {
                b = true; 
            }
            return b;
        }

        public bool HasSpaceBetweenQuotes(List<string> L)  // If it has a " "
        { 
            // this apply to a well formed list         
            bool b = false;
            foreach (string s in L)
            {
                if (s.Contains("\" \""))
                {
                    b = true;
                }
            }
            return b;
        }

        // 1.A OK->  No Quotes  
        List<string> ListWordsNoQuotes(string s)
        {
            List<string> L = new List<string>();
            string[] Arr = s.Split(' ');
            L = Arr.ToList(); 
            return L;
        }

        // 1.B. OK-> With Quotes  --> ANALISIS
        public void ListWordsQuotes(string s, int contgral, ref List<string> L)
        {
            string sAux = "";
            int PosNext = 0;
            string sFirst = s.Substring(0, 1);

            if (sFirst == "\"")
            {
                int i = 0 + 1; // from next one, doesnt include quote
                contgral = i;
                while (s.Substring(i, 1) != "\"")
                {
                    sAux = sAux + s.Substring(i, 1);
                    i++;
                    contgral++; 
                }
                PosNext = i + 2;
                sAux = "\"" + sAux + "\"";
            }
            else  // character  not quote
            {
                int i = 0;  // CurPos
                contgral = i;
                while (s.Substring(i, 1) != " ")
                {
                    sAux = sAux + s.Substring(i, 1);
                    i++;
                    contgral++;
                    if (i == s.Length)
                    {
                        break; 
                    }
                }
                PosNext = i + 1;
            }
            L.Add(sAux);

            if (contgral <= s.Length -1 && PosNext < s.Length)
            {
                string s2 = s.Substring(PosNext);
                ListWordsQuotes(s2, contgral, ref L);
            }
        }



        int NumQuotes(string s)
        {
            int n = 0;
            for (int i = 0; i <= s.Length - 1; i++)
            {
                if (s.Substring(i, 1) == "\"")
                {
                    n++;
                }
            }
            return n;
        }

        public string StringWithoutAdditionalSpaces(string s)
        {
            string sRes = "";
            Regex trimmer = new Regex(@"\s\s+");
            sRes = trimmer.Replace(s, " ");
            return sRes;
        }


    }
}
