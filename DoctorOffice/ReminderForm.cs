using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;
using BE;
using BLL;

namespace DoctorOffice
{
    public partial class ReminderForm : Form
    {
        public ReminderForm()
        {
            InitializeComponent();
        }

        Reminder_BLL reminder_bll = new Reminder_BLL();
        User_BLL user_bll = new User_BLL();
        User u;
        int id;


        private void Fill_DataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = reminder_bll.Read();

            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["DeleteStatus"].Visible = false;

        }

        private void Clean()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            richTextBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            Reminder r = new Reminder();
            r.Title = textBox2.Text;
            r.Info = richTextBox1.Text;
            r.Date = dateTimePicker1.Value.Date;
            r.RegDate = DateTime.Now;
            u = user_bll.find(textBox1.Text);

            MSG msg = new MSG();
            if (label10.Text == "ثبت اطلاعات")
            {
                string str = reminder_bll.Create(r, u.id);
                msg.Show(str, false);
            }
            else if (label10.Text == "ویرایش اطلاعات")
            {
                r.user = u;
                string str = reminder_bll.Update(r, id);
                msg.Show(str, false);
                label10.Text = "ثبت اطلاعات";
            }

            Fill_DataGridView();
            Clean();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt16(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value.ToString());
            Reminder r = reminder_bll.Find(id);

            textBox1.Text = r.user.Name;
            textBox2.Text = r.Title;
            richTextBox1.Text = r.Info;
            dateTimePicker1.Value = r.Date;

            label10.Text = "ویرایش اطلاعات";
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt16(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value.ToString());
            MSG msg = new MSG();
            DialogResult dr = msg.Show("آیا از حذف یادآور اطمینان دارید ؟", true);
            if (dr == DialogResult.Yes)
            {
                string str = reminder_bll.Delete(id);
                msg.Show(str, false);
            }

            Fill_DataGridView();
        }

        private void انجامشدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt16(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value.ToString());
            Reminder r = reminder_bll.Find(id);
            r.Done = true;
            MSG msg = new MSG();
            string str = reminder_bll.Update(r, id);
            msg.Show(str, false);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            Fill_DataGridView();
            AutoCompleteStringCollection names = new AutoCompleteStringCollection();
            foreach (var item in user_bll.Read_UsersName())
            {
                names.Add(item);
            }
            textBox1.AutoCompleteCustomSource = names;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = reminder_bll.Search(textBox4.Text);

            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["DeleteStatus"].Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
