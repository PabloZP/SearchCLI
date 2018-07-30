using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;

namespace ChallengeCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            string cadena = "";
            for (int i = 0; i <= args.Length - 1; i++)
            {
                string elm = args[i].Trim();
                Texto Tx = new Texto();
                elm = Tx.StringWithoutAdditionalSpaces(elm);
                if (elm.Contains(" "))
                {
                    elm = "\"" + elm + "\"";
                }
                cadena = cadena + " " + elm;
            }
            Texto C = new Texto(cadena);
            C.ParsingText();
            string sParseMssg = C.Message;
            string sSearchMsg = "";
            if (C.ParsedOK)
            {
                Searching SSS = new Searching(C.Words);
                sSearchMsg = Environment.NewLine + SSS.Message;
            }
            Console.WriteLine(sParseMssg + sSearchMsg);

            
        }
    }
}
