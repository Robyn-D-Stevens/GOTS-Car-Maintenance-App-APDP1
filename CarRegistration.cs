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
    public partial class CarRegistration : Form
    {
        public CarRegistration()
        {
            InitializeComponent();
        }
        DataTable table = new DataTable();//Displays The table in the DataGridView
        private void btnSave_Click(object sender, EventArgs e)//Executes the code, Records data to a Textfile
        {
            if (string.IsNullOrWhiteSpace(txtCarCat.Text) || string.IsNullOrWhiteSpace(txtColor.Text) || string.IsNullOrWhiteSpace(txtLP.Text) || string.IsNullOrWhiteSpace(txtMake.Text) || string.IsNullOrWhiteSpace(txtGearType.Text))
            {
                MessageBox.Show("Fill in all empty spaces", "ERROR");
            }
            else 
            {
                string register = @"E:\FinalVersion2019\CarReg.txt";//Declaration of a variable that store the txext file location
                StreamWriter objSW = new StreamWriter(register);//wRITING TO A TEXT FILE METHOD
                using (objSW)//Construction automatically closes
                {
                    //declare variables
                    string Licensenum = txtLP.Text;//Gets or sets the input on the textbox
                    string CarMake = txtMake.Text;//Gets or sets the input on the textbox
                    string CarColor = txtColor.Text;//Gets or sets the input on the textbox
                    string CarCat = txtCarCat.Text;//Gets or sets the input on the textbox
                    string GearType = txtGearType.Text;//Gets or sets the input on the textbox
                                                       //Output
                    objSW.Write(Licensenum + "\t" + CarMake + '\t' + CarColor + '\t' + CarCat + '\t' + GearType);//Displays to a textfile


                }
                MessageBox.Show("Saved Successfully!", "Notification");
            }
            //A pop that displays what happended after the excecution on code
        }

        private void CarRegistration_Load(object sender, EventArgs e)
        {
            //Adding colomns to  a datagridview table
            table.Columns.Add("License Plate", typeof(int));//adding the License plate coloum to the table that store intergers only
            table.Columns.Add("Car Make", typeof(string));//adding the CarMake coloum to the table that store String only
            table.Columns.Add("Car Color", typeof(string));//adding the Car Color plate coloum to the table that store String only
            table.Columns.Add("Car Catergory", typeof(string));//adding the Car Catergory plate coloum to the table that store Strings only
            table.Columns.Add("Gear Type", typeof(string));//adding the Gear Type coloum to the table that store Strings only

            dataGridView1.DataSource = table;//Gets the data thatthe datagrid view will display
        }

        private void btnView_Click(object sender, EventArgs e)//excecutes the code when clicked 
        {
            string[] lines = File.ReadAllLines(@"E:\FinalVersion2019\CarReg.txt");//Location of a textfile 
            string[] values;
            //Getting data from a text file to be displayed in the datagridviiew and store and displayes it accoring to the table format/layout
            for(int i = 0; i< lines.Length; i++)//for loop
            {
                values = lines[i].ToString().Split('\t');
                String[] row = new string[values.Length];
                for(int j = 0; j < values.Length; j++)
                {
                    row[j] = values[j].Trim();

                }
                table.Rows.Add(row);
            }
        }

        private void button1_Click(object sender, EventArgs e)//When clicked take you back to the landing page
        {
            Admin Ad = new Admin();
            Ad.Show();
            this.Hide();//hides the current form


        }

        private void txtLP_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a letter
            if (!char.IsDigit (e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the key press if it is not a letter or a control character
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtMake_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a letter
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the key press if it is not a letter or a control character
                e.Handled = true;
            }
        }

        private void txtColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a letter
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the key press if it is not a letter or a control character
                e.Handled = true;
            }
        }

        private void txtGearType_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a letter
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the key press if it is not a letter or a control character
                e.Handled = true;
            }
        }

        private void txtCarCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a letter
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Cancel the key press if it is not a letter or a control character
                e.Handled = true;
            }
        }
    }
}
