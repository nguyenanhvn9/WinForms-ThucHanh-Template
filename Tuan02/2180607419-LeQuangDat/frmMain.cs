using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2180607419_LeQuangDat
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private double firstOperand = 0;
        private string currentOperator = "";
        private bool isNewNumber = true;

        private void btnNumber_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                if (isNewNumber)
                {
                    txtDisplay.Text = btn.Text;
                    isNewNumber = false;
                }
                else
                {
                    txtDisplay.Text += btn.Text;
                }
            }
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                if (btn.Text == "=")
                {
                    CalculateResult();
                    currentOperator = "";
                }
                else
                {
                    firstOperand = double.Parse(txtDisplay.Text);
                    currentOperator = btn.Text;
                    isNewNumber = true;
                }
            }
        }

        private void CalculateResult()
        {
            try
            {
                double secondOperand = double.Parse(txtDisplay.Text);
                double result = 0;

                switch (currentOperator)
                {
                    case "+":
                        result = firstOperand + secondOperand;
                        break;
                    case "-":
                        result = firstOperand - secondOperand;
                        break;
                    case "*":
                        result = firstOperand * secondOperand;
                        break;
                    case "/":
                        if (secondOperand == 0)
                            throw new DivideByZeroException();
                        result = firstOperand / secondOperand;
                        break;
                }

                txtDisplay.Text = result.ToString();
                isNewNumber = true;
            }
            catch (Exception)
            {
                txtDisplay.Text = "Error";
                isNewNumber = true;
            }
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            CalculateResult();
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            try
            {
                double number = double.Parse(txtDisplay.Text);
                double result = number * number;
                txtDisplay.Text = result.ToString();
                isNewNumber = true;
            }
            catch (Exception)
            {
                txtDisplay.Text = "Error";
                isNewNumber = true;
            }
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            isNewNumber = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            firstOperand = 0;
            currentOperator = "";
            isNewNumber = true;
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text != "0" && txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Length == 1 ?
                    "0" : txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            }
            if (txtDisplay.Text == "Error")
            {
                txtDisplay.Text = "0";
            }
            isNewNumber = false;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            try
            {
                double number = double.Parse(txtDisplay.Text);
                double result = number / 100;
                txtDisplay.Text = result.ToString();
                isNewNumber = true;
            }
            catch (Exception)
            {
                txtDisplay.Text = "Error";
                isNewNumber = true;
            }
        }

        private void btnsqrt_Click(object sender, EventArgs e)
        {
            try
            {
                double number = double.Parse(txtDisplay.Text);
                if (number < 0)
                {
                    txtDisplay.Text = "Error";
                    isNewNumber = true;
                    return;
                }
                double result = Math.Sqrt(number);
                txtDisplay.Text = result.ToString();
                isNewNumber = true;
            }
            catch (Exception)
            {
                txtDisplay.Text = "Error";
                isNewNumber = true;
            }
        }

        private void btnReciprocal_Click(object sender, EventArgs e)
        {
            try
            {
                double number = double.Parse(txtDisplay.Text);
                if (number == 0)
                {
                    txtDisplay.Text = "Error";
                    isNewNumber = true;
                    return;
                }
                double result = 1 / number;
                txtDisplay.Text = result.ToString();
                isNewNumber = true;
            }
            catch (Exception)
            {
                txtDisplay.Text = "Error";
                isNewNumber = true;
            }
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text == "Error")
            {
                txtDisplay.Text = "0";
                isNewNumber = true;
            }

            if (isNewNumber)
            {
                txtDisplay.Text = "0.";
                isNewNumber = false;
            }
            else if (!txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ".";
            }
        }

        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text == "Error")
            {
                txtDisplay.Text = "0";
                isNewNumber = true;
                return;
            }

            try
            {
                double number = double.Parse(txtDisplay.Text);
                number = -number;
                txtDisplay.Text = number.ToString();
            }
            catch (Exception)
            {
                txtDisplay.Text = "Error";
                isNewNumber = true;
            }
        }
    }
}
