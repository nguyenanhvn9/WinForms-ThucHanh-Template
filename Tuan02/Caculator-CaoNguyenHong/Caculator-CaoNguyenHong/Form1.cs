using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caculator_CaoNguyenHong
{
    public partial class frmCalculator : Form
    {
        private double _result = 0;
        private string _operation = "";
        private bool _isOperationPerformed = false;
        private double _memory = 0;

        public frmCalculator()
        {
            InitializeComponent();
            
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text == "0" || _isOperationPerformed)
                lblDisplay.Text = "";
            _isOperationPerformed = false;
            Button btn = sender as Button;
            lblDisplay.Text += btn.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _operation = "+";
            _result = double.Parse(lblDisplay.Text);
            _isOperationPerformed = true;
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            _operation = "-";
            _result = double.Parse(lblDisplay.Text);
            _isOperationPerformed = true;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            _operation = "*";
            _result = double.Parse(lblDisplay.Text);
            _isOperationPerformed = true;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            _operation = "/";
            _result = double.Parse(lblDisplay.Text);
            _isOperationPerformed = true;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            double secondNumber = double.Parse(lblDisplay.Text);
            switch (_operation)
            {
                case "+":
                    lblDisplay.Text = (_result + secondNumber).ToString();
                    break;
                case "-":
                    lblDisplay.Text = (_result - secondNumber).ToString();
                    break;
                case "*":
                    lblDisplay.Text = (_result * secondNumber).ToString();
                    break;
                case "/":
                    if (secondNumber != 0)
                        lblDisplay.Text = (_result / secondNumber).ToString();
                    else
                        lblDisplay.Text = "Error";
                    break;
            }
            _isOperationPerformed = true;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
            _result = 0;
            _operation = "";
            _isOperationPerformed = false;
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text.Length > 1)
                lblDisplay.Text = lblDisplay.Text.Substring(0, lblDisplay.Text.Length - 1);
            else
                lblDisplay.Text = "0";
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = "0";
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            double value = double.Parse(lblDisplay.Text);
            lblDisplay.Text = (value / 100).ToString();
            _isOperationPerformed = true;
        }

        private void btnReciprocal_Click(object sender, EventArgs e)
        {
            double value = double.Parse(lblDisplay.Text);
            if (value != 0)
                lblDisplay.Text = (1 / value).ToString();
            else
                lblDisplay.Text = "Error";
            _isOperationPerformed = true;
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            double value = double.Parse(lblDisplay.Text);
            lblDisplay.Text = (value * value).ToString();
            _isOperationPerformed = true;
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            double value = double.Parse(lblDisplay.Text);
            if (value >= 0)
                lblDisplay.Text = Math.Sqrt(value).ToString();
            else
                lblDisplay.Text = "Error";
            _isOperationPerformed = true;
        }

        private void btnPlusMinus_Click(object sender, EventArgs e)
        {
            double value = double.Parse(lblDisplay.Text);
            lblDisplay.Text = (-value).ToString();
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            if (!_isOperationPerformed && !lblDisplay.Text.Contains(","))
                lblDisplay.Text += ",";
            else if (_isOperationPerformed)
                lblDisplay.Text = "0,";
            _isOperationPerformed = false;
        }
    }
}
