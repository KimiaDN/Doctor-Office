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
using System.IO;

namespace DoctorOffice
{
    public partial class D_PersonalInfo_UC : UserControl
    {
        public D_PersonalInfo_UC()
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

        private void D_PersonalInfo_UC_Load(object sender, EventArgs e)
        {
            textBox1.Text = d.Name;
            textBox2.Text = d.Phone;
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
            d.UserName = textBox3.Text;
            d.Cart = textBox7.Text;
            d.RegDate = DateTime.Now;
            //d.Picture = Save_Picture(textBox3.Text);
            // if accountant is not null we should add it

            if (textBox4.Text == textBox5.Text)
            {
                d.Password = textBox5.Text;
            }


            MSG msg = new MSG();
            if (check)
            {
                string str = doctor_bll.Update(d, d.id);
                msg.Show(str, false);
            }
        }
    }
}
