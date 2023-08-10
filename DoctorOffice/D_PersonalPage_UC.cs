using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace DoctorOffice
{
    public partial class D_PersonalPage_UC : UserControl
    {
        public D_PersonalPage_UC()
        {
            InitializeComponent();
        }

        Doctor_BLL doctor_bll = new Doctor_BLL();
        WorkDay_BLL workday_bll = new WorkDay_BLL();
        OpenFileDialog opd = new OpenFileDialog();
        Image pic;
        public Doctor d;
        bool check = true;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            opd.Filter = "JPG(*.JPG)|*.JPG";
            opd.Title = "نصویر کاربر خود را انتخاب کنید";
            if (opd.ShowDialog() == DialogResult.OK)
            {
                pic = Image.FromFile(opd.FileName);
                pictureBox1.Image = pic;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private string Save_Picture(string code)
        {
            check = false;
            string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\DoctorsPic\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string PicName = code + ".jpg";
            try
            {
                string PicPath = opd.FileName;
                System.IO.File.Copy(PicPath, path + PicName, true);
                check = true;
            }
            catch (Exception e)
            {
                MSG msg = new MSG();
                msg.Show("سیستم قادر به ذخیره عکس نمی باشد\n" + e.Message, false);
            }
            return path + PicName;
        }

        private void D_PersonalPage_UC_Load(object sender, EventArgs e)
        {
            textBox1.Text = d.Name;
            textBox2.Text = d.Phone;
            textBox15.Text = d.SpecialityNum;
            textBox3.Text = d.UserName;
            textBox7.Text = d.Cart;
            comboBox1.Text = d.Speciality;
            numericUpDown1.Value = Convert.ToDecimal(d.Age);
            pictureBox1.Image = Image.FromFile(d.Picture);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            d.Name = textBox1.Text;
            d.Age = Convert.ToInt32(numericUpDown1.Value);
            d.Phone = textBox2.Text;
            d.Speciality = comboBox1.Text;
            d.SpecialityNum = textBox15.Text;
            d.UserName = textBox3.Text;
            d.Cart = textBox7.Text;
            if (textBox4.Text == textBox5.Text)
            {
                d.Password = textBox5.Text;
            }
            d.Picture = Save_Picture(textBox3.Text);
            d.RegDate = DateTime.Now;

            List<WorkDay> list = new List<WorkDay>();
            list = CheckWorkDays();
            // if accountant is not null we should add it

            MSG msg = new MSG();
            if (check)
            {
                string str = doctor_bll.Update(d, d.id);
                msg.Show( str, false);
            }
        }

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

        private List<WorkDay> CheckWorkDays()
        {
            List<WorkDay> workDayList = new List<WorkDay>();
            if (checkBox1.Checked)
            {
                WorkDay w = new WorkDay();
                w.Day = "شنبه";
                w.From = textBox8.Text;
                w.Until = textBox9.Text;
                workday_bll.create(w, d.id);
                workDayList.Add(w);
            }
            else if (checkBox2.Checked)
            {
                WorkDay w = new WorkDay();
                w.Day = "یکشنبه";
                w.From = textBox10.Text;
                w.Until = textBox11.Text;
                workday_bll.create(w, d.id);
                workDayList.Add(w);
            }
            else if (checkBox3.Checked)
            {
                WorkDay w = new WorkDay();
                w.Day = "دوشنبع";
                w.From = textBox12.Text;
                w.Until = textBox13.Text;
                workday_bll.create(w, d.id);
                workDayList.Add(w);
            }
            else if (checkBox4.Checked)
            {
                WorkDay w = new WorkDay();
                w.Day = "سه شنبه";
                w.From = textBox14.Text;
                w.Until = textBox20.Text;
                workday_bll.create(w, d.id);
                workDayList.Add(w);
            }
            else if (checkBox5.Checked)
            {
                WorkDay w = new WorkDay();
                w.Day = "چهارشنبه";
                w.From = textBox16.Text;
                w.Until = textBox17.Text;
                workday_bll.create(w, d.id);
                workDayList.Add(w);
            }
            else if (checkBox6.Checked)
            {
                WorkDay w = new WorkDay();
                w.Day = "پنجشمبه";
                w.From = textBox18.Text;
                w.Until = textBox19.Text;
                workday_bll.create(w, d.id);
                workDayList.Add(w);
            }

            return workDayList;
        }
    }
}
