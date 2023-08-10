using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace DoctorOffice
{
    public partial class S_PersonalInfo_UC : UserControl
    {
        public S_PersonalInfo_UC()
        {
            InitializeComponent();
        }

        Secretary_BLL secretary_bll = new Secretary_BLL();
        Doctor_BLL doctor_bll = new Doctor_BLL();
        OpenFileDialog opd = new OpenFileDialog();
        Image pic;
        public Secretary s;
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

        private void S_PersonalInfo_UC_Load(object sender, EventArgs e)
        {
            textBox1.Text = s.Name;
            textBox2.Text = s.Phone;
            textBox15.Text = s.UserName;
            textBox5.Text = s.doctor.Name;
            textBox6.Text = s.Cart;
            numericUpDown1.Value = Convert.ToDecimal(s.Age);
            pictureBox1.Image = Image.FromFile(s.Picture);
            Add_WorkDays();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            s.Name = textBox1.Text;
            s.Age = Convert.ToInt32(numericUpDown1.Value);
            s.Phone = textBox2.Text;
            s.UserName = textBox15.Text;
            s.Cart = textBox6.Text;
            s.RegDate = DateTime.Now;
            s.doctor = doctor_bll.find_ByName(textBox5.Text);
            //d.Picture = Save_Picture(textBox3.Text);

            if (textBox3.Text == textBox4.Text)
            {
                s.Password = textBox3.Text;
            }


            MSG msg = new MSG();
            if (check)
            {
                string str = secretary_bll.Update(s, s.id);
                msg.Show(str, false);
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

        private void Add_WorkDays()
        {
            List<WorkDay> workdays = new List<WorkDay>();
            workdays = doctor_bll.Doctor_WorkDays(s.doctor.id);

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

       
    }
}
