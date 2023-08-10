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
using Stimulsoft.Report;

namespace DoctorOffice
{
    public partial class ReportLists_UC : UserControl
    {
        public ReportLists_UC()
        {
            InitializeComponent();
        }
        public DateTime start;
        public DateTime end;
        public int kind;

        Report_BLL bll = new Report_BLL();
        private void ReportLists_UC_Load(object sender, EventArgs e)
        {
            if (kind == 1)
            {
                dataGridViewX1.DataSource = null;
                dataGridViewX1.DataSource = bll.Report_Deposits(start, end);

                double sum = 0;
                foreach (DataGridViewRow row in dataGridViewX1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.ColumnIndex == 2)
                        {
                            if (cell.Value != null)
                            {
                                sum = sum + Convert.ToDouble(cell.Value.ToString());
                            }
                        }
                    }
                }
                label4.Text = "جمع کل : " + sum + "تومان";
            }
            if (kind == 2)
            {
                dataGridViewX1.DataSource = null;
                dataGridViewX1.DataSource = bll.Report_Receives(start, end);
                label8.Text = "گزارش دریافت ها :";

                double sum = 0;
                foreach (DataGridViewRow row in dataGridViewX1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.ColumnIndex == 3)
                        {
                            if (cell.Value != null)
                            {
                                sum = sum + Convert.ToDouble(cell.Value.ToString());
                            }
                        }
                    }
                }
                label4.Text = "جمع کل : " + sum + "تومان";
            }
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (kind == 1)
            {
                StiReport sti = new StiReport();
                sti.Load(@"D:\C#\DoctorOffice\Report_Deposits.mrt");
                sti.Dictionary.Variables["StartDate"].Value = start.ToString();
                sti.Dictionary.Variables["EndDate"].Value = end.ToString();
                sti.RegBusinessObject("DepositsReport", bll.Report_Deposits_Print(start, end));

                sti.Render();
                sti.Show();
            }
            if (kind == 2)
            {
                StiReport sti = new StiReport();
                sti.Load(@"D:\C#\DoctorOffice\Report_Receives.mrt");
                sti.Dictionary.Variables["StartDate"].Value = start.ToString();
                sti.Dictionary.Variables["EndDate"].Value = end.ToString();
                sti.RegBusinessObject("ReportReceives", bll.Report_Receives_Print(start, end));

                sti.Render();
                sti.Show();
            }
        }
    }
}
