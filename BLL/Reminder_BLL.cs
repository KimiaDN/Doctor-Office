using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
using System.Data;

namespace BLL
{
    public class Reminder_BLL
    {

        Reminder_DAL dal = new Reminder_DAL();

        public string Create(Reminder r, int id)
        {
            return dal.Create(r, id);
        }

        public DataTable Read()
        {
            return dal.Read();
        }

        public DataTable Search(string s)
        {
            return dal.Search(s);
        }

        public Reminder Find(int id)
        {
            return dal.Find(id);
        }

        public string Update(Reminder r, int id)
        {
            return dal.Update(r, id);   
        }

        public string Delete(int id)
        {
            return dal.Delete(id);  
        }
    }
}
