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
