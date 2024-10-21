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
