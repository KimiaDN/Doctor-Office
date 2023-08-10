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
    public class Test_BLL
    {
        Test_DAL dal = new Test_DAL();
        public string Create(Test t, int id)
        {
           return dal.Create(t, id);
        }

        public bool Add_Picture(string pic, int id)
        {
            return dal.Add_Picture(pic, id);
        }

        public Test Find(int id)
        {
            return dal.Find(id);
        }

        public DataTable Read()
        {
            return dal.Read();
        }

        public DataTable Search_ByDate(DateTime time)
        {
            return dal.Search_ByDate(time);
        }

        public DataTable Search_ByType(string s)
        {
            return dal.Search_ByType(s);
        }


        public string Update(Test t, int id)
        {
            return dal.Update(t, id);
        }

        public string Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}
