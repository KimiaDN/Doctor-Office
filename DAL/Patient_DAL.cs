using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Runtime.InteropServices;
using System.Data.Entity;

namespace DAL
{
    public class Patient_DAL
    {
        DB db = new DB();

        public string Create(Patient p, int id)
        {
            
            try
            {
                Doctor d = db.Doctors.Find(id);  
                p.doctor = d;
                db.Patient.Add(p);
                db.SaveChanges();
                return "ثبت بیمار با موفقست انجام شد";
            }
            catch (Exception e)
            {
                return "مشکلی در ثبت بیمار رخ داده است\n" + e.Message;
            }
        }

        public bool Check(Patient p)
        {
            foreach (var p1 in db.Patient)
            {
                if ((p1.Code == p.Code || p1.Phone == p.Phone) && !p1.DeleteStatus)
                {
                    return false;
                }
            }
            return true;
        }

        public DataTable Read()
        {
            SqlConnection con = new SqlConnection("Data Source = .;Initial Catalog=DrOffice;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("dbo.Read_Patients");
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            var sqladapter = new SqlDataAdapter();
            sqladapter.SelectCommand = cmd;
            var commandbuilder = new SqlCommandBuilder(sqladapter);
            var ds = new DataSet();
            sqladapter.Fill(ds);
            return ds.Tables[0];
        }

        public Patient Find(int id)
        {
            Patient p = db.Patient.Where(i => i.id == id).Include("Doctor").FirstOrDefault();
            return p;
        }

        public DataTable Search(string s)
        {
            SqlConnection con = new SqlConnection("Data Source = .;Initial Catalog=DrOffice;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("dbo.Search_Patients");
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

        public DataTable Search_ByDoctorName(string s, int id)
        {
            SqlConnection con = new SqlConnection("Data Source = .;Initial Catalog=DrOffice;Integrated Security=true");
            SqlCommand cmd = new SqlCommand("dbo.Search_Patients_ByDoctorName");
            cmd.Parameters.AddWithValue("@search", s);
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
        public List<Visit> Read_Visits(int id)
        {
            return db.Visits.Where(i => i.patient.id == id && i.DeleteStatus == false).ToList();
        }

        public string Update(int id, Patient p)
        {
           
            Patient patient = db.Patient.Where(i => i.id == id).SingleOrDefault();
            patient.Name = p.Name;
            patient.Credit = p.Credit;
            patient.Code = p.Code;
            patient.Phone = p.Phone;
            patient.Insurance = p.Insurance;
            patient.Age = p.Age;
            patient.doctor = db.Doctors.Find(p.doctor.id);
            patient.Gender = p.Gender;

            db.SaveChanges();
            return "ویرایش بیمار با موفقیت انجام شد";
        }

        public string Delete(int id)
        {
            try
            {
                Patient p = db.Patient.Where(i => i.id == id).SingleOrDefault();
                p.DeleteStatus = true;
                db.SaveChanges();
                return "حذف بیمار با موفقیت انجام شد";
            }
            catch (Exception e)
            {
                return "مشکلی در حذف بیمار رخ داده است\n" + e.Message;
            }
        }
    }
}
