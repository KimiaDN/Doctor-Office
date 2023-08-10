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
using DevComponents.DotNetBar.Controls;

namespace DoctorOffice
{
    public partial class SecretaryForm_UC : UserControl
    {
        public SecretaryForm_UC()
        {
            InitializeComponent();
        }

        Secretary_BLL secrerary_bll = new Secretary_BLL();
        Doctor_BLL doctor_bll = new Doctor_BLL();
        UserGroup_BLL ug_bll = new UserGroup_BLL();
        OpenFileDialog opd = new OpenFileDialog();
        Image pic;
        bool check = true;
        Doctor d;
        int id;


        private void Fill_DataGrid_View()
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = secrerary_bll.Read();

            dataGridViewX1.Columns["id"].Visible = false;
            dataGridViewX1.Columns["DeleteStatus"].Visible = false;
            dataGridViewX1.Columns["Discriminator"].Visible = false;

        }

        private void Clean()
        {
            textBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            numericUpDown1.Value = 30;
            pictureBox1.Image = Properties.Resources.add_user;
        }

        private string Save_Picture(string code)
        {
            check = false;
            string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\SecretariesPic\";
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Secretary s = new Secretary();
            s.Name = textBox1.Text;
            s.Age =Convert.ToInt32(numericUpDown1.Value);
            s.Phone = textBox2.Text;
            s.UserName = textBox3.Text;
            s.Cart = textBox7.Text;
            s.RegDate = DateTime.Now;
            s.Education = textBox8.Text;
            UserGroup ug = ug_bll.Find_ByName(comboBox1.Text);
            //s.Picture = Save_Picture(textBox3.Text);
            if (textBox4.Text == textBox5.Text)
            {
                s.Password = textBox5.Text;
            }
            if (textBox6.Text != "")
            {
                d = doctor_bll.find_ByName(textBox6.Text);
                d.SecretaryName = textBox6.Text;
                doctor_bll.Update(d, d.id);
            }


            MSG msg = new MSG();
            if (check)
            {
                if (label10.Text == "ثبت اطلاعات")
                {
                    string str = secrerary_bll.Create(s, d.id, ug.id);
                    msg.Show(str, false);
                }
                else if (label10.Text == "ویرایش اطلاعات")
                {
                    s.doctor = d;
                    string str = secrerary_bll.Update(s, id);
                    label10.Text = "ثبت اطلاعات";
                }

                Fill_DataGrid_View();
                Clean();
            }
            
        }

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

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = secrerary_bll.Search(textBox14.Text);


            dataGridViewX1.Columns["id"].Visible = false;
            dataGridViewX1.Columns["DeleteStatus"].Visible = false;
            dataGridViewX1.Columns["Discriminator"].Visible = false;
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt16(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells["id"].Value.ToString());
            Secretary s = secrerary_bll.Find(id);

            textBox1.Text = s.Name;
            textBox2.Text = s.Phone;
            textBox3.Text = s.UserName;
            textBox6.Text = s.doctor.Name;
            textBox7.Text = s.Cart;
            textBox8.Text = s.Education;
            numericUpDown1.Value = Convert.ToDecimal(s.Age);
            pictureBox1.Image = Image.FromFile(s.Picture);

            label10.Text = "ویرایش اطلاعات";
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt16(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells["id"].Value.ToString());
            MSG msg = new MSG();
            DialogResult dr = msg.Show("آیا از حذف منشی اطمینان دارید ؟", true);
            if (dr == DialogResult.Yes)
            {
                string str = secrerary_bll.Delete(id);
                msg.Show(str, false);
            }

            Fill_DataGrid_View();
        }

        private void مشاهدهجزئیاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt16(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells["id"].Value.ToString());
            Secretary s = secrerary_bll.Find(id);
            SecretaryHome securatyHome = new SecretaryHome();
            securatyHome.s = s;
            securatyHome.ShowDialog();
        }

        private void SecretaryForm_UC_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection names = new AutoCompleteStringCollection();
            foreach (var item in doctor_bll.Read_ByNames())
            {
                names.Add(item);
            }

            foreach (var item in ug_bll.Read_ByName())
            {
                comboBox1.Items.Add(item);
            }
            textBox6.AutoCompleteCustomSource = names;
            Fill_DataGrid_View();
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
        }
    }
}
