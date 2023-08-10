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
using BLL;
using System.IO;

namespace DoctorOffice
{
    public partial class Tests_UC : UserControl
    {
        public Tests_UC()
        {
            InitializeComponent();
        }
        public Patient p;
        public User user;

        Test_BLL bll = new Test_BLL();
        User_BLL user_bll = new User_BLL();
        OpenFileDialog opd = new OpenFileDialog();
        MSG msg = new MSG();
        Image pic;
        bool check = false;    // this should change
        int id;

        private void Clean()
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox1.Text = "";
            richTextBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now.Date;
            dateTimePicker2.Value = DateTime.Now.Date;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            pictureBox1.Image = null;
        }

        private void Fill_DataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bll.Read();
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["DeleteStatus"].Visible = false;
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

        private string Save_Picture(string code, string count)
        {
            check = false;
            string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\TestsPic\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            count = count.Replace("/", string.Empty).Replace(" ", "-").Replace(":",string.Empty);
            string PicName = (code + "-" + count).Replace("/", "-").Replace(" ", String.Empty) + ".jpg";
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
            if (user_bll.Access(user, 5, 2))
            {
                Test t = new Test();
                t.Name = textBox1.Text;
                t.Type = comboBox1.Text;
                t.Info = richTextBox1.Text;
                t.RegDate = dateTimePicker1.Value.Date;
                t.Picture = Save_Picture(p.Code, dateTimePicker1.Value.ToString());
                if (label5.Text == "ثبت اطلاعات")
                {
                    if (check)
                    {
                        string str = bll.Create(t, p.id);
                        msg.Show(str, false);
                    }
                }
                else if (label5.Text == "ویرایش اطلاعات")
                {
                    if (check)
                    {
                        string str = bll.Update(t, id);
                        msg.Show(str, false);
                    }
                    label5.Text = "ثبت اطلاعات";
                }
                Fill_DataGridView();
                Clean();
            }
            else
            {
                msg.Show("ورود به این بخش مجاز نمی باشد", false);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void Tests_UC_Load(object sender, EventArgs e)
        {
            Fill_DataGridView();
        }

        private void مشاهدهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user_bll.Access(user,5, 3))
            {
                id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value.ToString());
                Test t = bll.Find(id);
                dateTimePicker1.Value = t.RegDate;
                comboBox1.Text = t.Type;
                textBox1.Text = t.Name;
                richTextBox1.Text = t.Info;
                pictureBox1.Image = Image.FromFile(t.Picture);

                label5.Text = "ویرایش اطلاعات";
            }
            else
            {
                msg.Show("ورود به این بخش مجاز نمی باشد", false);
            }
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user_bll.Access(user,5, 4))
            {
                id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value.ToString());
                DialogResult dr = msg.Show("آیا از حذف عکس اطمینان دارید ؟", true);
                if (dr == DialogResult.Yes)
                {
                    string str = bll.Delete(id);
                    msg.Show(str, false);
                }
                Fill_DataGridView();
            }
            else
            {
                msg.Show("ورود به این بخش مجاز نمی باشد", false);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bll.Search_ByDate(dateTimePicker2.Value.Date);
               
            }
            else if (radioButton2.Checked)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = bll.Search_ByType(comboBox2.Text);
            }
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["DeleteStatus"].Visible = false;
        }
    }
}
