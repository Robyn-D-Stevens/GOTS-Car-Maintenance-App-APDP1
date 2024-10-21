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
