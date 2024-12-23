using System;
using System.Windows.Forms;
using System.Data;

namespace Calculator
{
    public partial class frm1 : Form
    {
        private double result = 0;
        private string operation = "";
        private bool isOperationPerformed = false;
        private string expression = "";

        public frm1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            // Handle number and decimal point inputs
            if (char.IsDigit(button.Text[0]) || button.Text == ".")
            {
                if (isOperationPerformed || lbl1.Text == "0")
                {
                    lbl1.Text = "";
                    isOperationPerformed = false;
                }

                if (button.Text == "." && lbl1.Text.Contains("."))
                    return;

                lbl1.Text += button.Text;
            }

            // Handle operators
            else if (button.Text == "+" || button.Text == "-" || button.Text == "x" || button.Text == "/")
            {
                if (!isOperationPerformed)
                {
                    if (!string.IsNullOrEmpty(expression))
                    {
                        expression += lbl1.Text;
                    }
                    else
                    {
                        expression = lbl1.Text;
                    }
                    expression += " " + button.Text + " ";
                }

                operation = button.Text == "x" ? "*" : button.Text;

                lbl2.Text = expression;
                lbl1.Text = "0";
                isOperationPerformed = true;
            }

            // Handle equals button
            else if (button.Text == "=")
            {
                expression += lbl1.Text;
                lbl2.Text = expression;
                lbl1.Text = Compute(expression).ToString();
                expression = "";
                operation = "";
            }

            // Handle clear button
            else if (button.Text == "C")
            {
                lbl1.Text = "0";
                lbl2.Text = "";
                result = 0;
                operation = "";
                expression = "";
            }

            // Handle delete button
            else if (button.Text == "DEL")
            {
                if (lbl1.Text.Length > 1)
                {
                    lbl1.Text = lbl1.Text.Substring(0, lbl1.Text.Length - 1);
                }
                else
                {
                    lbl1.Text = "0";
                }
            }
        }

        private double Compute(string expression)
        {
                expression = expression.Replace("x", "*"); // Replace 'x' with '*' for multiplication
                var table = new DataTable();
                object result = table.Compute(expression, "");
                return Convert.ToDouble(result);
        }

        private void lbl1_Click(object sender, EventArgs e)
        {
        }
    }
}
