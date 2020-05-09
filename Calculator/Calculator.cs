using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Threading;

namespace Calculator
{
    public partial class Calculator : Form
    {
        char decsep;
        public Calculator()
        {
            InitializeComponent();
            InitializeCalculator();
        }

        private void InitializeCalculator()
        {
            decsep = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            this.BackColor = Color.FromArgb(40, 40, 40);

            string buttonName = null;
            Button button = null;

            for (int i = 0; i < 10; i++)
            {
                buttonName = "button" + i;
                button = (Button)this.Controls[buttonName];
                button.Text = i.ToString();
            }

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (Display.Text == "0")
            {
                Display.Text = button.Text;
            }
            else
            {
                Display.Text += button.Text;
            }
        }

        private void buttondot_Click(object sender, EventArgs e)
        {
            if (!Display.Text.Contains(decsep))
            {
                if (Display.Text == string.Empty)
                {
                    Display.Text += "0" + decsep;
                }
                else
                {
                    Display.Text += decsep;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string s = Display.Text;
            if (s.Length > 1) // if the lenght is more then one thent it reads the leanght takes one off and sets the display as that
            {
                s = s.Substring(0, s.Length - 1); // reads the lenght of the string from the display from 0 and subtracts one char
            }
            else // if its one then just delete the text
            {
                s = string.Empty;
            }

            Display.Text = s;
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            try
            {
                double number = Convert.ToDouble(Display.Text);   // converts the display text to numbers then makes it negative/positive and converts them back to strings 
                number *= -1;
                Display.Text = number.ToString("F99").TrimEnd('0');
            }
            catch
            {

            }
            // try and catch is: if code that u try crashes then go to catch
        }
    }
}
