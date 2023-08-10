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
    public partial class PatientForm_UC : UserControl
    {
        public PatientForm_UC()
        {
            InitializeComponent();
        }

        public User user;
        Patient_BLL patient_bll = new Patient_BLL();
        Doctor_BLL doctor_bll = new Doctor_BLL();
        Doctor d = new Doctor();
        OpenFileDialog opd = new OpenFileDialog();
        Image pic;
        int id;

        public void Fill_DataFridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = patient_bll.Read();
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["DeleteStatus"].Visible = false;
        }

        public void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            comboBox1.Text = "";
            pictureBox1.Image = null;
            textBox2.Enabled = false;
        }

        public bool check()
        {
            if (textBox1.Text == "" || textBox7.Text == "" || textBox8.Text == "")
            {
                MSG msg = new MSG();
                msg.Show( "فیلد های نام، شماره تماس و کد ملی نباید خالی باشند", false);
                return false;
            }
            return true;
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
            string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\PatientsPic\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string PicName = code + ".JPG";
            try
            {
                string PicPath = opd.FileName;
                System.IO.File.Copy(PicPath, path + PicName, true);
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
            if (check())
            {
                Patient p = new Patient();
                p.Code = textBox1.Text;
                p.Name = textBox1.Text;
                p.Age = Convert.ToInt32(textBox4.Text);
                p.Credit = textBox7.Text;
                p.Code = textBox7.Text;
                p.Phone = textBox8.Text;
                p.Picture = Save_Picture(textBox1.Text);
                p.RegDate = DateTime.Now;

                if (textBox6.Text != "")
                {
                    d = doctor_bll.find_ByName(textBox6.Text);
                }

                if (radioButton1.Checked)
                {
                    p.Gender = false;
                }
                else if (radioButton2.Checked)
                {
                    p.Gender = true;
                }

                if (comboBox1.Text == "بیمه تامین اجتماعی")
                {
                    p.Insurance = InsuranceType.TaminEjtemaee;
                }
                else if (comboBox1.Text == "بیمه نیرو های مسلح")
                {
                    p.Insurance = InsuranceType.NiroohayeMosallah;
                }
                else if (comboBox1.Text == "بیمه سلامت")
                {
                    p.Insurance = InsuranceType.Salamat;
                }
                else
                {
                    p.Insurance = InsuranceType.NoOne;
                }

                if (label1.Text == "ثبت اطلاعات")
                {
                    string str = patient_bll.Create(p, d.id);
                    MSG msg = new MSG();
                    msg.Show( " شماره پرونده : \n" + p.Code + str, false);
                }
                else if (label1.Text == "ویرایش اطلاعات")
                {
                    p.doctor = d;
                    string str = patient_bll.Update(id, p);
                    MSG msg = new MSG();
                    msg.Show( str, false);
                    label1.Text = "ثیت اطلاعات";
                }
            }


            Clear();
            Fill_DataFridView();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void مشاهدهجزئیاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt16(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value.ToString());
            Patient p = patient_bll.Find(id);
            PatientHome visits = new PatientHome();
            visits.user = user;
            visits.p = p;
            visits.ShowDialog();
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt16(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value.ToString());
            Patient p = patient_bll.Find(id);

            textBox1.Text = p.Name;
            textBox2.Text = p.Code;
            textBox4.Text = p.Age.ToString();
            if (p.doctor != null)
            {
                textBox6.Text = p.doctor.Name;
            }
            textBox7.Text = p.Credit;
            textBox8.Text = p.Phone;
            pictureBox1.Image = Image.FromFile(p.Picture);
            if (p.Gender)
            {
                radioButton2.Checked = true;
            }
            else
            {
                radioButton1.Checked = true;
            }

            if (p.Insurance == InsuranceType.TaminEjtemaee)
            {
                comboBox1.Text = "بیمه تامین اجتماعی";
            }
            else if (p.Insurance == InsuranceType.Salamat)
            {
                comboBox1.Text = "بیمه سلامت";
            }
            else if (p.Insurance == InsuranceType.NiroohayeMosallah)
            {
                comboBox1.Text = "بیمه خدمات درمانی";
            }
            else
            {
                comboBox1.Text = "فاقد بیمه";
            }

            label1.Text = "ویرایش اطلاعات";
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt16(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value.ToString());
            MSG msg = new MSG();
            DialogResult dr = msg.Show("آیا از حذف بیمار اطمینان دارید ؟", true);
            if (dr == DialogResult.Yes)
            {
                string str = patient_bll.Delete(id);
                msg.Show( str, false);
            }
            Fill_DataFridView();
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = patient_bll.Search(textBox16.Text);
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["DeleteStatus"].Visible = false;
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MSG msg = new MSG();
                msg.Show( "لطفا فقط عدد وارد کنید", false);
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
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

        private void PatientForm_UC_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection names = new AutoCompleteStringCollection();
            foreach (var item in doctor_bll.Read_ByNames())
            {
                names.Add(item);
            }
            textBox6.AutoCompleteCustomSource = names;
            Fill_DataFridView();
        }
    }
}
