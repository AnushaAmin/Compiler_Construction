using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _032_MidLabQ2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Parse_Click(object sender, EventArgs e)
        {
            string input = textBox.Text;
            LL1Parser parser = new LL1Parser(input);
            parser.Parse();
            if (parser.currentPosition == input.Length)
            {
                output.Text = "The input is valid.";
            }
            else
            {
                output.Text = "The input is invalid.";
            }
        }
    }
}
