using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class Report_BLL
    {
        Report_DAL dal = new Report_DAL();

        public DataTable Report_Deposits(DateTime time1, DateTime time2)
        {
            return dal.Report_Deposits(time1, time2);
        }

        public List<Deposit> Report_Deposits_Print(DateTime time1, DateTime time2)
        {
            return dal.Report_Deposits_Print(time1, time2 );
        }
        public DataTable Report_Receives(DateTime time1, DateTime time2)
        {
            return dal.Report_Receives(time1, time2);
        }

        public List<Visit> Report_Receives_Print(DateTime time1, DateTime time2)
        {
           return dal.Report_Receives_Print(time1 , time2 );
        }
        public DataTable Report_DoctorPatients(DateTime time1, DateTime time2, string name)
        {
            return dal.Report_DoctorPatients(time1, time2, name);
        }

        public DataTable Reaport_UsersSalary(DateTime time1, DateTime time2, string name)
        {
            return dal.Report_UsersSalary(time1, time2, name);
        }
    }
}
