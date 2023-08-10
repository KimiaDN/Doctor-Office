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
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
        }

        Report_BLL bll = new Report_BLL();
        User_BLL user_bll = new User_BLL();

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection names = new AutoCompleteStringCollection();
            foreach (var item in user_bll.Read_UsersName())
            {
                names.Add(item);
            }    
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                StiReport sti = new StiReport();
                sti.Load(@"D:\C#\DoctorOffice\Report_Deposits.mrt");
                sti.Dictionary.Variables["StartDate"].Value = dateTimePicker1.Value.Date.ToString();
                sti.Dictionary.Variables["EndDate"].Value = dateTimePicker2.Value.Date.ToString();
                sti.RegBusinessObject("DepositsReport", bll.Report_Deposits_Print(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date));

                sti.Render();
                sti.Show();
            }

            if (radioButton2.Checked)
            {
                StiReport sti = new StiReport();
                sti.Load(@"D:\C#\DoctorOffice\Report_Receives.mrt");
                sti.Dictionary.Variables["StartDate"].Value = dateTimePicker1.Value.Date.ToString();
                sti.Dictionary.Variables["EndDate"].Value = dateTimePicker2.Value.Date.ToString();
                sti.RegBusinessObject("ReportReceives", bll.Report_Receives_Print(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date));

                sti.Render();
                sti.Show();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked || radioButton2.Checked)
            {
                ReportLists_UC report = new ReportLists_UC();   
                report.start = dateTimePicker1.Value.Date;
                report.end = dateTimePicker2.Value.Date;

                if (radioButton1.Checked)
                {
                    report.kind = 1;
                    report.label8.Text = "گزارش واریز ها :";
                }
                else
                {
                    report.kind = 2;
                    report.label8.Text = "گزارش دریافت ها :";
                }
                if (panel1.Controls.Count > 0)
                {
                    panel1.Controls[0].Dispose();
                }
                panel1.Controls.Add(report);

            }
            if (radioButton4.Checked)
            {
                ReportCharts_UC report = new ReportCharts_UC();
                report.start = dateTimePicker1.Value.Date;
                report.end = dateTimePicker2.Value.Date;
                if (panel1.Controls.Count > 0)
                {
                    panel1.Controls[0].Dispose();
                }
                panel1.Controls.Add(report);
            }
        }
    }
}
