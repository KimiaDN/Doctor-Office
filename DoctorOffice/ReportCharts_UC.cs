using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BE;
using BLL;

namespace DoctorOffice
{
    public partial class ReportCharts_UC : UserControl
    {
        public ReportCharts_UC()
        {
            InitializeComponent();
        }

        Doctor_BLL doctor_bll = new Doctor_BLL();
        public DateTime start;
        public DateTime end;
        private void ReportCharts_UC_Load(object sender, EventArgs e)
        {
            chart1.Titles["Title1"].Text = "نمودار مقایسه تعداد بیماران هر پزشک";
            chart1.Series["Series1"].Points.Clear();
            chart1.Series["Series1"].LegendText = "نام پزشک";

            foreach (var item in doctor_bll.ReadDoctors())
            {
                int num = doctor_bll.Doctor_PatientsCount(start, end, item.id);
                chart1.Series["Series1"].Points.AddXY(item.Name, num);
            }
        }
    }
}
