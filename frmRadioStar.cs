using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioStar
{
    public partial class frmRadioStar : Form
    {
        public frmRadioStar()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int left = 0;
            int right = 0;

            bool leftValid = int.TryParse(txtLeftOperand.Text, out left);
            bool rightValid = int.TryParse(txtRightOperand.Text, out right);

            string errors = "";

            // Check left operand
            if (string.IsNullOrWhiteSpace(txtLeftOperand.Text))
            {
                errors += "Left operand is blank.\n";
            }
            else if (!leftValid)
            {
                errors += "Left operand must be a whole number.\n";
            }

            // Check right operand
            if (string.IsNullOrWhiteSpace(txtRightOperand.Text))
            {
                errors += "Right operand is blank.\n";
            }
            else if (!rightValid)
            {
                errors += "Right operand must be a whole number.\n";
            }

            // Check division and modulus by zero
            if (rightValid && right == 0 &&
                (rdoDivision.Checked || rdoModulus.Checked))
            {
                errors += "Cannot divide or calculate modulus by zero.\n";
            }

            // Check negative modulus values
            if (rdoModulus.Checked &&
                ((leftValid && left < 0) || (rightValid && right < 0)))
            {
                errors += "Modulus cannot use negative numbers.\n";
            }

            // Display all errors
            if (errors != "")
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = errors;
                return;
            }

            // Perform calculation
            int answer = 0;
            string operation = "";

            if (rdoAddition.Checked)
            {
                answer = left + right;
                operation = "+";
            }
            else if (rdoSubtraction.Checked)
            {
                answer = left - right;
                operation = "-";
            }
            else if (rdoMultiplication.Checked)
            {
                answer = left * right;
                operation = "*";
            }
            else if (rdoDivision.Checked)
            {
                answer = left / right;
                operation = "/";
            }
            else if (rdoModulus.Checked)
            {
                answer = left % right;
                operation = "%";
            }

            // Display answer
            lblMessage.ForeColor = Color.DarkBlue;

            if (chkVerbose.Checked)
            {
                lblMessage.Text = left + " " + operation + " " + right + " = " + answer;
            }
            else
            {
                lblMessage.Text = "The Answer is: " + answer;
            }
        }
        

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtLeftOperand.Text = "";
            txtRightOperand.Text = "";

            lblMessage.Text = "";

            rdoAddition.Checked = true;

            chkVerbose.Checked = true;

            txtLeftOperand.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
