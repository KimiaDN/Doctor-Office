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
using System.Runtime.InteropServices;

namespace DoctorOffice
{
    public partial class PatientTurn : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // width of ellipse
           int nHeightEllipse // height of ellipse
       );
        public PatientTurn()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 40, 40));
        }

        public User user;
        User_BLL user_bll = new User_BLL();
        Secretary_BLL secretary_bll = new Secretary_BLL();
        Doctor_BLL doctor_bll = new Doctor_BLL();
        Turn_BLL turn_bll = new Turn_BLL();
        MSG msg = new MSG();

        int id;

        private void Clean()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            maskedTextBoxAdv1.Text = "";

        }

        private void  Fill_DataGridView()
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = turn_bll.Read(textBox4.Text, dateTimePicker4.Value.Date);

            dataGridViewX1.Columns["id"].Visible = false;
            dataGridViewX1.Columns["DeleteStatus"].Visible = false;
            dataGridViewX1.Columns["Date"].Visible = false;
            dataGridViewX1.Columns["DoctorName"].Visible = false;

            dataGridViewX1.Columns["PatientName"].HeaderText = "نام بیمار";
            dataGridViewX1.Columns["PatientPhone"].HeaderText = "شماره تماس";
            dataGridViewX1.Columns["Time"].HeaderText = "ساعت ویزیت";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PatientTurn_Load(object sender, EventArgs e)
        {
            if (user_bll.IsDoctor(user))
            {
                textBox3.Text = user.Name;
                textBox4.Text = user.Name;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }
            else if (user_bll.IsSecretary(user))
            {
                Secretary s = secretary_bll.Find(user.id);
                textBox3.Text = s.doctor.Name;
                textBox4.Text = s.doctor.Name;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
            }
            else
            {
                AutoCompleteStringCollection names = new AutoCompleteStringCollection();
                foreach (var item in doctor_bll.Read_ByNames())
                {
                    names.Add(item);
                }
                textBox3.AutoCompleteCustomSource = names;
                textBox4.AutoCompleteCustomSource = names;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Turn t = new Turn();
            t.PatientName = textBox1.Text;
            t.PatientPhone = textBox2.Text;
            t.DoctorName = textBox3.Text;
            t.Date = dateTimePicker1.Value.Date;
            t.Time = maskedTextBoxAdv1.Text;

            if (label6.Text == "ثبت اطلاعات")
            {
                string str = turn_bll.Create(t);
                msg.Show(str, false);
            }
            else if (label6.Text == "ویرایش اطلاعات")
            {
                string str = turn_bll.Update(t, id);
                msg.Show(str, false);
                label6.Text = "ثبت اطلاعات";
            }
            Clean();
            Fill_DataGridView();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Fill_DataGridView();
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt16(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells["id"].Value.ToString());
            Turn t = turn_bll.Find(id);

            textBox1.Text = t.PatientName;
            textBox2.Text = t.PatientPhone;
            textBox3.Text = t.DoctorName;
            dateTimePicker1.Value = t.Date;
            maskedTextBoxAdv1.Text = t.Time;
            label6.Text = "ویرایش اطلاعات";
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt16(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells["id"].Value.ToString());
            DialogResult dr = msg.Show("آیا از حدف نوبت اطمینان دارید ؟", true);
            if (dr == DialogResult.Yes)
            {
                string str = turn_bll.Delete(id);
                msg.Show(str, true);
            }
        }
    }
}
