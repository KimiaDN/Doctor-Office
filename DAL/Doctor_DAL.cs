using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
   public class Doctor_DAL
    {
        DB db = new DB();

        public string Create(Doctor d, int id)
        {
			try
			{
                d.usergroup = db.UserGroups.Find(id);
				db.Doctors.Add(d);
				db.SaveChanges();
				return "ثبت پزشک با موفقیت انجام شد";
			}
			catch (Exception e) 
			{
				return "خطایی در ثبت پزشک رخ داده است" + e.Message;
			}
        }

        public bool check(Doctor d)
        {
            foreach (var i in db.Users)
            {
                if (i.UserName == d.UserName && i.Password == d.Password && !i.DeleteStatus)
                {
                    return false;
                }
            }
            return true;
        }

		public DataTable Read()
		{
            SqlConnection con = new SqlConnection("Data Source = .;Initial Catalog=DrOffice;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("dbo.Read_Doctors");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }

        public List<Doctor> ReadDoctors()
        {
            return db.Doctors.Where(i => i.DeleteStatus == false).ToList();
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

        public int Doctor_PatientsCount(DateTime time1, DateTime time2, int id)
        {
            int count = 0;
            foreach (var item in db.Patient)
            {
                if (item.RegDate >= time1 && item.RegDate <= time2 && item.DeleteStatus == false)
                {
                    if (item.doctor.id == id)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public DataTable Search(string s)
        {
            SqlConnection con = new SqlConnection("Data Source = .;Initial Catalog=DrOffice;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("dbo.Search_Doctors");
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

        public List<String> Read_ByNames()
		{
			return db.Doctors.Select(i => i.Name).ToList();
		}

		public Doctor find(int id)
		{
            return db.Doctors.Where(i => i.id == id).FirstOrDefault();
		}

        public List<WorkDay> Doctor_WorkDays(int id)
        {
            return db.WorkDays.Where(i => i.user.id == id && i.DeleteStatus == false).ToList();
        }

        public Doctor find_ByName(string s)
        {
            return db.Doctors.Where(i => i.Name == s).FirstOrDefault();
        }

        public string Update(Doctor d, int id)
		{
            try
            {
                Doctor doctor = db.Doctors.Where(i => i.id == id).FirstOrDefault();
                doctor.Name = d.Name;
                doctor.Age = d.Age;
                doctor.UserName = d.UserName;
                doctor.Speciality = d.Speciality;
                doctor.SpecialityNum = d.SpecialityNum;
                doctor.SecretaryName = d.SecretaryName; 
                doctor.Cart = d.Cart;
                if (d.Password != "")
                {
                    doctor.Password = d.Password;
                }

                db.SaveChanges();
                return "ویرایش پزشک با موفقیت انجام شد";
            }
            catch (Exception e)
            {
                return "خطایی در ویرایش پزشک رخ داده است" + e.Message;
            }
			
        }

		public string Delete(int id)
		{
            try
            {
                Doctor doctor = db.Doctors.Where(i => i.id == id).FirstOrDefault();
                doctor.DeleteStatus = true;
                db.SaveChanges();
                return "حذف پزشک با موفقیت انجام شد";
            }
            catch (Exception e)
            {
                return "خطایی در حذف پزشک رخ داده است" + e.Message;
            }
           
        }

        
    }
}
