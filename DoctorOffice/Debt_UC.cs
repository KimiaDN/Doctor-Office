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
using DevComponents.DotNetBar.Controls;

namespace DoctorOffice
{
    public partial class Debt_UC : UserControl
    {
        public Patient p;
        Patient_BLL patient_bll = new Patient_BLL();
        Visit_BLL visit_bll = new Visit_BLL();
        MSG msg = new MSG();
        Visit v;
        int id;
        public Debt_UC()
        {
            InitializeComponent();
        }

        private void Fill_DataGridView()
        {

            dataGridViewX1.Columns["id"].Visible = false;
            dataGridViewX1.Columns["DeleteStatus"].Visible = false;
            dataGridViewX1.Columns["patient"].Visible = false;
            dataGridViewX1.Columns["Drugs"].Visible = false;
            dataGridViewX1.Columns["PatientSigns"].Visible = false;
            dataGridViewX1.Columns["DoctorIdea"].Visible = false;
            dataGridViewX1.Columns["Title"].Visible = false;

            dataGridViewX1.Columns["RegDate"].HeaderText = "تاریخ مراجعه";
            dataGridViewX1.Columns["Cost"].HeaderText = "هزینه ویزیت";
            dataGridViewX1.Columns["IsPayed"].HeaderText = "وضعیت پرداخت";
            dataGridViewX1.Columns["PayDate"].HeaderText = "تاریخ پرداخت";
        }

        private void Debt_UC_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "همه ویزیت ها";
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = patient_bll.Read_Visit(p.id);

            textBox2.Text = p.doctor.Name;
            textBox1.Text = p.doctor.Cart;
            Fill_DataGridView();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ویزیت های پرداخت شده")
            {
                dataGridViewX1.DataSource = null;
                dataGridViewX1.DataSource = visit_bll.Read_Payed(p.id);
            }
            else if (comboBox1.Text == "ویزیت های پرداخت نشده")
            {
                dataGridViewX1.DataSource = null;
                dataGridViewX1.DataSource = visit_bll.Read_UnPayed(p.id);
            }
            else if (comboBox1.Text == "همه ویزیت ها")
            {
                dataGridViewX1.DataSource = null;
                dataGridViewX1.DataSource = patient_bll.Read_Visit(p.id);
            }

            Fill_DataGridView();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void پرداختToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells["id"].Value.ToString());
            v = visit_bll.Find(id);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            v.PayDate = dateTimePicker2.Value.Date;
            v.IsPayed = true;
            v.Cost = Convert.ToDouble(textBox3.Text);
            string str = visit_bll.Update(v, v.Id);
            msg.Show( str, false);

            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = patient_bll.Read_Visit(p.id);
            Fill_DataGridView();
        }
    }
}
