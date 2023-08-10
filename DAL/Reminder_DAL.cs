using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class Reminder_DAL
    {
        DB db = new DB();

        public string Create(Reminder r, int id)
        {
            r.user = db.Users.Find(id);
            db.Reminders.Add(r);
            db.SaveChanges();
            return "ثبت یادآور با موفقیت انجام شد";
        }

        public DataTable Read()
        {
            SqlConnection con = new SqlConnection("Data Source = .;Initial Catalog=DrOffice;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("dbo.Read_Reminders");
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
            SqlCommand cmd = new SqlCommand("dbo.Search_Reminders");
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

        public Reminder Find(int id)
        {
            return db.Reminders.Where(r => r.id == id).Include("user").FirstOrDefault();
        }

        public string Update(Reminder r, int id)
        {
            var q = db.Reminders.Where(i => i.id == id).FirstOrDefault();
            q.Title = r.Title;
            q.Info = r.Info;
            q.user = db.Users.Find(r.user.id);
            q.Date = r.Date;
            q.Done = r.Done;

            db.SaveChanges();
            return "ویرایش یادآور با موفقیت انجام شد";
        }

        public string Delete(int id)
        {
            var q = db.Reminders.Where(i => i.id == id).FirstOrDefault();
            q.DeleteStatus = true;
            db.SaveChanges();
            return "حذف یادآور با موفقیت انجام شد";
        }
    }
}
