using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Future_Value
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            decimal monthlyInvestement = Convert.ToDecimal(txtMonthlyInvestement.Text);
            decimal yearlyInterestRate = Convert.ToDecimal(txtInterestRate.Text);
            int years = Convert.ToInt32(txtYears.Text);

            int months = years * 12;
            decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;

            decimal futureValue = CalculateFutureValue(monthlyInvestement, monthlyInterestRate, months);
            txtFutureValue.Text = futureValue.ToString("C");
            txtMonthlyInvestement.Focus();
        }
        private decimal CalculateFutureValue(decimal monthlyInvestement, decimal monthlyinterestRate, int months)
        {
            decimal futureValue = 0m;
            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + monthlyInvestement)
                    * (1 + monthlyinterestRate);
            }
            return futureValue;


        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMonthlyInvestement_TextChanged(object sender, EventArgs e)
        {

        }
        
            
        
         
        private void txtFutureValue_TextChanged(object sender, EventArgs e)
        {



        }
        private void DisableButtons()
        {
            btnCalculate.Enabled = false;
            btnExit.Enabled = false;
        }
        private decimal GetDiscountPercent(decimal subtotal)
        {
            decimal discountPercent = 0m;
            if (subtotal >= 500)
                discountPercent = .2m;
            else
                discountPercent = .1m;
            return discountPercent;
        }

        private void ClearFutureValue(object sender, EventArgs e)
        {
            txtFutureValue.Text = "";
        }
    }
}
    