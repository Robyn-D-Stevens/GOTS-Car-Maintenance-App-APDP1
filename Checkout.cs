using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FinalVersion
{
    public partial class Checkout : Form
    {
        public Checkout()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string cardholderName, cardNum, expDate, CVV, cellphone, email;


            string path = @"E:\FinalVersion2019\CardDetails.txt";

            using (StreamWriter writer = new StreamWriter(path))

            {
                cardholderName = txtCardHolderName.Text;
                cardNum = txtCardNumber.Text;
                expDate = txtExpiryDate.Text;
                CVV = txtCVV.Text;
                cellphone = txtCellNumber.Text;
                email = txtEmailAddress.Text;

                writer.WriteLine(cardholderName + '\t' +cardNum + '\t' +expDate + '\t' +CVV + '\t' +cellphone  + '\t' +email +'\n');

            }


            if (txtCardHolderName.Text == "" || txtCardNumber.Text == "" || txtCVV.Text == "" || txtExpiryDate.Text == ""  || txtEmailAddress.Text == "" || txtCellNumber.Text == "")
            {
                MessageBox.Show("The fields are empty. Please fill in the missing spaces !!!");
            }


            else if (File.Exists(path))
            {

                if (txtCardNumber.Text.Length < 16)
                {
                    MessageBox.Show("Invalid Card Number! Please enter at least 16 digits.");
                }

                if (txtCVV.Text.Length < 3)
                {
                    MessageBox.Show("Invalid CVV! Please enter at least 3 digits.");
                }

                if (txtExpiryDate.Text.Length < 8)
                {
                    MessageBox.Show("Invalid Expiry Date! Please enter at least 6 digits.");
                }

                if (txtCellNumber.Text.Length < 10)
                {
                    MessageBox.Show("Invalid Cellphone Number! Please enter at least 10 digits.");
                }

                else
                {
                    MessageBox.Show("Checkout Successfull!");
                }
            }



        }

        

       



        private void txtCardNumber_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Allowing only numbers and certain control keys
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Suppress the key press
            }

            // Ensuring total characters are exactly 16
            if (txtCardNumber.Text.Length >= 16 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Suppress the key press
            }


        }

        private void txtCardholderName_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Allowing only letters, space, and certain control keys
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Suppress the key press
            }
        }

        private void txtExpiryDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allowing only numbers, backslash, and certain control keys
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/')
            {
                e.Handled = true; // Suppress the key press
            }

            // Ensuring total characters do not exceed 6
            if (txtExpiryDate.Text.Length >= 8 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Suppress the key press
            }
        }

        private void txtCVV_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allowing only numbers and certain control keys
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Suppress the key press
            }

            // Ensuring total characters do not exceed 3
            if (txtCVV.Text.Length >= 3 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Suppress the key press
            }
        }

        private void txtprovince_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allowing only letters, hyphen, space, and certain control keys
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != ' ')
            {
                e.Handled = true; // Suppress the key press
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Allowing only letters, numbers, and certain special characters for an email address
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) &&
            e.KeyChar != '@' && e.KeyChar != '.' && e.KeyChar != '_' && e.KeyChar != '-')
            {
                e.Handled = true; // Suppress the key press
            }
        }

        private void txtCellphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allowing only numbers and certain control keys
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Suppress the key press
            }

            // Ensuring total characters are exactly 10
            if (txtCellNumber.Text.Length >= 10 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Suppress the key press
            }

        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            // Closing the form
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RentCar Rcar = new RentCar();
            Rcar.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            txtCardHolderName.Clear();
            txtCardNumber.Clear();
            txtCVV.Clear();
            txtExpiryDate.Clear();
            txtEmailAddress.Clear();
            txtCellNumber.Clear();
            txtEmailAddress.Focus();
        }
    }
}
