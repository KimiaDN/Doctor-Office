using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class User_BLL
    {
        User_DAL dal = new User_DAL();

        private string EncodePass(string pass)
        {
            byte[] encdata_byte = new byte[pass.Length];
            encdata_byte = System.Text.Encoding.UTF8.GetBytes(pass);
            string encodeData = Convert.ToBase64String(encdata_byte);
            return encodeData;
        }

        public User find(string s)
        {
            return dal.find(s);
        }

        public User Login(string u, string p)
        {
            p = EncodePass(p);
            return dal.Login(u, p);
        }

        public List<string> Read_UsersName()
        {
            return dal.Read_UsersName();
        }

        public bool IsRegistered()
        {
            return dal.IsRegistered();
        }

        public bool IsDoctor(User u)
        {
            return dal.IsDoctor(u);
        }

        public bool IsSecretary(User u)
        {
            return dal.IsSecretary(u);
        }

        public bool Access(User u, int code, int a)
        {
            return dal.Access(u, code, a);
        }

    }
}
