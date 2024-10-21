using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalVersion
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
       


        private void button1_Click(object sender, EventArgs e)
        {
            CustomerDetails CD = new CustomerDetails();
            CD.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CarRegistration CarRegister = new CarRegistration();
            CarRegister.Show();
            this.Hide();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
      


        }

        private void button4_Click(object sender, EventArgs e)
        {
            RentalDetails Rd = new RentalDetails();
            Rd.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MaintainaceFeedback mf = new MaintainaceFeedback();
            mf.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CurrentBookings Cb = new CurrentBookings();
            Cb.Show();
            this.Hide();
        }
    }
}
