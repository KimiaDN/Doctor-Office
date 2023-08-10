using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class Secretary_BLL
    {

        Secretary_DAL dal = new Secretary_DAL();


        private string EncodePass(string pass)
        {
            byte[] encdata_byte = new byte[pass.Length];
            encdata_byte = System.Text.Encoding.UTF8.GetBytes(pass);
            string encodeData = Convert.ToBase64String(encdata_byte);
            return encodeData;
        }

        public string Create(Secretary s, int d_id, int ug_id)
        {
           s.Password = EncodePass(s.Password);
           return dal.Create(s, d_id, ug_id);
        }

        public DataTable Read()
        {
            return dal.Read();
        }

        public DataTable Search(string s)
        {
            return dal.Search(s);
        }

        public Secretary Find(int id)
        {
            return dal.Find(id);
        }

        public DataTable Read_DoctorPatients(int id)
        {
            return dal.Read_DoctorPatients(id);
        }

        public List<string> Read_ByName()
        {
            return dal.Read_ByName();
        }

        public string Update(Secretary s, int id)
        {
            s.Password = EncodePass(s.Password);
            return dal.Update(s, id);
        }

        public string Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}
