using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BL;

namespace Challenge
{
    public partial class Form1 : Form
    {
       
     
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cadena = txtCadena.Text.Trim();
            Texto C = new Texto(cadena);
            C.ParsingText();
            string sParseMssg = C.Message;
            string sSearchMsg = "";
            if (C.ParsedOK)
            {
                Searching SSS = new Searching(C.Words);
                sSearchMsg = Environment.NewLine + SSS.Message;
            }
            txtResul.Text = sParseMssg + sSearchMsg;      
        }


        


    }
}
