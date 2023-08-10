using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace DoctorOffice
{
    public partial class SecretaryHome : Form
    {
        public SecretaryHome()
        {
            InitializeComponent();
        }

        public Secretary s;
        private void button1_Click(object sender, EventArgs e)
        {
            S_PersonalInfo_UC personal = new S_PersonalInfo_UC();
            personal.s = s;
            if (panel2.Controls.Count > 0)
            {
                panel2.Controls[0].Dispose();
            }
            panel2.Controls.Add(personal);  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Vacation_UC vacation = new Vacation_UC();
            vacation.DoctorOrSecretary = false;
            vacation.s = s;
            if (panel2.Controls.Count > 0)
            {
                panel2.Controls[0].Dispose();
            }
            panel2.Controls.Add(vacation);
        }
    }

    
}
