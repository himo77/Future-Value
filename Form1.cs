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
        //creating and initializing a variable named monthlyinvestment.
        decimal monthlyInvestment = 0m;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public bool IsValidData() 
        {
            return

                //validate the monthly investment
                IsPresent(txtMonthlyInvestment, "Monthly Investment") &&
                IsDecimal(txtMonthlyInvestment, "Monthly Investment") &&
                IsWithinRange(txtMonthlyInvestment, "Monthly Investment", 1, 1000) &&

                 //validate the rate interest
                 IsPresent(txtInterestRate, "Yearly Interest Rate") &&
                 IsDecimal(txtInterestRate, "Yearly Interest Rate") &&
                 IsWithinRange(txtInterestRate, "Yearly Interest Rate", 1, 20) &&

                 //validate the yearly interest
                 IsPresent(txtYears, "Number of Years") &&
                 IsInt32(txtYears, "Number of Years") &&
                 IsWithinRange(txtYears, "Number of Years", 1, 40);



        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                //calling the isvaliddata method
               if(IsValidData())
                {
                    monthlyInvestment = Convert.ToDecimal(txtMonthlyInvestment.Text);
                    decimal yearlyInterestRate = Convert.ToDecimal(txtInterestRate.Text);
                    int years = Convert.ToInt32(txtYears.Text);

                    int months = years * 12;
                    decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;

                    decimal futureValue = CalculateFutureValue(monthlyInvestment, monthlyInterestRate, months);
                    txtFutureValue.Text = futureValue.ToString("C");
                    txtMonthlyInvestment.Focus();
                }


                
            }

            catch (FormatException)  // a specific exception
            {
                MessageBox.Show("Invalid numeric format. Please check all entries.", "Entry Error");
            }
            catch (OverflowException)  // another specific exception
            {
                MessageBox.Show("Overflow error. Please enter smaller values.", "Entry Error");
            }
            catch (Exception ex)  // all other exception
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }

        }


        //A method calculating future value.
        private decimal CalculateFutureValue(decimal monthlyInvestment, decimal monthlyinterestRate, int months)
        {


            decimal futureValue = 0m;
            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + monthlyInvestment)
                    * (1 + monthlyinterestRate);
            }
            return futureValue;
        }



       

        
       
        //A method to calculate the discount percent
        private decimal GetDiscountPercent(decimal subtotal)
        {
            decimal discountPercent = 0m;
            if (subtotal >= 500)
                discountPercent = .2m;
            else
                discountPercent = .1m;
            return discountPercent;
        }

       
        //A method to check if the textbox is empty
        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }
        //A method to check if the user entered a decimal  value or not.
        public bool IsDecimal(TextBox textBox, string name)
        {
            decimal number = 0m;
            if (Decimal.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be a decimal value.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }
        //A method to check if the user entered anything other than an integer.
        public bool IsInt32(TextBox textBox, string name)
        {
            int number = 0;
            if (Int32.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be an integer.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }
        //A method checking if the user input is within range.
        public bool IsWithinRange(TextBox textBox, string name, decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(name + "Must be between" + min + "and" + max + ".", "Entry Error");
                textBox.Focus();
                return false;

            }
            return true;
        }

        //close the program
        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

            
    