# Car-Maintenance-App-APDP1
// Group project for university project using C# and done on Visual Studio
// Source naming might be incorrect as the code was used as a back up for potential technical difficulties and IS NOT fully edited.
// This is STRICTLY CS files so feel free to design the layout and RENAME your content according to your forms.
// Each CS file is separated by a comment

// Program
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalVersion
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

// Registration Form
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

// Registration Designer

namespace FinalVersion
{
    partial class Registration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtCellnum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.lblMatch = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.radFemale = new System.Windows.Forms.RadioButton();
            this.radMale = new System.Windows.Forms.RadioButton();
            this.radOther = new System.Windows.Forms.RadioButton();
            this.lblCPass = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(63, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Customer Registration";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.txtSurname);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 100);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(112, 75);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(195, 21);
            this.txtID.TabIndex = 12;
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtID_KeyPress);
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(112, 41);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(195, 21);
            this.txtSurname.TabIndex = 11;
            this.txtSurname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSurname_KeyPress);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(112, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(195, 21);
            this.txtName.TabIndex = 10;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "ID Number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Surname:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.txtEmail);
            this.panel2.Controls.Add(this.txtCellnum);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(12, 195);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(396, 81);
            this.panel2.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(148, 53);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(194, 21);
            this.txtEmail.TabIndex = 12;
            // 
            // txtCellnum
            // 
            this.txtCellnum.Location = new System.Drawing.Point(148, 14);
            this.txtCellnum.Name = "txtCellnum";
            this.txtCellnum.Size = new System.Drawing.Size(194, 21);
            this.txtCellnum.TabIndex = 13;
            this.txtCellnum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCellnum_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Cellphone Number:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "Email Address:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.lblCPass);
            this.panel3.Controls.Add(this.lblPassword);
            this.panel3.Controls.Add(this.lblConfirm);
            this.panel3.Controls.Add(this.lblMatch);
            this.panel3.Controls.Add(this.lblUsername);
            this.panel3.Controls.Add(this.txtConfirm);
            this.panel3.Controls.Add(this.txtPassword);
            this.panel3.Controls.Add(this.txtUsername);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Location = new System.Drawing.Point(12, 282);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(396, 128);
            this.panel3.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.ForeColor = System.Drawing.Color.Red;
            this.lblPassword.Location = new System.Drawing.Point(148, 78);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(0, 15);
            this.lblPassword.TabIndex = 15;
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.ForeColor = System.Drawing.Color.Red;
            this.lblConfirm.Location = new System.Drawing.Point(145, 77);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(0, 15);
            this.lblConfirm.TabIndex = 14;
            // 
            // lblMatch
            // 
            this.lblMatch.AutoSize = true;
            this.lblMatch.ForeColor = System.Drawing.Color.Red;
            this.lblMatch.Location = new System.Drawing.Point(145, 80);
            this.lblMatch.Name = "lblMatch";
            this.lblMatch.Size = new System.Drawing.Size(0, 15);
            this.lblMatch.TabIndex = 13;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.ForeColor = System.Drawing.Color.Red;
            this.lblUsername.Location = new System.Drawing.Point(145, 36);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 15);
            this.lblUsername.TabIndex = 12;
            // 
            // txtConfirm
            // 
            this.txtConfirm.Location = new System.Drawing.Point(147, 98);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.Size = new System.Drawing.Size(195, 21);
            this.txtConfirm.TabIndex = 11;
            this.txtConfirm.TextChanged += new System.EventHandler(this.txtConfirm_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(147, 53);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(195, 21);
            this.txtPassword.TabIndex = 10;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(147, 13);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(195, 21);
            this.txtUsername.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 15);
            this.label8.TabIndex = 6;
            this.label8.Text = "Enter username:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 15);
            this.label9.TabIndex = 7;
            this.label9.Text = "Create Password:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 15);
            this.label10.TabIndex = 8;
            this.label10.Text = "Confirm Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Gender:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSubmit.Location = new System.Drawing.Point(283, 416);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(125, 31);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "SUBMIT";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnBack.Location = new System.Drawing.Point(14, 416);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(125, 31);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "BACK";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // radFemale
            // 
            this.radFemale.AutoSize = true;
            this.radFemale.Location = new System.Drawing.Point(124, 160);
            this.radFemale.Name = "radFemale";
            this.radFemale.Size = new System.Drawing.Size(73, 19);
            this.radFemale.TabIndex = 6;
            this.radFemale.TabStop = true;
            this.radFemale.Text = "Female";
            this.radFemale.UseVisualStyleBackColor = true;
            // 
            // radMale
            // 
            this.radMale.AutoSize = true;
            this.radMale.Location = new System.Drawing.Point(240, 160);
            this.radMale.Name = "radMale";
            this.radMale.Size = new System.Drawing.Size(57, 19);
            this.radMale.TabIndex = 7;
            this.radMale.TabStop = true;
            this.radMale.Text = "Male";
            this.radMale.UseVisualStyleBackColor = true;
            // 
            // radOther
            // 
            this.radOther.AutoSize = true;
            this.radOther.Location = new System.Drawing.Point(348, 160);
            this.radOther.Name = "radOther";
            this.radOther.Size = new System.Drawing.Size(60, 19);
            this.radOther.TabIndex = 8;
            this.radOther.TabStop = true;
            this.radOther.Text = "Other";
            this.radOther.UseVisualStyleBackColor = true;
            // 
            // lblCPass
            // 
            this.lblCPass.AutoSize = true;
            this.lblCPass.Location = new System.Drawing.Point(148, 77);
            this.lblCPass.Name = "lblCPass";
            this.lblCPass.Size = new System.Drawing.Size(0, 15);
            this.lblCPass.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(148, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 15);
            this.label11.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(148, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 15);
            this.label12.TabIndex = 18;
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(420, 459);
            this.Controls.Add(this.radOther);
            this.Controls.Add(this.radMale);
            this.Controls.Add(this.radFemale);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Registration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration";
            this.Load += new System.EventHandler(this.Registration_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtCellnum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.RadioButton radFemale;
        private System.Windows.Forms.RadioButton radMale;
        private System.Windows.Forms.RadioButton radOther;
        private System.Windows.Forms.Label lblMatch;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblCPass;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}

// Rental Details
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalVersion
{
    public partial class RentalDetails : Form
    {
        public RentalDetails()
        {
            InitializeComponent();
        }
        DataTable table = new DataTable();//Displays The table in the DataGridView
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // declare variables
            string customerId = txtCustID.Text;//Gets or sets the input on the textbox
            string customerName = txtCustName.Text;//Gets or sets the input on the textbox
            string carId = txtLP.Text;//Gets or sets the input on the textbox
            string carBrand = cmbCarBrand.Text;//Gets or sets the input on the textbox
            string carType = cmbCarType.Text;//Gets or sets the input on the textbox
            DateTime pickupDate = dateTimePicker1.Value;//Gets or sets the the date or time on the datetimepicker
            DateTime returnDate = dateTimePicker2.Value;//Gets or sets the the date or time on the datetimepicker

            if (customerId.Length != 13 || !customerId.All(char.IsDigit))//validates the Id NUmber
            {
                //when the ID Number is invalid this pops up
                MessageBox.Show("The custom ID should have 13 digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                //valodates the date
            if (pickupDate.Date == returnDate.Date)
            {
                //when the Date selection is invalid this pops up
                MessageBox.Show("You can't rent and return a car on the same day.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
               //Validates the textbox so an empty textbox cannot be saved
            if (string.IsNullOrWhiteSpace(customerName) || !customerName.All(char.IsLetter))
            {
                //when the customerName is invalid this pops up
                MessageBox.Show("Please enter your name", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Validates the textbox so an empty textbox cannot be saved
            if (string.IsNullOrWhiteSpace(carId))
            {
                //when the CarID is invalid this pops up
                MessageBox.Show("Please enter car number plate", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Validates the textbox so an empty textbox cannot be saved
            if (string.IsNullOrWhiteSpace(carBrand))
            {
                //when the carBrand is invalid this pops up
                MessageBox.Show("Please choose valid car brand ", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Validates the textbox so an empty textbox cannot be saved
            if (string.IsNullOrWhiteSpace(carType))
               //when the carType is invalid this pops up
            {
                MessageBox.Show("Please choose valid car type ", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {

                // Clear the ListBox before adding the new information (optional)
                // Display the information in the ListBox
                StreamWriter objSW = new StreamWriter(@"E:\New Text Document.txt", true);
                using (objSW)
                {
                    string custId = txtCustID.Text;//Gets or sets the input on the textbox
                    string custName = txtCustName.Text;//Gets or sets the input on the textbox
                    string carID = txtLP.Text;//Gets or sets the input on the textbox
                    string CarBrand = cmbCarBrand.Text;//Gets or sets the input on the textbox
                    string CarType = cmbCarType.Text;//Gets or sets the input on the textbox
                    DateTime PickupDate = dateTimePicker1.Value;//Gets or sets the the date or time on the datetimepicker
                    DateTime ReturnDate = dateTimePicker2.Value;//Gets or sets t

                    objSW.Write(custId + '\t' + custName + '\t' + carID + '\t' + CarBrand +'\t'+ CarType +'\t'+ PickupDate + '\t' + ReturnDate + '\n');

                }
                MessageBox.Show("SUCCESSFULLY ADDED TO RENTAL HISTORY", "NOTIFICATION",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }

           
        }

        private void txtCustID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a letter
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the key press if it is not a letter or a control character
                e.Handled = true;
            }
        }

        private void txtCustName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a letter
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the key press if it is not a letter or a control character
                e.Handled = true;
            }
        }

        private void txtLP_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a letter
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the key press if it is not a letter or a control character
                e.Handled = true;
            }
        }

        private void RentalDetails_Load(object sender, EventArgs e)
        {
            //Adding colomns to  a datagridview table
            table.Columns.Add("Customer ID", typeof(string));//adding the Name coloum to the table that store intergers only
            table.Columns.Add("Customer Name", typeof(string));//adding the Surname coloum to the table that store intergers only
            table.Columns.Add(" Car License Plate", typeof(string));//adding the ID coloum to the table that store intergers only
            table.Columns.Add("Car Brand", typeof(string));//adding the gENDER coloum to the table that store intergers only
            table.Columns.Add("Car Type", typeof(string));//adding the cELLPHONE NUMBER coloum to the table that store intergers only
            table.Columns.Add("Pick-Up Date", typeof(string));//adding the EMAIL ADDRESS coloum to the table that store intergers only
            table.Columns.Add("Return Date", typeof(string));//adding the uSERNAME coloum to the table that store intergers only
            
            dataGridView1.DataSource = table;//Gets the data thatthe datagrid view will display
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin ad = new Admin();
            ad.Show();
            this.Hide();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(@"E:\New Text Document.txt");//location a text file
            string[] values;
            // Getting data from a text file to be displayed in the datagridviiew and store and displayes it accoring to the table format/ layout
            for (int i = 0; i < lines.Length; i++)//for loop
            {
                values = lines[i].ToString().Split('\t');
                String[] row = new string[values.Length];
                for (int j = 0; j < values.Length; j++)
                {
                    row[j] = values[j].Trim();

                }
                table.Rows.Add(row);
            }
        }
    }
}

//Rental Details Designer
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalVersion
{
    public partial class RentalDetails : Form
    {
        public RentalDetails()
        {
            InitializeComponent();
        }
        DataTable table = new DataTable();//Displays The table in the DataGridView
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // declare variables
            string customerId = txtCustID.Text;//Gets or sets the input on the textbox
            string customerName = txtCustName.Text;//Gets or sets the input on the textbox
            string carId = txtLP.Text;//Gets or sets the input on the textbox
            string carBrand = cmbCarBrand.Text;//Gets or sets the input on the textbox
            string carType = cmbCarType.Text;//Gets or sets the input on the textbox
            DateTime pickupDate = dateTimePicker1.Value;//Gets or sets the the date or time on the datetimepicker
            DateTime returnDate = dateTimePicker2.Value;//Gets or sets the the date or time on the datetimepicker

            if (customerId.Length != 13 || !customerId.All(char.IsDigit))//validates the Id NUmber
            {
                //when the ID Number is invalid this pops up
                MessageBox.Show("The custom ID should have 13 digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                //valodates the date
            if (pickupDate.Date == returnDate.Date)
            {
                //when the Date selection is invalid this pops up
                MessageBox.Show("You can't rent and return a car on the same day.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
               //Validates the textbox so an empty textbox cannot be saved
            if (string.IsNullOrWhiteSpace(customerName) || !customerName.All(char.IsLetter))
            {
                //when the customerName is invalid this pops up
                MessageBox.Show("Please enter your name", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Validates the textbox so an empty textbox cannot be saved
            if (string.IsNullOrWhiteSpace(carId))
            {
                //when the CarID is invalid this pops up
                MessageBox.Show("Please enter car number plate", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Validates the textbox so an empty textbox cannot be saved
            if (string.IsNullOrWhiteSpace(carBrand))
            {
                //when the carBrand is invalid this pops up
                MessageBox.Show("Please choose valid car brand ", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Validates the textbox so an empty textbox cannot be saved
            if (string.IsNullOrWhiteSpace(carType))
               //when the carType is invalid this pops up
            {
                MessageBox.Show("Please choose valid car type ", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {

                // Clear the ListBox before adding the new information (optional)
                // Display the information in the ListBox
                StreamWriter objSW = new StreamWriter(@"E:\New Text Document.txt", true);
                using (objSW)
                {
                    string custId = txtCustID.Text;//Gets or sets the input on the textbox
                    string custName = txtCustName.Text;//Gets or sets the input on the textbox
                    string carID = txtLP.Text;//Gets or sets the input on the textbox
                    string CarBrand = cmbCarBrand.Text;//Gets or sets the input on the textbox
                    string CarType = cmbCarType.Text;//Gets or sets the input on the textbox
                    DateTime PickupDate = dateTimePicker1.Value;//Gets or sets the the date or time on the datetimepicker
                    DateTime ReturnDate = dateTimePicker2.Value;//Gets or sets t

                    objSW.Write(custId + '\t' + custName + '\t' + carID + '\t' + CarBrand +'\t'+ CarType +'\t'+ PickupDate + '\t' + ReturnDate + '\n');

                }
                MessageBox.Show("SUCCESSFULLY ADDED TO RENTAL HISTORY", "NOTIFICATION",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }

           
        }

        private void txtCustID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a letter
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the key press if it is not a letter or a control character
                e.Handled = true;
            }
        }

        private void txtCustName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a letter
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the key press if it is not a letter or a control character
                e.Handled = true;
            }
        }

        private void txtLP_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a letter
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the key press if it is not a letter or a control character
                e.Handled = true;
            }
        }

        private void RentalDetails_Load(object sender, EventArgs e)
        {
            //Adding colomns to  a datagridview table
            table.Columns.Add("Customer ID", typeof(string));//adding the Name coloum to the table that store intergers only
            table.Columns.Add("Customer Name", typeof(string));//adding the Surname coloum to the table that store intergers only
            table.Columns.Add(" Car License Plate", typeof(string));//adding the ID coloum to the table that store intergers only
            table.Columns.Add("Car Brand", typeof(string));//adding the gENDER coloum to the table that store intergers only
            table.Columns.Add("Car Type", typeof(string));//adding the cELLPHONE NUMBER coloum to the table that store intergers only
            table.Columns.Add("Pick-Up Date", typeof(string));//adding the EMAIL ADDRESS coloum to the table that store intergers only
            table.Columns.Add("Return Date", typeof(string));//adding the uSERNAME coloum to the table that store intergers only
            
            dataGridView1.DataSource = table;//Gets the data thatthe datagrid view will display
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin ad = new Admin();
            ad.Show();
            this.Hide();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(@"E:\New Text Document.txt");//location a text file
            string[] values;
            // Getting data from a text file to be displayed in the datagridviiew and store and displayes it accoring to the table format/ layout
            for (int i = 0; i < lines.Length; i++)//for loop
            {
                values = lines[i].ToString().Split('\t');
                String[] row = new string[values.Length];
                for (int j = 0; j < values.Length; j++)
                {
                    row[j] = values[j].Trim();

                }
                table.Rows.Add(row);
            }
        }
    }
}

// Rent Car
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
    public partial class RentCar : Form
    {
        public RentCar()
        {
            InitializeComponent();
        }
        
        private void RentCar_Load(object sender, EventArgs e)
        {
            txtCurrentUser.Text = Form1.currentuser;
            panel10.Visible = false;
            panel3.Visible = false;
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
           
          
            
            //Small Car Catergory
            cmbSmall.Items.Add("Renault Kwid");
            cmbSmall.Items.Add("Mini Cooper");
            cmbSmall.Items.Add("Hyndai Grand i10");
            //Mid Sized Catergory
            cmbMid.Items.Add("Toyota Camry");
            cmbMid.Items.Add("Mazda 3");
            cmbMid.Items.Add("Honda Accord");
            //Large Size Catergory
            cmbLarge.Items.Add("Toyota Fortuner");
            cmbLarge.Items.Add("Mazda CX-5");
            cmbLarge.Items.Add("Hyndai Tuscon");
            //People Carriers
            cmbPCarrier.Items.Add("Mercedes V Class");
            cmbPCarrier.Items.Add("Hyndai i800");
            cmbPCarrier.Items.Add("VW Caravelle");

        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime pickupDate = dateTimePicker1.Value;//Gets or sets the the date or time on the datetimepicker
            DateTime returnDate = dateTimePicker2.Value;//Gets or sets the the date or time on the datetimepicker
            if (pickupDate.Date == returnDate.Date)
            {
                //when the Date selection is invalid this pops up
                MessageBox.Show("You can't rent and return a car on the same day.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //the panel1 hides and panel2 shows
                panel3.Visible = true;
                panel1.Visible = false;
            }
            if (radioButton1.Checked)
            {
                //the panel1 hides and panel2 shows
                panel3.Visible = true;
                panel1.Visible = false;
            }
            else
            {
                //pops up when 
                MessageBox.Show("You have to agree to terms and conditions to continue", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSmall_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCars.Text = cmbSmall.Text;
            if (cmbSmall.SelectedItem == "Hyndai Grand i10")
            {
                var path = @"E:\FinalVersion2019\renault-kwid-ice-cool-white.png";
                var imageLabel = Path.Combine(path);
                pictureBox1.ImageLocation = imageLabel;
                
            }
            if (cmbSmall.SelectedItem == "Mini Cooper")
            {
                var path = @"E:\Mini-Cooper-S-Transparent-File.png";
                var imageLabel = Path.Combine(path);
                pictureBox1.ImageLocation = imageLabel;
            }
            if (cmbSmall.SelectedItem == "Renault Kwid")
            {
                var path = @"E:\FinalVersion2019\hyundai-grand-i10-nios-polar-white.png";
                var imageLabel = Path.Combine(path);
                pictureBox1.ImageLocation = imageLabel;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Today > dateTimePicker1.Value)
            {
                MessageBox.Show("You cannot select the date before the Current Date", "ERROR!");
                dateTimePicker1.Value = DateTime.Today;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Today > dateTimePicker2.Value)
            {
                MessageBox.Show("You cannot select the date before the Current Date", "ERROR!");
                dateTimePicker1.Value = DateTime.Today;
            }
        }
        
        private void button2_Click(object sender, EventArgs e)

        {
            
            panel10.Visible = true;
            // Calculate the number of days between the two datetime pickers.
            TimeSpan timeSpan = dateTimePicker2.Value - dateTimePicker1.Value;
            int numberOfDays = timeSpan.Days;
           
            //declare variables
            double carcost = 0, extracost = 0, carCostExtras = 0, totalCost=0 ;
            if(txtCars.Text == "Mini Cooper")
            {
                carcost = 900;
            }
            if (txtCars.Text == "Renault Kwid")
            {
                carcost = 700;
            }
            if (txtCars.Text == "Hyndai Grand i10")
            {
                carcost = 600;
            }
            if (txtCars.Text == "Toyota Camry")
            {
                carcost = 1000;
            }
            if (txtCars.Text == "Madza 3")
            {
                carcost = 1100;
            }
            if (txtCars.Text == "Honda Accord")
            {
                carcost = 1000;
            }
            if (txtCars.Text == "Toyota Fortuner")
            {
                carcost = 1900;
            }
            if (txtCars.Text == "Mazda CX-5")
            {
                carcost = 1300;
            }
            if (txtCars.Text == "Hyndai Tuscon")
            {
                carcost = 1500;
            }
            if (txtCars.Text == "VW Caravelle")
            {
                carcost = 3000;
            }
            if (txtCars.Text == "Hyndai i800")
            {
                carcost = 3400;
            }
            if (txtCars.Text == "Mercedes V Class")
            {
                carcost = 3900;
            }

            //extras
            if (chkNavigation.Checked)
            {
                extracost = 150;
            }
            if (chkWiFi.Checked)
            {
                extracost += 200;
            }
            if (chkChildSeats.Checked)
            {
                extracost += 150;
            }
            if (chkRRack.Checked)
            {
                extracost += 120;
            }
            if (chkBRack.Checked)
            {
                extracost += 100;
            }
            if (chkAddDriver.Checked)
            {
                extracost += 550;

            }

            
           
            ///calculation
            carCostExtras = carcost + extracost;
            totalCost = numberOfDays * carCostExtras;
            //output
            txtCarCost.Text = carcost.ToString("C");
            txtExtras.Text = extracost.ToString("C");
            txtTotal.Text = totalCost.ToString("C");
            txtLocation.Text = cmbLocation.Text;
            txtGearT.Text = cmbGearType.Text;
            txtColor.Text = cmbColors.Text;
            txtNumDays.Text = dateTimePicker1.Text;
            txtReturnDate.Text = dateTimePicker2.Text;


        }

        private void label7_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel1.Visible = true;
        }

       

        private void cmbMid_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCars.Text = cmbMid.Text;
            if (cmbMid.SelectedItem == "Mazda 3")
            {
                var path = @"E:\FinalVersion2019\mazda3.png";
                var imageLabel = Path.Combine(path);
                pictureBox1.ImageLocation = imageLabel;
            }
            if (cmbMid.SelectedItem == "Honda Accord")
            {
                var path = @"E:\FinalVersion2019\Honda-Accord-Transparent-File.png";
                var imageLabel = Path.Combine(path);
                pictureBox1.ImageLocation = imageLabel;
            }
            if (cmbMid.SelectedItem == "Toyota Camry")
            {
                var path = @"E:\FinalVersion2019\Toyotamid.png";
                var imageLabel = Path.Combine(path);
                pictureBox1.ImageLocation = imageLabel;
            }
        }

        private void cmbLarge_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCars.Text = cmbLarge.Text;
            if (cmbLarge.SelectedItem == "Toyota Fortuner")
            {
                var path = @"E:\FinalVersion2019\Toyota-Fortuner-PNG-HD.png";
                var imageLabel = Path.Combine(path);
                pictureBox1.ImageLocation = imageLabel;
            }
            if (cmbLarge.SelectedItem == "Mazda CX-5")
            {
                var path = @"E:\FinalVersion2019\mazda_PNG79.png";
                var imageLabel = Path.Combine(path);
                pictureBox1.ImageLocation = imageLabel;
            }
            if (cmbLarge.SelectedItem == "Hyndai Tuscon")
            {
                var path = @"E:\FinalVersion2019\tuscon.png";
                var imageLabel = Path.Combine(path);
                pictureBox1.ImageLocation = imageLabel;
            }
        }

        private void cmbPCarrier_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCars.Text = cmbPCarrier.Text;
            if (cmbPCarrier.SelectedItem == "VW Caravelle")
            {
                var path = @"E:\FinalVersion2019\Mercedes V class.png";
                var imageLabel = Path.Combine(path);
                pictureBox1.ImageLocation = imageLabel;
            }
            if (cmbPCarrier.SelectedItem == "Hyndai i800")
            {
                var path = @"E:\FinalVersion2019\Hyundai_i800-main.png";
                var imageLabel = Path.Combine(path);
                pictureBox1.ImageLocation = imageLabel;
            }
            if (cmbPCarrier.SelectedItem == "Mercedes V Class")
            {
                var path = @"E:\FinalVersion2019\vclass.png";
                var imageLabel = Path.Combine(path);
                pictureBox1.ImageLocation = imageLabel;
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Form1 Back = new Form1();
            Back.Show();
            this.Hide();
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtCars.Text) || string.IsNullOrWhiteSpace(txtLocation.Text) || string.IsNullOrWhiteSpace(txtNumDays.Text) ||
                string.IsNullOrWhiteSpace(txtReturnDate.Text) || string.IsNullOrWhiteSpace(txtColor.Text) || string.IsNullOrWhiteSpace(txtGearT.Text) ||
                string.IsNullOrWhiteSpace(txtCarCost.Text) || string.IsNullOrWhiteSpace(txtExtras.Text) || string.IsNullOrWhiteSpace(txtTotal.Text))
            {
                MessageBox.Show("Please choose all options to fill in all missing spaces!", "ALERT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
             StreamWriter objSW = new StreamWriter(@"E:\FinalVersion2019\Current Bookings.txt", true);
             using (objSW)
             {


                string CarCost = txtCarCost.Text;
                string Extras = txtExtras.Text;
                string Total = txtTotal.Text;
                string Location = txtLocation.Text;
                string Start = txtNumDays.Text;
                string End = txtReturnDate.Text;
                string Colour = txtColor.Text;
                string Gear = txtGearT.Text;
                string user = txtCurrentUser.Text;
                string car = txtCars.Text;

                //write
                objSW.Write(user + '\t' + Location + '\t' + car + '\t' + Start + '\t' + End + '\t' + Colour + '\t' + Gear + '\t' + CarCost + '\t' + Extras + '\t' + Total + '\n');
                    Checkout Chkout = new Checkout();
                    Chkout.Show();
                    this.Hide();
             }
           
            }
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel3.Visible = true;
            panel10.Visible = false;
        }
    }
  }

// Rent Car Designer

namespace FinalVersion
{
    partial class RentCar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RentCar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCurrentUser = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.txtReturnDate = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.txtNumDays = new System.Windows.Forms.TextBox();
            this.txtExtras = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtGearT = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtCarCost = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtCars = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.chkAddDriver = new System.Windows.Forms.CheckBox();
            this.chkWiFi = new System.Windows.Forms.CheckBox();
            this.chkNavigation = new System.Windows.Forms.CheckBox();
            this.chkBRack = new System.Windows.Forms.CheckBox();
            this.chkRRack = new System.Windows.Forms.CheckBox();
            this.chkChildSeats = new System.Windows.Forms.CheckBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.cmbGearType = new System.Windows.Forms.ComboBox();
            this.cmbColors = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbMid = new System.Windows.Forms.ComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbLarge = new System.Windows.Forms.ComboBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbPCarrier = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbSmall = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.cmbLocation);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(116, 179);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 200);
            this.panel1.TabIndex = 0;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.radioButton1.Location = new System.Drawing.Point(31, 119);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(244, 19);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Legal Driver over 21 years of age?";
            this.radioButton1.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(207, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 37);
            this.button1.TabIndex = 6;
            this.button1.Text = "View Available Cars";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbLocation
            // 
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Items.AddRange(new object[] {
            "King Shaka International Airport",
            "Mount Currie Inn, Main Rd, Kokstad, 4700",
            "Arbor Crossing Shopping Centr, 2 Oppenheimer Road, Amanzimtoti, 4000",
            "190 Ke Masinga Road, Durban, 4000. ",
            "190 Ke Masinga Road, Durban, 4000. "});
            this.cmbLocation.Location = new System.Drawing.Point(153, 24);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(392, 23);
            this.cmbLocation.TabIndex = 5;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(297, 90);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(248, 21);
            this.dateTimePicker2.TabIndex = 4;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(31, 90);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(249, 21);
            this.dateTimePicker1.TabIndex = 3;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(294, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Return Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(28, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pick-Up Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(28, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Location:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtCurrentUser);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(798, 82);
            this.panel2.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(523, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 15);
            this.label10.TabIndex = 7;
            this.label10.Text = "Log in";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(360, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 15);
            this.label9.TabIndex = 6;
            this.label9.Text = "Contact Us";
            // 
            // txtCurrentUser
            // 
            this.txtCurrentUser.Location = new System.Drawing.Point(679, 32);
            this.txtCurrentUser.Name = "txtCurrentUser";
            this.txtCurrentUser.Size = new System.Drawing.Size(117, 20);
            this.txtCurrentUser.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(589, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "Current User:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(265, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "Home Page";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(446, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "About Us";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(294, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 15);
            this.label5.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(256, 45);
            this.label4.TabIndex = 0;
            this.label4.Text = "GOTsCarRental";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel3.Controls.Add(this.panel10);
            this.panel3.Controls.Add(this.txtCars);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.panel9);
            this.panel3.Controls.Add(this.panel8);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(1, 81);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(798, 357);
            this.panel3.TabIndex = 2;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Location = new System.Drawing.Point(2, 0);
            this.panel10.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(796, 378);
            this.panel10.TabIndex = 9;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel11.Controls.Add(this.txtReturnDate);
            this.panel11.Controls.Add(this.label25);
            this.panel11.Controls.Add(this.txtColor);
            this.panel11.Controls.Add(this.label22);
            this.panel11.Controls.Add(this.button4);
            this.panel11.Controls.Add(this.button3);
            this.panel11.Controls.Add(this.label23);
            this.panel11.Controls.Add(this.txtNumDays);
            this.panel11.Controls.Add(this.txtExtras);
            this.panel11.Controls.Add(this.txtLocation);
            this.panel11.Controls.Add(this.txtGearT);
            this.panel11.Controls.Add(this.label24);
            this.panel11.Controls.Add(this.txtCarCost);
            this.panel11.Controls.Add(this.txtTotal);
            this.panel11.Controls.Add(this.label21);
            this.panel11.Controls.Add(this.label18);
            this.panel11.Controls.Add(this.label20);
            this.panel11.Controls.Add(this.label19);
            this.panel11.Location = new System.Drawing.Point(150, 6);
            this.panel11.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(499, 344);
            this.panel11.TabIndex = 21;
            this.panel11.Paint += new System.Windows.Forms.PaintEventHandler(this.panel11_Paint);
            // 
            // txtReturnDate
            // 
            this.txtReturnDate.Location = new System.Drawing.Point(295, 88);
            this.txtReturnDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtReturnDate.Name = "txtReturnDate";
            this.txtReturnDate.Size = new System.Drawing.Size(151, 20);
            this.txtReturnDate.TabIndex = 26;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(61, 92);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(68, 13);
            this.label25.TabIndex = 25;
            this.label25.Text = "Return Date:";
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(295, 120);
            this.txtColor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(151, 20);
            this.txtColor.TabIndex = 24;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(61, 122);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 13);
            this.label22.TabIndex = 23;
            this.label22.Text = "Car Color:";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.button4.Location = new System.Drawing.Point(27, 302);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(141, 31);
            this.button4.TabIndex = 22;
            this.button4.Text = "BACK";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.button3.Location = new System.Drawing.Point(347, 302);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(141, 31);
            this.button3.TabIndex = 21;
            this.button3.Text = "CHECKOUT";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(61, 27);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(115, 13);
            this.label23.TabIndex = 17;
            this.label23.Text = "The Pick-up Location :";
            // 
            // txtNumDays
            // 
            this.txtNumDays.Location = new System.Drawing.Point(295, 58);
            this.txtNumDays.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNumDays.Name = "txtNumDays";
            this.txtNumDays.Size = new System.Drawing.Size(151, 20);
            this.txtNumDays.TabIndex = 20;
            // 
            // txtExtras
            // 
            this.txtExtras.Location = new System.Drawing.Point(294, 232);
            this.txtExtras.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtExtras.Name = "txtExtras";
            this.txtExtras.Size = new System.Drawing.Size(151, 20);
            this.txtExtras.TabIndex = 9;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(294, 19);
            this.txtLocation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLocation.Multiline = true;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(189, 29);
            this.txtLocation.TabIndex = 19;
            // 
            // txtGearT
            // 
            this.txtGearT.Location = new System.Drawing.Point(294, 151);
            this.txtGearT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtGearT.Name = "txtGearT";
            this.txtGearT.Size = new System.Drawing.Size(151, 20);
            this.txtGearT.TabIndex = 10;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(61, 60);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(74, 13);
            this.label24.TabIndex = 18;
            this.label24.Text = "Pick-Up Date:";
            // 
            // txtCarCost
            // 
            this.txtCarCost.Location = new System.Drawing.Point(294, 191);
            this.txtCarCost.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCarCost.Name = "txtCarCost";
            this.txtCarCost.Size = new System.Drawing.Size(151, 20);
            this.txtCarCost.TabIndex = 8;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(295, 273);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(151, 20);
            this.txtTotal.TabIndex = 11;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(61, 273);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(223, 13);
            this.label21.TabIndex = 15;
            this.label21.Text = "The total Rental Cost over the rental period is:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(61, 193);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(182, 13);
            this.label18.TabIndex = 12;
            this.label18.Text = "The rental Cost for this car per day is:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(61, 153);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(141, 13);
            this.label20.TabIndex = 14;
            this.label20.Text = "The Gear type for this Car is:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(61, 234);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(180, 13);
            this.label19.TabIndex = 13;
            this.label19.Text = "The total Extras cost for this rental is:";
            // 
            // txtCars
            // 
            this.txtCars.Location = new System.Drawing.Point(117, 283);
            this.txtCars.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCars.Name = "txtCars";
            this.txtCars.Size = new System.Drawing.Size(165, 20);
            this.txtCars.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(143, 305);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 37);
            this.button2.TabIndex = 6;
            this.button2.Text = "VIEW DEAL";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(71, 74);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(248, 181);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel9.Controls.Add(this.label17);
            this.panel9.Controls.Add(this.chkAddDriver);
            this.panel9.Controls.Add(this.chkWiFi);
            this.panel9.Controls.Add(this.chkNavigation);
            this.panel9.Controls.Add(this.chkBRack);
            this.panel9.Controls.Add(this.chkRRack);
            this.panel9.Controls.Add(this.chkChildSeats);
            this.panel9.Location = new System.Drawing.Point(439, 161);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(294, 145);
            this.panel9.TabIndex = 4;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label17.Location = new System.Drawing.Point(3, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 13);
            this.label17.TabIndex = 4;
            this.label17.Text = "Car Hire Extras:";
            // 
            // chkAddDriver
            // 
            this.chkAddDriver.AutoSize = true;
            this.chkAddDriver.BackColor = System.Drawing.Color.Transparent;
            this.chkAddDriver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAddDriver.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkAddDriver.Location = new System.Drawing.Point(180, 120);
            this.chkAddDriver.Name = "chkAddDriver";
            this.chkAddDriver.Size = new System.Drawing.Size(92, 19);
            this.chkAddDriver.TabIndex = 5;
            this.chkAddDriver.Text = "Add Driver";
            this.chkAddDriver.UseVisualStyleBackColor = false;
            // 
            // chkWiFi
            // 
            this.chkWiFi.AutoSize = true;
            this.chkWiFi.BackColor = System.Drawing.Color.Transparent;
            this.chkWiFi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWiFi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkWiFi.Location = new System.Drawing.Point(180, 77);
            this.chkWiFi.Name = "chkWiFi";
            this.chkWiFi.Size = new System.Drawing.Size(54, 19);
            this.chkWiFi.TabIndex = 4;
            this.chkWiFi.Text = "WiFi";
            this.chkWiFi.UseVisualStyleBackColor = false;
            // 
            // chkNavigation
            // 
            this.chkNavigation.AutoSize = true;
            this.chkNavigation.BackColor = System.Drawing.Color.Transparent;
            this.chkNavigation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNavigation.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkNavigation.Location = new System.Drawing.Point(180, 36);
            this.chkNavigation.Name = "chkNavigation";
            this.chkNavigation.Size = new System.Drawing.Size(94, 19);
            this.chkNavigation.TabIndex = 3;
            this.chkNavigation.Text = "Navigation";
            this.chkNavigation.UseVisualStyleBackColor = false;
            // 
            // chkBRack
            // 
            this.chkBRack.AutoSize = true;
            this.chkBRack.BackColor = System.Drawing.Color.Transparent;
            this.chkBRack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBRack.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkBRack.Location = new System.Drawing.Point(3, 120);
            this.chkBRack.Name = "chkBRack";
            this.chkBRack.Size = new System.Drawing.Size(107, 19);
            this.chkBRack.TabIndex = 2;
            this.chkBRack.Text = "Bicycle Rack";
            this.chkBRack.UseVisualStyleBackColor = false;
            // 
            // chkRRack
            // 
            this.chkRRack.AutoSize = true;
            this.chkRRack.BackColor = System.Drawing.Color.Transparent;
            this.chkRRack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRRack.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkRRack.Location = new System.Drawing.Point(3, 77);
            this.chkRRack.Name = "chkRRack";
            this.chkRRack.Size = new System.Drawing.Size(92, 19);
            this.chkRRack.TabIndex = 1;
            this.chkRRack.Text = "Roof Rack";
            this.chkRRack.UseVisualStyleBackColor = false;
            // 
            // chkChildSeats
            // 
            this.chkChildSeats.AutoSize = true;
            this.chkChildSeats.BackColor = System.Drawing.Color.Transparent;
            this.chkChildSeats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkChildSeats.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkChildSeats.Location = new System.Drawing.Point(3, 36);
            this.chkChildSeats.Name = "chkChildSeats";
            this.chkChildSeats.Size = new System.Drawing.Size(99, 19);
            this.chkChildSeats.TabIndex = 0;
            this.chkChildSeats.Text = "Child Seats";
            this.chkChildSeats.UseVisualStyleBackColor = false;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.cmbGearType);
            this.panel8.Controls.Add(this.cmbColors);
            this.panel8.Controls.Add(this.label16);
            this.panel8.Controls.Add(this.label15);
            this.panel8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel8.Location = new System.Drawing.Point(439, 65);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(295, 82);
            this.panel8.TabIndex = 3;
            // 
            // cmbGearType
            // 
            this.cmbGearType.FormattingEnabled = true;
            this.cmbGearType.Items.AddRange(new object[] {
            "Manual",
            "Automatic"});
            this.cmbGearType.Location = new System.Drawing.Point(136, 41);
            this.cmbGearType.Name = "cmbGearType";
            this.cmbGearType.Size = new System.Drawing.Size(155, 21);
            this.cmbGearType.TabIndex = 3;
            // 
            // cmbColors
            // 
            this.cmbColors.FormattingEnabled = true;
            this.cmbColors.Items.AddRange(new object[] {
            "White",
            "Black",
            "Silver"});
            this.cmbColors.Location = new System.Drawing.Point(136, 14);
            this.cmbColors.Name = "cmbColors";
            this.cmbColors.Size = new System.Drawing.Size(155, 21);
            this.cmbColors.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.Location = new System.Drawing.Point(6, 43);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Gear Type:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label15.Location = new System.Drawing.Point(6, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Available Colors:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label12);
            this.panel5.Controls.Add(this.cmbMid);
            this.panel5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel5.Location = new System.Drawing.Point(205, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(194, 56);
            this.panel5.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label12.Location = new System.Drawing.Point(27, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(129, 20);
            this.label12.TabIndex = 3;
            this.label12.Text = "Mid Sized Cars";
            // 
            // cmbMid
            // 
            this.cmbMid.FormattingEnabled = true;
            this.cmbMid.Location = new System.Drawing.Point(1, 31);
            this.cmbMid.Name = "cmbMid";
            this.cmbMid.Size = new System.Drawing.Size(187, 21);
            this.cmbMid.TabIndex = 1;
            this.cmbMid.SelectedIndexChanged += new System.EventHandler(this.cmbMid_SelectedIndexChanged);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.label13);
            this.panel6.Controls.Add(this.cmbLarge);
            this.panel6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel6.Location = new System.Drawing.Point(401, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(194, 56);
            this.panel6.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label13.Location = new System.Drawing.Point(41, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 20);
            this.label13.TabIndex = 4;
            this.label13.Text = "Large Cars";
            // 
            // cmbLarge
            // 
            this.cmbLarge.FormattingEnabled = true;
            this.cmbLarge.Location = new System.Drawing.Point(3, 31);
            this.cmbLarge.Name = "cmbLarge";
            this.cmbLarge.Size = new System.Drawing.Size(187, 21);
            this.cmbLarge.TabIndex = 2;
            this.cmbLarge.SelectedIndexChanged += new System.EventHandler(this.cmbLarge_SelectedIndexChanged);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.label14);
            this.panel7.Controls.Add(this.cmbPCarrier);
            this.panel7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel7.Location = new System.Drawing.Point(602, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(194, 56);
            this.panel7.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(17, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(137, 20);
            this.label14.TabIndex = 5;
            this.label14.Text = "People Carriers ";
            // 
            // cmbPCarrier
            // 
            this.cmbPCarrier.FormattingEnabled = true;
            this.cmbPCarrier.Location = new System.Drawing.Point(3, 31);
            this.cmbPCarrier.Name = "cmbPCarrier";
            this.cmbPCarrier.Size = new System.Drawing.Size(187, 21);
            this.cmbPCarrier.TabIndex = 3;
            this.cmbPCarrier.SelectedIndexChanged += new System.EventHandler(this.cmbPCarrier_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.cmbSmall);
            this.panel4.Location = new System.Drawing.Point(11, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(194, 56);
            this.panel4.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label11.Location = new System.Drawing.Point(43, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 20);
            this.label11.TabIndex = 2;
            this.label11.Text = "Small Cars";
            // 
            // cmbSmall
            // 
            this.cmbSmall.FormattingEnabled = true;
            this.cmbSmall.Location = new System.Drawing.Point(3, 31);
            this.cmbSmall.Name = "cmbSmall";
            this.cmbSmall.Size = new System.Drawing.Size(187, 21);
            this.cmbSmall.TabIndex = 0;
            this.cmbSmall.SelectedIndexChanged += new System.EventHandler(this.cmbSmall_SelectedIndexChanged);
            // 
            // RentCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "RentCar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RentCar";
            this.Load += new System.EventHandler(this.RentCar_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCurrentUser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox cmbMid;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cmbLarge;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ComboBox cmbPCarrier;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cmbSmall;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.CheckBox chkChildSeats;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox chkAddDriver;
        private System.Windows.Forms.CheckBox chkWiFi;
        private System.Windows.Forms.CheckBox chkNavigation;
        private System.Windows.Forms.CheckBox chkBRack;
        private System.Windows.Forms.CheckBox chkRRack;
        private System.Windows.Forms.ComboBox cmbGearType;
        private System.Windows.Forms.ComboBox cmbColors;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox txtCars;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtGearT;
        private System.Windows.Forms.TextBox txtExtras;
        private System.Windows.Forms.TextBox txtCarCost;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtNumDays;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtReturnDate;
        private System.Windows.Forms.Label label25;
    }
}

//Retrieve Password
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
    public partial class RetrivePassword : Form
    {
        public RetrivePassword()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            string lineRec = "";
            string[] lineArray = new string[8];
            int cellNum;
            cellNum = int.Parse(txtCellNumber.Text);
            lblOutput.Text = "Cellphone number is not in our system";

            StreamReader objSR = new StreamReader(@"E:\FinalVersion2019\RegistrationDetails.txt");
            using (objSR)
            {
                lineRec = objSR.ReadLine();
                while (lineRec != null)
                {
                    lineArray = lineRec.Split('\t');
                    if (txtCellNumber.Text == (lineArray[4]))
                    {
                        lblOutput.Text = (lineArray[7]);
                    }
                    lineRec = objSR.ReadLine();
                }
              
            }
        }
    }
}

//Retrieve Password Designer

namespace FinalVersion
{
    partial class RetrivePassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtCellNumber = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Cellphone Number:";
            // 
            // txtCellNumber
            // 
            this.txtCellNumber.Location = new System.Drawing.Point(244, 36);
            this.txtCellNumber.Name = "txtCellNumber";
            this.txtCellNumber.Size = new System.Drawing.Size(202, 28);
            this.txtCellNumber.TabIndex = 1;
            // 
            // btnProcess
            // 
            this.btnProcess.BackColor = System.Drawing.SystemColors.GrayText;
            this.btnProcess.Location = new System.Drawing.Point(157, 70);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(154, 31);
            this.btnProcess.TabIndex = 2;
            this.btnProcess.Text = "Retrieve Password";
            this.btnProcess.UseVisualStyleBackColor = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnExit.Location = new System.Drawing.Point(157, 137);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(154, 32);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Your PASSWORD is:";
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(240, 104);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(58, 22);
            this.lblOutput.TabIndex = 7;
            this.lblOutput.Text = "******";
            // 
            // RetrivePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(458, 181);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.txtCellNumber);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "RetrivePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RetrivePassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCellNumber;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblOutput;
    }
}

//Maintenence Feedback
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalVersion
{
    public partial class MaintainaceFeedback : Form
    {
        public MaintainaceFeedback()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader(@"E:\FinalVersion2019\InspectionReport.txt");
            using (reader)
            {
               
                string line = reader.ReadLine();
                while(line != null)
                {
               
                    lstOutput.Items.Add(line);
                    line = reader.ReadLine();
                }
                ;
            }
        }
    }
}

//Maintenence Feedback Designer

namespace FinalVersion
{
    partial class MaintainaceFeedback
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstOutput = new System.Windows.Forms.ListBox();
            this.btnView = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstOutput
            // 
            this.lstOutput.FormattingEnabled = true;
            this.lstOutput.Location = new System.Drawing.Point(48, 84);
            this.lstOutput.Name = "lstOutput";
            this.lstOutput.Size = new System.Drawing.Size(326, 342);
            this.lstOutput.TabIndex = 0;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(96, 55);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(221, 23);
            this.btnView.TabIndex = 1;
            this.btnView.Text = "VIEW DETAILS";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // MaintainaceFeedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 450);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.lstOutput);
            this.Name = "MaintainaceFeedback";
            this.Text = "MaintainaceFeedback";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstOutput;
        private System.Windows.Forms.Button btnView;
    }
}

// Form1
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

// Form1 Designer

namespace FinalVersion
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblClear = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkShowHide = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRegister = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(292, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(292, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // lblClear
            // 
            this.lblClear.AutoSize = true;
            this.lblClear.ForeColor = System.Drawing.Color.Red;
            this.lblClear.Location = new System.Drawing.Point(292, 161);
            this.lblClear.Name = "lblClear";
            this.lblClear.Size = new System.Drawing.Size(55, 24);
            this.lblClear.TabIndex = 2;
            this.lblClear.Text = "Clear";
            this.lblClear.Click += new System.EventHandler(this.lblClear_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(285, 323);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(324, 84);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(185, 32);
            this.txtUsername.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(324, 131);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(185, 32);
            this.txtPassword.TabIndex = 5;
            // 
            // chkShowHide
            // 
            this.chkShowHide.AutoSize = true;
            this.chkShowHide.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkShowHide.Location = new System.Drawing.Point(404, 161);
            this.chkShowHide.Name = "chkShowHide";
            this.chkShowHide.Size = new System.Drawing.Size(168, 28);
            this.chkShowHide.TabIndex = 6;
            this.chkShowHide.Text = "Show Password";
            this.chkShowHide.UseVisualStyleBackColor = true;
            this.chkShowHide.CheckedChanged += new System.EventHandler(this.chkShowHide_CheckedChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.DarkOrange;
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLogin.Location = new System.Drawing.Point(349, 188);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(106, 33);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(292, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(257, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Don\'t have an account? Click";
            // 
            // lblRegister
            // 
            this.lblRegister.AutoSize = true;
            this.lblRegister.ForeColor = System.Drawing.Color.Red;
            this.lblRegister.Location = new System.Drawing.Point(453, 224);
            this.lblRegister.Name = "lblRegister";
            this.lblRegister.Size = new System.Drawing.Size(75, 24);
            this.lblRegister.TabIndex = 9;
            this.lblRegister.Text = "register";
            this.lblRegister.Click += new System.EventHandler(this.lblRegister_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(497, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "to";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(292, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 24);
            this.label6.TabIndex = 11;
            this.label6.Text = "create an account.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(411, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "Forgot Password?";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(295, 84);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(295, 131);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(26, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Moccasin;
            this.btnExit.Location = new System.Drawing.Point(349, 291);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(106, 23);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(514, 326);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblRegister);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.chkShowHide);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblClear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkOrange;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblClear;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkShowHide;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRegister;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnExit;
    }
}

// Customer Details
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
    public partial class CustomerDetails : Form
    {
        public CustomerDetails()
        {
            InitializeComponent();
        }
        DataTable table = new DataTable();//Displays The table in the DataGridView

        private void button2_Click(object sender, EventArgs e)//when this button is clicked the admin landing page shows up and this form hides
        {
            Admin Ad = new Admin();
            Ad.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string[] lines = File.ReadAllLines(@"E:\FinalVersion2019\RegistrationDetails.txt");//location a text file
            string[] values;
            // Getting data from a text file to be displayed in the datagridviiew and store and displayes it accoring to the table format/ layout
            for (int i = 0; i < lines.Length; i++)//for loop
            {
                values = lines[i].ToString().Split('\t');
                String[] row = new string[values.Length];
                for (int j = 0; j < values.Length; j++)
                {
                    row[j] = values[j].Trim();

                }
                table.Rows.Add(row);
            }
        }

        private void CustomerDetails_Load(object sender, EventArgs e)
        {
            //Adding colomns to  a datagridview table
            table.Columns.Add("Name", typeof(string));//adding the Name coloum to the table that store intergers only
            table.Columns.Add("Surname", typeof(string));//adding the Surname coloum to the table that store intergers only
            table.Columns.Add("ID", typeof(double ));//adding the ID coloum to the table that store intergers only
            table.Columns.Add("Gender", typeof(string));//adding the gENDER coloum to the table that store intergers only
            table.Columns.Add("Cellphone Number", typeof(double));//adding the cELLPHONE NUMBER coloum to the table that store intergers only
            table.Columns.Add("Email Address", typeof(string));//adding the EMAIL ADDRESS coloum to the table that store intergers only
            table.Columns.Add("Username", typeof(string));//adding the uSERNAME coloum to the table that store intergers only
            table.Columns.Add("Password", typeof(string));//adding the pASSWORD coloum to the table that store intergers only

            dataGridView1.DataSource = table;//Gets the data thatthe datagrid view will display
        }
    }
    
}

// Customer Details Designer

namespace FinalVersion
{
    partial class CustomerDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Highlight;
            this.button2.Location = new System.Drawing.Point(255, 464);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(173, 47);
            this.button2.TabIndex = 4;
            this.button2.Text = "EXIT";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.Location = new System.Drawing.Point(13, 94);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(673, 364);
            this.dataGridView1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.Location = new System.Drawing.Point(204, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(287, 55);
            this.button1.TabIndex = 6;
            this.button1.Text = "View Registered Customers";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CustomerDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(698, 523);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Font = new System.Drawing.Font("Lucida Sans Typewriter", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CustomerDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomerDetails";
            this.Load += new System.EventHandler(this.CustomerDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
    }
}

// Current Bookings
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalVersion
{
    public partial class CurrentBookings : Form
    {
        public CurrentBookings()
        {
            InitializeComponent();
        }
        DataTable table = new DataTable();//Displays The table in the DataGridView

        private void button3_Click(object sender, EventArgs e)
        {
            Admin Adm = new Admin();
            Adm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(@"E:\FinalVersion2019\Current Bookings.txt");//location a text file
            string[] values;
            // Getting data from a text file to be displayed in the datagridviiew and store and displayes it accoring to the table format/ layout
            for (int i = 0; i < lines.Length; i++)//for loop
            {
                values = lines[i].ToString().Split('\t');
                String[] row = new string[values.Length];
                for (int j = 0; j < values.Length; j++)
                {
                    row[j] = values[j].Trim();

                }
                table.Rows.Add(row);
            }
        }

        private void CurrentBookings_Load(object sender, EventArgs e)
        {
            //Adding colomns to  a datagridview table
            table.Columns.Add("Username", typeof(string));//adding the Name coloum to the table that store intergers only
            table.Columns.Add("Location", typeof(string));//adding the Surname coloum to the table that store intergers only
            table.Columns.Add("Car", typeof(string));
            table.Columns.Add("StartDate", typeof(string));//adding the ID coloum to the table that store intergers only
            table.Columns.Add("EndDate", typeof(string));//adding the gENDER coloum to the table that store intergers only
            table.Columns.Add("CarColor", typeof(string));//adding the cELLPHONE NUMBER coloum to the table that store intergers only
            table.Columns.Add("GearType", typeof(string));//adding the EMAIL ADDRESS coloum to the table that store intergers only
            table.Columns.Add("CarCost", typeof(string));//adding the uSERNAME coloum to the table that store intergers only
            table.Columns.Add("ExtrasCost", typeof(string));//adding the pASSWORD coloum to the table that store intergers only
            table.Columns.Add("TotalCost", typeof(string));
            dataGridView1.DataSource = table;//Gets the data thatthe datagrid view will display
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowIndex);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CardDetails Cd = new CardDetails();
            Cd.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

// Current Bookings Designer

namespace FinalVersion
{
    partial class CurrentBookings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 68);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(796, 278);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.Location = new System.Drawing.Point(687, 364);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 43);
            this.button1.TabIndex = 1;
            this.button1.Text = "VIEW BOOKINGS";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Highlight;
            this.button2.Location = new System.Drawing.Point(158, 364);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 43);
            this.button2.TabIndex = 2;
            this.button2.Text = "REMOVE";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.Highlight;
            this.button3.Location = new System.Drawing.Point(25, 364);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 43);
            this.button3.TabIndex = 3;
            this.button3.Text = "DONE";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.Highlight;
            this.button4.Location = new System.Drawing.Point(553, 366);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(129, 41);
            this.button4.TabIndex = 4;
            this.button4.Text = "VIEW CARD DETAILS";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(335, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Remove all bookings of customers that did not meet the requirements.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(22, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "*Please NOTE*:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(326, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "CURRENT BOOKINGS";
            // 
            // CurrentBookings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(847, 418);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CurrentBookings";
            this.Text = "CurrentBookings";
            this.Load += new System.EventHandler(this.CurrentBookings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

// Checkout
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

// Checkout Designer

namespace FinalVersion
{
    partial class Checkout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Checkout));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtCellNumber = new System.Windows.Forms.TextBox();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.txtCardHolderName = new System.Windows.Forms.TextBox();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.txtExpiryDate = new System.Windows.Forms.TextBox();
            this.txtCVV = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Cellphone Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter email address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(12, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Please note we only accept:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(12, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cardholder Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(12, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Enter Card Number:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label6.Location = new System.Drawing.Point(176, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "CVV:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label7.Location = new System.Drawing.Point(12, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Expiry Date:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 125);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(62, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(97, 125);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(62, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(179, 125);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(62, 35);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // txtCellNumber
            // 
            this.txtCellNumber.Location = new System.Drawing.Point(167, 19);
            this.txtCellNumber.Name = "txtCellNumber";
            this.txtCellNumber.Size = new System.Drawing.Size(167, 24);
            this.txtCellNumber.TabIndex = 11;
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Location = new System.Drawing.Point(167, 51);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(167, 24);
            this.txtEmailAddress.TabIndex = 12;
            // 
            // txtCardHolderName
            // 
            this.txtCardHolderName.Location = new System.Drawing.Point(150, 179);
            this.txtCardHolderName.Name = "txtCardHolderName";
            this.txtCardHolderName.Size = new System.Drawing.Size(184, 24);
            this.txtCardHolderName.TabIndex = 13;
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.Location = new System.Drawing.Point(150, 213);
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(184, 24);
            this.txtCardNumber.TabIndex = 14;
            // 
            // txtExpiryDate
            // 
            this.txtExpiryDate.Location = new System.Drawing.Point(10, 278);
            this.txtExpiryDate.Name = "txtExpiryDate";
            this.txtExpiryDate.Size = new System.Drawing.Size(155, 24);
            this.txtExpiryDate.TabIndex = 15;
            // 
            // txtCVV
            // 
            this.txtCVV.Location = new System.Drawing.Point(179, 278);
            this.txtCVV.Name = "txtCVV";
            this.txtCVV.Size = new System.Drawing.Size(155, 24);
            this.txtCVV.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Location = new System.Drawing.Point(12, 321);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 28);
            this.button1.TabIndex = 18;
            this.button1.Text = "BACK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button2.Location = new System.Drawing.Point(124, 321);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 28);
            this.button2.TabIndex = 19;
            this.button2.Text = "RESET";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Location = new System.Drawing.Point(242, 321);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 28);
            this.button3.TabIndex = 20;
            this.button3.Text = "PROCEED";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Checkout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(360, 356);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtCVV);
            this.Controls.Add(this.txtExpiryDate);
            this.Controls.Add(this.txtCardNumber);
            this.Controls.Add(this.txtCardHolderName);
            this.Controls.Add(this.txtEmailAddress);
            this.Controls.Add(this.txtCellNumber);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Checkout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Checkout";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox txtCellNumber;
        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.TextBox txtCardHolderName;
        private System.Windows.Forms.TextBox txtCardNumber;
        private System.Windows.Forms.TextBox txtExpiryDate;
        private System.Windows.Forms.TextBox txtCVV;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}
