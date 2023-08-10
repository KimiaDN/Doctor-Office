using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using Stimulsoft.Report;

namespace DoctorOffice
{
    public partial class PatientHome : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
         (
             int nLeftRect,     // x-coordinate of upper-left corner
             int nTopRect,      // y-coordinate of upper-left corner
             int nRightRect,    // x-coordinate of lower-right corner
             int nBottomRect,   // y-coordinate of lower-right corner
             int nWidthEllipse, // width of ellipse
             int nHeightEllipse // height of ellipse
         );
        public PatientHome()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 40, 40));
        }

        public Patient p;
        public User user;
        Patient_BLL bll = new Patient_BLL();
        User_BLL user_bll = new User_BLL();
        MSG msg = new MSG();
        private void button1_Click(object sender, EventArgs e)
        {
            if (user_bll.Access(user, 3, 1))
            {
                Visits_UC visits = new Visits_UC();
                visits.p = p;
                if (panel2.Controls.Count > 0)
                {
                    panel2.Controls[0].Dispose();
                }
                panel2.Controls.Add(visits);
            }
            else
            {
                msg.Show("ورود به این بخش مجاز نمی باشد", false);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PatientVisits_Load(object sender, EventArgs e)
        {
            label2.Text = p.Name;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (user_bll.Access(user, 4, 1))
            {
                VisitsHistory_UC history = new VisitsHistory_UC();
                history.p = p;
                history.user = user;
                if (panel2.Controls.Count > 0)
                {
                    panel2.Controls[0].Dispose();
                }
                panel2.Controls.Add(history);
            }
            else
            {
                msg.Show("ورود به این بخش مجاز نمی باشد", false);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (user_bll.Access(user, 5, 1))
            {
                Tests_UC test = new Tests_UC();
                test.p = p;
                test.user = user;
                if (panel2.Controls.Count > 0)
                {
                    panel2.Controls[0].Dispose();
                }
                panel2.Controls.Add(test);
            }
            else
            {
                msg.Show("ورود به این بخش مجاز نمی باشد", false);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (user_bll.Access(user, 6, 1))
            {
                Debt_UC debt = new Debt_UC();
                debt.p = p;
                if (panel2.Controls.Count > 0)
                {
                    panel2.Controls[0].Dispose();
                }
                panel2.Controls.Add(debt);
            }
            else
            {
                msg.Show("ورود به این بخش مجاز نمی باشد", false);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (user_bll.Access(user, 4, 1))
            {
                StiReport sti = new StiReport();
                List<Visit> visits = new List<Visit>();
                visits = bll.Read_Visit(p.id);
                sti.Load(@"D:\C#\DoctorOffice\PatientVisitsReport.mrt");
                sti.Dictionary.Variables["FileNum"].Value = p.Code;
                sti.Dictionary.Variables["DoctorName"].Value = p.doctor.Name;
                sti.Dictionary.Variables["PatientName"].Value = p.Name;
                sti.Dictionary.Variables["Code"].Value = p.Credit;
                sti.Dictionary.Variables["Date"].Value = p.RegDate.ToString();
                sti.Dictionary.Variables["PhoneNum"].Value = p.Phone;

                sti.RegBusinessObject("PstientVisits", visits);
                MessageBox.Show(visits.Count.ToString());
                sti.Render();
                sti.Show();
            }
            else
            {
                msg.Show("ورود به این بخش مجاز نمی باشد", false);
            }

        }
    }
}
