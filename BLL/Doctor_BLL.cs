using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Data.SqlClient;

namespace BLL
{
    public class Doctor_BLL
    {
        Doctor_DAL dal = new Doctor_DAL();

        private string EncodePass(string pass)
        {
            byte[] encdata_byte = new byte[pass.Length];
            encdata_byte = System.Text.Encoding.UTF8.GetBytes(pass);
            string encodeData = Convert.ToBase64String(encdata_byte);
            return encodeData;
        }

        public string Create(Doctor d, int id)
        {
           d.Password = EncodePass(d.Password);
            if (dal.check(d))
            {
                return dal.Create(d, id);
            }
            else
            {
                return "نام کاربری یا کلمه عبور تکراری می باشد";
            }

        }

        public DataTable Read()
        {
            return dal.Read();
        }

        public List<Doctor> ReadDoctors()
        {
            return dal.ReadDoctors();
        }

        public DataTable Read_DoctorPatients(int id)
        {
            return dal.Read_DoctorPatients(id);
        }

        public int Doctor_PatientsCount(DateTime time1, DateTime time2, int id)
        {
           return dal.Doctor_PatientsCount(time1, time2, id);   
        }

        public DataTable Search(string s)
        {
            return dal.Search(s);
        }

        public List<String> Read_ByNames()
        {
            return dal.Read_ByNames();
        }

        public Doctor find(int id)
        {
            return dal.find(id);
        }

        public List<WorkDay> Doctor_WorkDays(int id)
        {
            return dal.Doctor_WorkDays(id);
        }

        public Doctor find_ByName(string s)
        {
            return dal.find_ByName(s);
        }

        public string Update(Doctor d, int id)
        {
            d.Password = EncodePass(d.Password);    
            return dal.Update(d, id);
        }

        public string Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}
