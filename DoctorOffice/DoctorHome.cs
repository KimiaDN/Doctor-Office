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

namespace DoctorOffice
{
    public partial class DoctorHome : Form
    {
        public DoctorHome()
        {
            InitializeComponent();
        }

        public Doctor d;
        private void button1_Click(object sender, EventArgs e)
        {
           D_PersonalInfo_UC personal = new D_PersonalInfo_UC();
            personal.d = d;
            if (panel2.Controls.Count > 0)
            {
                panel2.Controls[0].Dispose();
            }
            panel2.Controls.Add(personal);
        }

        private void DoctorHome_Load(object sender, EventArgs e)
        {
            label2.Text = d.Name;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            D_PatientsList_UC patients = new D_PatientsList_UC();
            patients.d = d;
            if (panel2.Controls.Count > 0)
            {
                panel2.Controls[0].Dispose();
            }
            panel2.Controls.Add(patients);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Vacation_UC vacation = new Vacation_UC();
            vacation.DoctorOrSecretary = true;
            vacation.d = d;
            if (panel2.Controls.Count > 0)
            {
                panel2.Controls[0].Dispose();
            }
            panel2.Controls.Add(vacation);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            D_WorkDays_UC workdays = new D_WorkDays_UC();
            workdays.d = d;
            if (panel2.Controls.Count > 0)
            {
                panel2.Controls[0].Dispose();
            }
            panel2.Controls.Add(workdays);
        }
    }
}
