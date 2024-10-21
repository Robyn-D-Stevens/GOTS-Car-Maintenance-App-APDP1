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

