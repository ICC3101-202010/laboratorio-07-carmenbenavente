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
        private void buttonEqual_Click(object sender, EventArgs e)
        {
            Calcular();
            //this.Result.Text = this.textBox1.Text;
            this.textBox1.Clear();
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
            this.textBox1.Clear();
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
            this.textBox1.Text += this.Result.Text;
        }
        #endregion
        // Usé como base el código que utiliza Angel Six (https://www.youtube.com/watch?v=oOAeCOQ8yCs) 
        private void FocusInputText()
        {
            this.textBox1.Focus();
        }
        private void Calcular()
        {
            this.Result.Text = ParseOperation();
        }
        private string ParseOperation()
        {
            try
            {
                string input = this.textBox1.Text;
                Operation operation = new Operation();
                bool leftside = true;
                for (int i = 0; i < input.Length; i++)
                {
                    if ("0123456789.".Any(c => input[i] == c))
                    {
                        if (leftside)
                            operation.LeftSide = AddNumberPart(operation.LeftSide, input[i]);
                        else
                            operation.RightSide = AddNumberPart(operation.RightSide, input[i]);
                    }
                    else if ("+-*/".Any(c => input[i] == c))
                    {
                        if (!leftside)
                        {
                            OperationType operationType = GetOperationType(input[i]);
                        }
                        else
                        {
                            OperationType operationType = GetOperationType(input[i]);
                            if (operation.LeftSide.Length == 0)
                            {
                                if (operationType != OperationType.Minus)
                                    throw new InvalidOperationException("Syntax ERROR");
                                operation.LeftSide += input[i];
                            }
                            else
                            {
                                operation.OperationType = operationType;
                                leftside = false;
                            }
                        }
                    }
                }
                return CalculateOperation(operation);
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        private string AddNumberPart(string currentNumber, char currentChar)
        {
            if (currentChar == '.' && currentNumber.Contains("."))
                throw new InvalidOperationException("Syntax ERROR");
            
            return currentNumber + currentChar;
        }
        private OperationType GetOperationType(char character)
        {
            switch (character)
            {
                case '+':
                    return OperationType.Add;
                case '-':
                    return OperationType.Minus;
                case '*':
                    return OperationType.Multiply;
                case '/':
                    return OperationType.Divide;
                default:
                    throw new InvalidOperationException("Syntax ERROR");
            }
        }
        private string CalculateOperation(Operation operation)
        {
            double left = 0;
            double right = 0;
            if (string.IsNullOrEmpty(operation.LeftSide) || !double.TryParse(operation.LeftSide, out left))
                throw new InvalidOperationException("Syntax ERROR");

            if (string.IsNullOrEmpty(operation.RightSide) || !double.TryParse(operation.RightSide, out right))
                throw new InvalidOperationException("Syntax ERROR");
            if (operation.RightSide == "0" && operation.OperationType == OperationType.Divide)
                throw new InvalidOperationException("Math ERROR");

            try
            {
                switch (operation.OperationType)
                {
                    case OperationType.Add:
                        return (left + right).ToString();
                    case OperationType.Minus:
                        return (left - right).ToString();
                    case OperationType.Multiply:
                        return (left * right).ToString();
                    case OperationType.Divide:
                        return (left / right).ToString();
                    default:
                        throw new InvalidOperationException("Syntax ERROR");
                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Math ERROR");
            }

        }
    }
}
