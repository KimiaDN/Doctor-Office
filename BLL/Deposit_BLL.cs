using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BLL;
using DAL;

namespace BLL
{
    public class Deposit_BLL
    {
        Deposit_DAL dal = new Deposit_DAL();

        public string create(Deposit d, User u)
        {
            return dal.create(d, u);
        }

        public DataTable Read()
        {
            return dal.Read();
        }
        public DataTable Search(string s)
        {
            return dal.Search(s);
        }

        public string Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}
