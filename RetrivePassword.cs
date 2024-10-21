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
