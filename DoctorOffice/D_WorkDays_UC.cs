using BLL;
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

namespace DoctorOffice
{
    public partial class D_WorkDays_UC : UserControl
    {
        public D_WorkDays_UC()
        {
            InitializeComponent();
        }

        Doctor_BLL doctor_bll = new Doctor_BLL();
        WorkDay_BLL workday_bll = new WorkDay_BLL();
        public Doctor d;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox8.Enabled = true;
                textBox9.Enabled = true;
            }
            else
            {
                textBox8.Enabled = false;
                textBox9.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox10.Enabled = true;
                textBox11.Enabled = true;
            }
            else
            {
                textBox10.Enabled = false;
                textBox11.Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                textBox12.Enabled = true;
                textBox13.Enabled = true;
            }
            else
            {
                textBox12.Enabled = false;
                textBox13.Enabled = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                textBox14.Enabled = true;
                textBox20.Enabled = true;
            }
            else
            {
                textBox14.Enabled = false;
                textBox20.Enabled = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                textBox16.Enabled = true;
                textBox17.Enabled = true;
            }
            else
            {
                textBox16.Enabled = false;
                textBox17.Enabled = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                textBox18.Enabled = true;
                textBox19.Enabled = true;
            }
            else
            {
                textBox18.Enabled = false;
                textBox19.Enabled = false;
            }
        }

        private void CheckWorkDays()
        {
            if (checkBox1.Checked)
            {
                WorkDay w = new WorkDay();
                w.Day = "شنبه";
                w.From = textBox8.Text;
                w.Until = textBox9.Text;
                workday_bll.create(w, d.id);
            }
            if (checkBox2.Checked)
            {
                WorkDay w = new WorkDay();
                w.Day = "یکشنبه";
                w.From = textBox10.Text;
                w.Until = textBox11.Text;
                workday_bll.create(w, d.id);
            }
            if (checkBox3.Checked)
            {
                WorkDay w = new WorkDay();
                w.Day = "دوشنبه";
                w.From = textBox12.Text;
                w.Until = textBox13.Text;
                workday_bll.create(w, d.id);
            }
            if (checkBox4.Checked)
            {
                WorkDay w = new WorkDay();
                w.Day = "سه شنبه";
                w.From = textBox14.Text;
                w.Until = textBox20.Text;
                workday_bll.create(w, d.id);
            }
            if (checkBox5.Checked)
            {
                WorkDay w = new WorkDay();
                w.Day = "چهارشنبه";
                w.From = textBox16.Text;
                w.Until = textBox17.Text;
                workday_bll.create(w, d.id);
            }
            if (checkBox6.Checked)
            {
                WorkDay w = new WorkDay();
                w.Day = "پنجشمبه";
                w.From = textBox18.Text;
                w.Until = textBox19.Text;
                workday_bll.create(w, d.id);
            }
        }

        private void Add_WorkDays()
        {
            List<WorkDay> workdays = new List<WorkDay>();
            workdays = doctor_bll.Doctor_WorkDays(d.id);

            foreach (var item in workdays)
            {
                if (item.Day == "شنبه")
                {
                    checkBox1.Checked = true;
                    textBox8.Text = item.From;
                    textBox9.Text = item.Until;
                }
                else if (item.Day == "یکشنبه")
                {
                    checkBox2.Checked = true;
                    textBox10.Text = item.From;
                    textBox11.Text = item.Until;
                }
                else if (item.Day == "دوشنبه")
                {
                    checkBox3.Checked = true;
                    textBox12.Text = item.From;
                    textBox13.Text = item.Until;
                }
                else if (item.Day == "سه شنبه")
                {
                    checkBox4.Checked = true;
                    textBox14.Text = item.From;
                    textBox20.Text = item.Until;
                }
                else if (item.Day == "چهارشنبه")
                {
                    checkBox5.Checked = true;
                    textBox16.Text = item.From;
                    textBox17.Text = item.Until;
                }
                else if (item.Day == "پنج شنبه")
                {
                    checkBox6.Checked = true;
                    textBox18.Text = item.From;
                    textBox19.Text = item.Until;
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            workday_bll.Delete(d.id);
            CheckWorkDays();
        }

        private void D_WorkDays_UC_Load(object sender, EventArgs e)
        {
            Add_WorkDays();
        }
    }
}
