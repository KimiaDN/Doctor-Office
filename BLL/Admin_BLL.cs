using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Admin_BLL
    {
        Admin_DAL dal = new Admin_DAL();

        private string EncodePass(string pass)
        {
            byte[] encdata_byte = new byte[pass.Length];
            encdata_byte = System.Text.Encoding.UTF8.GetBytes(pass);
            string encodeData = Convert.ToBase64String(encdata_byte);
            return encodeData;
        }
        public string Create(Admin a, UserGroup ug)
        {
            if (dal.check(a))
            {
                a.Password = EncodePass(a.Password);    
                return dal.Create(a, ug);
            }
            return "نام کاربری یا کلمه عبور تکراری می باشد";

        }

    }
}
