using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carmen
{
    public partial class calc : Form
    {
        public calc()
        {
            InitializeComponent();
        }
        private string ans;
        private void buttonEqual_Click(object sender, EventArgs e)
        {
            Calcular();
            this.Result.Text = this.textBox1.Text;
            this.ans = this.textBox1.Text;
            this.textBox1.Text = string.Empty;
            MessageBox.Show("HI");
        }

        
        #region Numeros
        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "9";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "0";
        }
        #endregion

        #region Operaciones
        private void buttonDot_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += ".";
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            int l = this.textBox1.Text.Length;
            if (l > 0)
            {
                String texto = this.textBox1.Text;
                texto = texto.Substring(0, texto.Count() - 1);
                this.textBox1.Text = texto;
            }
            else
            {
                FocusInputText();
            }
            
        }

        private void buttonAc_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = string.Empty;
            FocusInputText();
        }

        private void buttonMul_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "*";
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "/";
        }

        private void buttonSum_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "+";
        }

        private void buttonMen_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "-";
        }

        private void buttonAns_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "Ans";
        }
        #endregion

        private void FocusInputText()
        {
            this.textBox1.Focus();
        }
        private void Calcular()
        {

        }
    }
}
