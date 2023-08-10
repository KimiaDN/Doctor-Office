using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using Stimulsoft.Report;

namespace DoctorOffice
{
    public partial class VisitsHistory_UC : UserControl
    {
        public VisitsHistory_UC()
        {
            InitializeComponent();
        }

        public Patient p;
        public User user;
        Patient_BLL patient_bll = new Patient_BLL();
        Visit_BLL visit_bll = new Visit_BLL();
        User_BLL user_bll = new User_BLL();
        MSG msg = new MSG();
        int id;

        private void Fill_DataGridView()
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = patient_bll.Read_Visit(p.id);

            dataGridViewX1.Columns["id"].Visible = false;
            dataGridViewX1.Columns["RegDate"].Visible = false;
            dataGridViewX1.Columns["DeleteStatus"].Visible = false;
            dataGridViewX1.Columns["patient"].Visible = false;
            dataGridViewX1.Columns["Cost"].Visible = false;

            dataGridViewX1.Columns["Title"].HeaderText = "علت مراجعه";
            dataGridViewX1.Columns["PatientSigns"].HeaderText = "علائم بیمار";
            dataGridViewX1.Columns["DoctorIdea"].HeaderText = "نظر پزشک";
            dataGridViewX1.Columns["Drugs"].HeaderText = "نسخه";
            dataGridViewX1.Columns["IsPayed"].HeaderText = "وضعیت پرداخت";
        }

        private void Clean()
        {
            textBox1.Text = "";
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            richTextBox3.Text = "";
            dateTimePicker3.Value = DateTime.Now.Date;
        }

        private void VisitsHistory_UC_Load(object sender, EventArgs e)
        {
            
            Fill_DataGridView();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void مشاهدهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user_bll.Access(user, 4, 1))
            {
                id = Convert.ToInt16(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells["id"].Value.ToString());
                Visit v = visit_bll.Find(id);
                textBox1.Text = v.Title;
                dateTimePicker3.Value = v.RegDate;
                richTextBox1.Text = v.PatientSigns;
                richTextBox2.Text = v.DoctorIdea;
                richTextBox3.Text = v.Drugs;

                textBox1.Enabled = false;
                dateTimePicker1.Enabled = false;
                richTextBox1.Enabled = false;
                richTextBox2.Enabled = false;
                richTextBox3.Enabled = false;
            }
            else
            {
                msg.Show("ورود به این بخش مجاز نمی باشد", false);
            }
           

        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user_bll.Access(user, 4, 3))
            {
                id = Convert.ToInt16(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells["id"].Value.ToString());
                Visit v = visit_bll.Find(id);
                textBox1.Text = v.Title;
                dateTimePicker3.Value = v.RegDate;
                richTextBox1.Text = v.PatientSigns;
                richTextBox2.Text = v.DoctorIdea;
                richTextBox3.Text = v.Drugs;
            }
            else
            {
                msg.Show("ورود به این بخش مجاز نمی باشد", false);
            }

        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user_bll.Access(user, 4, 4))
            {
                id = Convert.ToInt16(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells["id"].Value.ToString());
                DialogResult dr = msg.Show("آیا از حذف ویزیت اطمینان دارید ؟", true);
                if (dr == DialogResult.Yes)
                {
                    string str = visit_bll.Delete(id);
                    msg.Show(str, false);
                }
                Fill_DataGridView();
            }
            else
            {
                msg.Show("ورود به این بخش مجاز نمی باشد", false);
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Visit v = new Visit();
            v.Title = textBox1.Text;
            v.RegDate = dateTimePicker3.Value.Date;
            v.PatientSigns = richTextBox1.Text;
            v.DoctorIdea = richTextBox2.Text;
            v.Drugs = richTextBox3.Text;

            string str = visit_bll.Update(v, id);
            msg.Show( str, false);

            Clean();

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            StiReport sti = new StiReport();
            Visit v = visit_bll.Find(id);
            sti.Load(@"D:\C#\DoctorOffice\PatientVisitReport.mrt");
            sti.Dictionary.Variables["FileNum"].Value = p.Code;
            sti.Dictionary.Variables["DoctorName"].Value = p.doctor.Name;
            sti.Dictionary.Variables["PatientName"].Value = p.Name;
            sti.Dictionary.Variables["Code"].Value = p.Credit;
            sti.Dictionary.Variables["Date"].Value = p.RegDate.ToString();
            sti.Dictionary.Variables["PhoneNum"].Value = p.Phone;
            sti.Dictionary.Variables["Title"].Value = v.Title;
            sti.Dictionary.Variables["PatientSign"].Value = v.PatientSigns;
            sti.Dictionary.Variables["DoctorIdea"].Value = v.DoctorIdea;
            sti.Dictionary.Variables["Drugs"].Value = v.Drugs;

            sti.Render();
            sti.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = visit_bll.Read(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date, p.id);


            dataGridViewX1.Columns["id"].Visible = false;
            dataGridViewX1.Columns["RegDate"].Visible = false;
            dataGridViewX1.Columns["DeleteStatus"].Visible = false;
            dataGridViewX1.Columns["patient"].Visible = false;

            dataGridViewX1.Columns["Title"].HeaderText = "علت مراجعه";
            dataGridViewX1.Columns["PatientSigns"].HeaderText = "علائم بیمار";
            dataGridViewX1.Columns["DoctorIdea"].HeaderText = "نظر پزشک";
            dataGridViewX1.Columns["Drugs"].HeaderText = "نسخه";
        }
    }
}
