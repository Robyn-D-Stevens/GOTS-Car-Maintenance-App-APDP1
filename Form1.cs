using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace FinalVersion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;

        }
        public static string user;
        public static string currentuser
        {
            get { return user; }
            set { user = value; }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (txtUsername.Text == "Admin" && txtPassword.Text == "Ad1001")
            {
                Admin Ad = new Admin();
                Ad.Show();
                this.Hide();
            }
            else if (txtUsername.Text == "CarMManager" && txtPassword.Text == "CarMM")
            {
                CarMaintainceManager Cmm = new CarMaintainceManager();
                Cmm.Show();
                this.Hide();
            }
           
           else if (Login(username, password))
            {
                currentuser = txtUsername.Text;

                RentCar Rc = new RentCar();
                Rc.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private bool Login(string username, string password)
        {
            string filePath = @"E:\FinalVersion2019\RegistrationDetails.txt";

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split('\t');

                    if (parts.Length == 8 && parts[6].Trim() == username && parts[7].Trim() == password)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void lblRegister_Click(object sender, EventArgs e)
        {
            Registration Register = new Registration();
            Register.Show();
            this.Hide();
        }

        private void lblClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            RetrivePassword Rp = new RetrivePassword();
            Rp.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkShowHide_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowHide.Checked;
        }
    }
}
