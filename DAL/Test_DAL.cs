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
    public class Test_DAL
    {
        DB db = new DB();

        public string Create(Test t, int id)
        {
            try
            {
                t.patient = db.Patient.Find(id);
                db.Tests.Add(t);
                db.SaveChanges();
                return "ثبت آزمایش با موفقیت آنجام شد";
            }
            catch (Exception e)
            {
                return "مشکلی ئر ثبت آزمایش رخ داده است\n" + e.Message;
            }
        }

        public bool Add_Picture(string pic, int id)
        {
            bool check = false;
            foreach (var item in db.Tests)
            {
                if (item.id == id)
                {
                    item.Picture = pic;
                    check = true;
                }
            }
            if (check)
            {
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public Test Find(int id)
        {
            return db.Tests.Where(i => i.id == id).FirstOrDefault();
        }

        public DataTable Read()
        {

            SqlConnection con = new SqlConnection("Data Source = .;Initial Catalog=DrOffice;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("dbo.Read_Tests");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }

        public DataTable Search_ByDate(DateTime time)
        {
            SqlConnection con = new SqlConnection("Data Source = .;Initial Catalog=DrOffice;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("dbo.Search_Test_ByDate");
            cmd.Parameters.AddWithValue("@date", time);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }

        public DataTable Search_ByType(string s)
        {
            SqlConnection con = new SqlConnection("Data Source = .;Initial Catalog=DrOffice;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("dbo.Search_Test_ByType");
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

        public string Update(Test t, int id)
        {
            try
            {
                Test test = db.Tests.Where(i => i.id == id).FirstOrDefault();
                test.Type = t.Type;
                test.Name = t.Name;
                test.Info = t.Info;
                test.Picture = t.Picture;
                test.RegDate = t.RegDate;
                db.SaveChanges();
                return "ویرایش آزمایش با موفقیت انجام شد";
            }
            catch (Exception e)
            {
                return "مشکلی در ویرایش آزمایش رخ داده است\n" + e.Message;
            }
        }

        public string Delete(int id)
        {
            try
            {
                Test t = db.Tests.Where(i => i.id == id).FirstOrDefault();
                t.DeleteStatus = true;
                db.SaveChanges();
                return "حذف آزمایش با موفقیت انجام شد";
            }
            catch (Exception e)
            {
                return "مشکلی در حذف آزمایش رخ داده است\n" + e.Message;
            }
        }
    }
}
