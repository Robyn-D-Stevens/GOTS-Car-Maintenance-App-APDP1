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
