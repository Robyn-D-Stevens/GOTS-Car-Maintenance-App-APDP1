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
    public partial class CarMaintainceManager : Form
    {
        public CarMaintainceManager()
        {
            InitializeComponent();
        }

        private void CarMaintainceManager_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string filename = @"E:\FinalVersion2019\InspectionReport.txt";
            StreamWriter objMM = new StreamWriter(filename);
            using (objMM)
            {
                string plateNum = txtPlateNum.Text;
                objMM.Write("Car Liscence Plate: " + plateNum + '\n');

                if (radNoDam.Checked)
                {
                    string NoDam = radNoDam.Text;
                    objMM.WriteLine("Is car damaged? " + NoDam + ". Car is in good condition");
                }
                else
                {
                    string YesDam = radYesDam.Text;
                    objMM.WriteLine("Is car damaged? " + YesDam + ". Car is damaged, damage is listed below.");

                    string carDam = txtCarDam.Text;
                    objMM.WriteLine("The damage on this car is: " + carDam + '\n' );
                }
                string estCost = txtEstimatedCost.Text;
                objMM.WriteLine(estCost);

                dateTimePicker1.Text = DateTime.Now.ToString();
                objMM.WriteLine(dateTimePicker1);
            }
            MessageBox.Show("Maintenance Details Recorded!", "SUCCESS!");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.dateTimePicker1.MinDate = System.DateTime.Now;
        }

        private void radYesDam_Enter(object sender, EventArgs e)
        {
            panDamage.Show();
            txtCarDam.Show();
            txtEstimatedCost.Show();
        }

        private void radNoDam_CheckedChanged(object sender, EventArgs e)
        {
            panDamage.Hide();
            txtCarDam.Hide();
            txtEstimatedCost.Hide();
        }

        private void txtPlateNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!char.IsLetterOrDigit(c) && c != 8 && c != 46)
            {
                e.Handled = true;
            }

            if (char.IsPunctuation(c))
            {
                MessageBox.Show("Please use digits and letters only");
            }

            if (char.IsSymbol(c))
            {
                MessageBox.Show("No Special characters allowed (,),@,%,!,*,#,$, etc.");
            }
        }

        private void txtPlateNum_Leave(object sender, EventArgs e)
        {
            if (txtPlateNum.MaxLength < 9)
            {
                MessageBox.Show("Maximum Input is 9 characters!", "Invalid Input!");
            }
        }

        private void txtPlateNum_Validating(object sender, CancelEventArgs e)
        {

            if (txtPlateNum.Text.Length > 9)
            {
                MessageBox.Show("Please input a valid Liscence Plate Number of 9 characters or less to continue!", "Error!");
                btnSubmit.Hide();
            }
            else
            {
                btnSubmit.Show();
            }
        }

        private void txtPlateNum_Validated(object sender, EventArgs e)
        {
            MessageBox.Show("After Inputing a valid License Plate Number, carry on filling form values for 'Submit' button to display in order to record details for administrator", "NOTE!");
        }
    }
}
