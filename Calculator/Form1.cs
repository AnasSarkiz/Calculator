using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class frm1 : Form
    {
        private double result = 0;
        private string operation = "";
        private bool isOperationPerformed = false;

        public frm1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Text == "0" || button.Text == "1" || button.Text == "2" ||
                button.Text == "3" || button.Text == "4" || button.Text == "5" ||
                button.Text == "6" || button.Text == "7" || button.Text == "8" ||
                button.Text == "9" || button.Text == ".")
            {
                if ((lbl1.Text == "0") || isOperationPerformed)
                    lbl1.Text = "";

                if (operation == "" && isOperationPerformed)
                {
                    lbl1.Text = "";
                    lbl2.Text = "";
                }
                if(button.Text == "." && lbl1.Text.Contains(".")) 
                { 
                
                }else if (button.Text == "." && !lbl1.Text.Contains(".") && lbl1.Text == "")
                {
                    isOperationPerformed = false;
                    lbl1.Text += "0"+button.Text;
                }
                else 
                  {
                    isOperationPerformed = false;
                    lbl1.Text += button.Text;
                  }

                
            }
       
            else if (button.Text == "+" || button.Text == "-" || button.Text == "x" || button.Text == "/")
            {
                if (button.Text == "x")
                    operation = "*";
                else
                    operation = button.Text;

                result = Double.Parse(lbl1.Text);
                lbl2.Text = lbl1.Text + button.Text;
                isOperationPerformed = true;
            }
       
            else if (button.Text == "=")
            {
                isOperationPerformed = true;
        
                lbl2.Text += lbl1.Text;

                switch (operation)
                {
                    case "+":
                        lbl1.Text = (result + Double.Parse(lbl1.Text)).ToString();
                        break;
                    case "-":
                        lbl1.Text = (result - Double.Parse(lbl1.Text)).ToString();
                        break;
                    case "*":
                        lbl1.Text = (result * Double.Parse(lbl1.Text)).ToString();
                        break;
                    case "/":
                        lbl1.Text = (result / Double.Parse(lbl1.Text)).ToString();
                        break;
                }
                result = Double.Parse(lbl1.Text);
                operation = "";
            }
          
            else if (button.Text == "C")
            {
                lbl1.Text = "0";
                lbl2.Text = "";
                result = 0;
                operation = "";
            }
      
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
    }
}
