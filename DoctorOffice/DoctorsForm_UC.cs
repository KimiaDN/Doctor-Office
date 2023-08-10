using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace DoctorOffice
{
    public partial class DoctorsForm_UC : UserControl
    {
        public DoctorsForm_UC()
        {
            InitializeComponent();
        }

        Doctor_BLL doctor_bll = new Doctor_BLL();
        UserGroup_BLL usergroup_bll = new UserGroup_BLL();
        Secretary_BLL secretary_bll = new Secretary_BLL();
        UserGroup_BLL ug_bll = new UserGroup_BLL();
        OpenFileDialog opd = new OpenFileDialog();
        Image pic;
        bool check = true;
        int id;

        private void Fill_DataGridView()
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = doctor_bll.Read();

            dataGridViewX1.Columns["id"].Visible = false;
            dataGridViewX1.Columns["DeleteStatus"].Visible = false;
            dataGridViewX1.Columns["Discriminator"].Visible = false;
        }

        private void Clean()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.Text = null;
            numericUpDown1.Value = Convert.ToDecimal(numericUpDown1.Minimum.ToString());
            pictureBox1.Image = Properties.Resources.add_image;
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
                msg.Show( "سیستم قادر به ذخیره عکس نمی باشد\n" + e.Message, false);
            }
            
            return path + PicName;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Doctor d = new Doctor();
            UserGroup ug = new UserGroup();
            d.Name = textBox1.Text;
            d.Age = Convert.ToInt32(numericUpDown1.Value);
            d.Phone = textBox2.Text;
            d.Speciality = comboBox1.Text;
            d.UserName = textBox3.Text;
            d.Cart = textBox7.Text;
            d.Picture = Save_Picture(textBox3.Text);
            d.RegDate = DateTime.Now;
            d.SecretaryName = textBox6.Text;
            ug = usergroup_bll.Find_ByName(comboBox2.Text);
            if (textBox4.Text == textBox5.Text)
            {
                d.Password = textBox5.Text;
            }
            
            

            MSG msg = new MSG();
            if (check)
            {
                if (label10.Text == "ثبت اطلاعات")
                {
                    string str = doctor_bll.Create(d, ug.id);
                    msg.Show( str, false);
                }
                else if (label10.Text == "ویرایش اطلاعات")
                {
                    string str = doctor_bll.Update(d, id);
                    msg.Show( str, false);
                    label10.Text = "ثبت اطلاعات";
                }
            }

            Fill_DataGridView();
            Clean();
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells["id"].Value.ToString());
            Doctor d = doctor_bll.find(id);

            textBox1.Text = d.Name;
            textBox2.Text = d.Phone;
            textBox3.Text = d.UserName;
            textBox6.Text = d.SecretaryName;
            textBox7.Text = d.Cart;
            comboBox1.Text = d.Speciality;
            numericUpDown1.Value = Convert.ToDecimal(d.Age);
            pictureBox1.Image = Image.FromFile(d.Picture);

            label10.Text = "ویرایش اطلاعات";
        }

        private void مشاهدهجزئیاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells["id"].Value.ToString());
            Doctor d = doctor_bll.find(id);
            DoctorHome home = new DoctorHome();
            home.d = d;
            home.ShowDialog();
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells["id"].Value.ToString());
            MSG msg = new MSG();
            DialogResult dr = msg.Show("آیا از حذف پزشک اطمینان دارید ؟", true);
            if (dr == DialogResult.Yes)
            {
                string str = doctor_bll.Delete(id);
                msg.Show( str, false);
            }

            Fill_DataGridView();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = doctor_bll.Search(textBox14.Text);

            dataGridViewX1.Columns["id"].Visible = false;
            dataGridViewX1.Columns["DeleteStatus"].Visible = false;
            dataGridViewX1.Columns["Discriminator"].Visible = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MSG msg = new MSG();
                msg.Show( "لطفا فقط حروف وارد کنید", false);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MSG msg = new MSG();
                msg.Show( "لطفا فقط عدد وارد کنید", false);
            }
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MSG msg = new MSG();
                msg.Show( "لطفا فقط عدد وارد کنید", false);
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MSG msg = new MSG();
                msg.Show( "لطفا فقط عدد وارد کنید", false);
            }
        }

        private void DoctorsForm_UC_Load(object sender, EventArgs e)
        {
            Fill_DataGridView();
            AutoCompleteStringCollection names = new AutoCompleteStringCollection();
            foreach (var item in secretary_bll.Read_ByName())
            {
                names.Add(item);
            }
            textBox6.AutoCompleteCustomSource = names;

            foreach (var item in ug_bll.Read_ByName())
            {
                comboBox2.Items.Add(item);
            }


        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
        }
    }
}
