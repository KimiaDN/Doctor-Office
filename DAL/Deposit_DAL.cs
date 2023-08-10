using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class Deposit_DAL
    {
        DB db = new DB();

        public string create(Deposit d, User u)
        {
            d.user = db.Users.Find(u.id);   
            db.Deposits.Add(d);
            db.SaveChanges();
            return "واریز حقوق با موفقیت انجام شد";

        }

        public DataTable Read()
        {
            SqlConnection con = new SqlConnection("Data Source = .;Initial Catalog=DrOffice;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("dbo.Read_Deposits");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public DataTable Search(string s)
        {
            SqlConnection con = new SqlConnection("Data Source = .;Initial Catalog=DrOffice;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("dbo.Search_Deposits");
            cmd.Parameters.AddWithValue("@search", s);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }

        public string Delete(int id)
        {
            var q = db.Deposits.Where(i => i.id == id).FirstOrDefault();
            q.DeleteStatus = true;
            db.SaveChanges();
            return "حذف واریز با موفقیت انجام شد";
        }

        
    }
}
