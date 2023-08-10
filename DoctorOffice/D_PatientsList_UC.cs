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
using DevComponents.DotNetBar.Controls;

namespace DoctorOffice
{
    public partial class D_PatientsList_UC : UserControl
    {
        public D_PatientsList_UC()
        {
            InitializeComponent();
        }

        public Doctor d;
        Doctor_BLL doctor_bll = new Doctor_BLL();
        Patient_BLL patient_bll = new Patient_BLL();
        private void D_PatientsList_UC_Load(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = doctor_bll.Read_DoctorPatients(d.id);

            dataGridViewX1.Columns["id"].Visible = false;
            dataGridViewX1.Columns["doctor_id"].Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = patient_bll.Search(textBox1.Text);

            dataGridViewX1.Columns["id"].Visible = false;
            dataGridViewX1.Columns["DeleteStatus"].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void مشاهدهپروندهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells["id"].Value.ToString());
            Patient p = patient_bll.Find(id);
            PatientHome patient_home = new PatientHome();
            patient_home.p = p;
            patient_home.ShowDialog();
        }
    }
}
