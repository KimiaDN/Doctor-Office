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
using BE;
using Stimulsoft.Report;

namespace DoctorOffice
{
    public partial class Visits_UC : UserControl
    {
        public Visits_UC()
        {
            InitializeComponent();
        }

        
        Patient_BLL patient_bll = new Patient_BLL();
        Visit_BLL visit_bll = new Visit_BLL();

        public Patient p;
        Visit v = new Visit();
        MSG msg = new MSG();

        private void Clear()
        {
            textBox1.Text = "";
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            richTextBox3.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            v.Title = textBox1.Text;
            v.PatientSigns = richTextBox1.Text;
            v.DoctorIdea = richTextBox2.Text;
            v.Drugs = richTextBox3.Text;
            v.RegDate = dateTimePicker1.Value.Date;

            string str = visit_bll.Create(v, p.id);
            msg.Show( str, false);
            Clear();

            p.Visits.Add(v);
            patient_bll.Update(p.id, p);


        }
    }
}
