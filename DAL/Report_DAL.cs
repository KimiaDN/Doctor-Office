using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Report_DAL
    {
        DB db = new DB();
        public DataTable Report_Deposits(DateTime time1, DateTime time2)
        {
            SqlConnection con = new SqlConnection("Data Source = .;Initial Catalog=DrOffice;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("dbo.Report_Deposits");
            cmd.Parameters.AddWithValue("@startDate", time1);
            cmd.Parameters.AddWithValue("@endDate", time2);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }


        public List<Deposit> Report_Deposits_Print(DateTime time1, DateTime time2)
        {
            List<Deposit> deposits = new List<Deposit>();
            foreach (var item in db.Deposits)
            {
                if (item.Date >= time1 && item.Date <= time2)
                {
                    deposits.Add(item);
                }
            }
            return deposits;
        }
        public DataTable Report_Receives(DateTime time1, DateTime time2)
        {
            SqlConnection con = new SqlConnection("Data Source = .;Initial Catalog=DrOffice;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("dbo.Report_Receives");
            cmd.Parameters.AddWithValue("@startDate", time1);
            cmd.Parameters.AddWithValue("@endDate", time2);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public List<Visit> Report_Receives_Print(DateTime time1, DateTime time2)
        {
            List<Visit> visits = new List<Visit>();
            foreach (var item in db.Visits)
            {
                if (item.PayDate >= time1 && item.PayDate <= time2)
                {
                    visits.Add(item);
                }
            }
            return visits;
        }
        public DataTable Report_DoctorPatients(DateTime time1, DateTime time2, string name)
        {
            SqlConnection con = new SqlConnection("Data Source = .;Initial Catalog=DrOffice;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("dbo.Report_DoctorPatients");
            cmd.Parameters.AddWithValue("@startDate", time1);
            cmd.Parameters.AddWithValue("@endDate", time2);
            cmd.Parameters.AddWithValue("@search", name);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }

        public DataTable Report_UsersSalary(DateTime time1, DateTime time2, string name)
        {
            SqlConnection con = new SqlConnection("Data Source = .;Initial Catalog=DrOffice;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("dbo.Report_UsersSalary");
            cmd.Parameters.AddWithValue("@startDate", time1);
            cmd.Parameters.AddWithValue("@endDate", time2);
            cmd.Parameters.AddWithValue("@search", name);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
    }
}
