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
    public class Secretary_DAL
    {
        DB db = new DB();

        public string Create(Secretary s, int d_id, int ug_id)
        {
            s.doctor = db.Doctors.Find(d_id);
            s.usergroup = db.UserGroups.Find(ug_id); 
            db.Secretaries.Add(s);
            db.SaveChanges();
            return "ثبت منشی با موفقیت انجام شد";
        }

        public DataTable Read()
        {
            SqlConnection con = new SqlConnection("Data Source = .;Initial Catalog=DrOffice;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("dbo.Read_Secretaries");
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
            SqlCommand cmd = new SqlCommand("dbo.Search_Secretaries");
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

        public DataTable Read_DoctorPatients(int id)
        {
            SqlConnection con = new SqlConnection("Data Source = .;Initial Catalog=DrOffice;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("dbo.Read_DoctorPatiens");
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }
        public Secretary Find(int id)
        {
            return db.Secretaries.Where(x => x.id == id).Include("Doctor").FirstOrDefault();
        }

        public List<string> Read_ByName()
        {
            return db.Secretaries.Select(i => i.Name).ToList();
        }

        public string Update(Secretary s, int id)
        {
            var q = db.Secretaries.Where(x => x.id == id).FirstOrDefault();
            q.Name = s.Name;
            q.Age = s.Age;
            q.Phone = s.Phone;
            q.UserName = s.UserName;
            q.Picture = s.Picture;
            q.Cart = s.Cart;
            q.Education = s.Education;
            q.doctor = db.Doctors.Find(s.doctor.id);
            if (s.Password != "")
            {
                q.Password = s.Password;
            }
            db.SaveChanges();

            return "ویرایش منشی با موفقیت انجام شد";
        }

        public string Delete(int id)
        {
            var q = db.Secretaries.Where(x => x.id == id).FirstOrDefault();
            q.DeleteStatus = true;
            db.SaveChanges();
            return "حذف منشی با موفقیت انجام شد";
        }
    }
}
