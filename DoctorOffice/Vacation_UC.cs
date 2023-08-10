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
using BLL;


namespace DoctorOffice
{
    public partial class Vacation_UC : UserControl
    {
        public Vacation_UC()
        {
            InitializeComponent();
        }

        Vacation_BLL bll = new Vacation_BLL();
        MSG msg = new MSG();
        int id;
        public Doctor d;
        public Secretary s;
        public bool DoctorOrSecretary;

        private void Clean()
        {
            textBox1.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void Fill_DataGridView()
        {
            dataGridViewX1.DataSource = null;
            if (DoctorOrSecretary)
            {
                dataGridViewX1.DataSource = bll.Read(d.id);
            }
            else
            {
                dataGridViewX1.DataSource = bll.Read(s.id);
            }


            dataGridViewX1.Columns["Date"].HeaderText = "تاریخ مرخصی";
            dataGridViewX1.Columns["Info"].HeaderText = "توضیحات";

            dataGridViewX1.Columns["id"].Visible = false;
            dataGridViewX1.Columns["RegDate"].Visible = false;
            dataGridViewX1.Columns["DeleteStatus"].Visible = false;
            dataGridViewX1.Columns["user"].Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Vacation v = new Vacation();
            v.Date = dateTimePicker1.Value.Date;
            v.Info = textBox1.Text;
            v.RegDate = DateTime.Now;
            string str = "";

            if (label10.Text == "ثبت اطلاعات")
            {
                if (DoctorOrSecretary)
                {
                   str = bll.Create(v, d.id);
                    
                }
                else
                {
                     str = bll.Create(v, s.id);
                }
                msg.Show(str, false);
            }

            else if (label10.Text == "ویرایش اطلاعات")
            {
                str = bll.Update(v, id);
                msg.Show(str, false);
                label10.Text = "ثبت اطلاعات";
            }

            Fill_DataGridView();
            Clean();
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt16(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells["id"].Value.ToString());
            Vacation v = bll.Find(id);

            dateTimePicker1.Value = v.Date;
            textBox1.Text = v.Info;
            label10.Text = "ویرایش اطلاعات";
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt16(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells["id"].Value.ToString());
            MSG msg = new MSG();
            DialogResult dr = msg.Show("آیا از حذف تعطیلات اطمینان دارید ؟", true);
            if (dr == DialogResult.Yes)
            {
                string str = bll.Delete(id);
                msg.Show(str, false);
            }

            Fill_DataGridView();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = bll.Search(dateTimePicker2.Value.Date, d.id);

            dataGridViewX1.Columns["Date"].HeaderText = "تاریخ مرخصی";
            dataGridViewX1.Columns["Info"].HeaderText = "توضیحات";

            dataGridViewX1.Columns["id"].Visible = false;
            dataGridViewX1.Columns["RegDate"].Visible = false;
            dataGridViewX1.Columns["DeleteStatus"].Visible = false;
            dataGridViewX1.Columns["user"].Visible = false;
        }

        private void D_Vacation_UC_Load(object sender, EventArgs e)
        {
            Fill_DataGridView();
        }
    }
}
