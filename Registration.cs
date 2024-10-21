using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace FinalVersion
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }
        
        public static bool IsValidEmail(string email)//Validating email address
        {

            string regexPattern = @"^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";//pattern on the email that must be present on the users input
            Regex regex = new Regex(regexPattern);
            return regex.IsMatch(email);
        }
        

        
        private  void  btnSubmit_Click(object sender, EventArgs e)//Submission button
        {
            string records = "";
            string[] MyArray = new string[8];
            StreamReader reads = new StreamReader(@"E:\FinalVersion2019\RegistrationDetails.txt");
            using (reads)
            {
                records = reads.ReadLine();
                while (records != null)
                {
                    MyArray = records.Split('\t');
                    if (txtID.Text == (MyArray[2]))
                    {
                        MessageBox.Show($"You already have an Account", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    records = reads.ReadLine();
                }
               
            }


            //username already exists vali
            string lineRec = "";
            string[] lineArray = new string[8];
            StreamReader objSR = new StreamReader(@"E:\FinalVersion2019\RegistrationDetails.txt");
            using (objSR)
            {
                lineRec = objSR.ReadLine();
                while (lineRec != null)
                {
                    lineArray = lineRec.Split('\t');
                    if (txtUsername.Text == (lineArray[6]))
                    {
                        MessageBox.Show($"Username Already Exists", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    lineRec = objSR.ReadLine();
                }

            }
            //validating email address
            string emailAddress = txtEmail.Text;

            if (!IsValidEmail(emailAddress))
            {
                MessageBox.Show("Email address is invalid!", "Validation Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            string gender = "";
            if (radFemale.Checked)
            {
                gender = "Female";
            }
            else if (radMale.Checked)
            {
                gender = "Male";
           
            }
            else if (radOther.Checked)
            {
                gender = "Other";
            }
            else
            {
                MessageBox.Show("Please choose gender","ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //password

                        //validating empty
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSurname.Text) || string.IsNullOrWhiteSpace(txtID.Text) ||
                string.IsNullOrWhiteSpace(txtCellnum.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirm.Text))
            {
                MessageBox.Show("Fill all missing spaces", "Notification!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtID.Text.Length < 13 || txtID.Text.Length > 13)
            {
                MessageBox.Show("Invalid ID Number! Please enter  13 digits.");
            }
            else if (txtCellnum.Text.Length < 10 || txtCellnum.Text.Length > 10)
            {
                MessageBox.Show("Invalid Cellphone Number! Please enter  10 digits.");
            }
            
            else
            {
                string file = @"E:\FinalVersion2019\RegistrationDetails.txt";
                StreamWriter objSW = new StreamWriter(file,true);
                using (objSW)
                {
                    string name = txtName.Text;
                    string surname = txtSurname.Text;
                    string id = txtID.Text;
                    string cellnum = txtCellnum.Text;
                    string email = txtEmail.Text;
                    string username = txtUsername.Text;
                    string password = txtPassword.Text;
                    string Gender = gender;

                    objSW.Write(name + '\t' + surname + '\t' + id + '\t' + gender + '\t' + cellnum + '\t' + email + '\t' + username + '\t' + password + '\n');
               
                }
                MessageBox.Show("Registration Successful", "Notification");
            }

         
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a letter
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the key press if it is not a letter or a control character
                e.Handled = true;
            }
          
        }

        private void txtSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a letter
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the key press if it is not a letter or a control character
                e.Handled = true;
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a digit
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the key press if it's not a digit or a control character
                e.Handled = true;
            }
        }

        private void txtCellnum_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a digit
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the key press if it's not a digit or a control character
                e.Handled = true;
            }
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        
        }

        private void txtConfirm_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtConfirm.Text)
            {
                label11.Text = "";
            }
            else
            {
                label11.Text = "Password does Not Match!";
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length >= 6)
            {
                label11.Text = "";
            }
            else
            {
                label11.Text = "Password must be atleast 6 charecters";
            }
        }
    }

}
