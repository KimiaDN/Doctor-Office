using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
using System.Runtime.InteropServices.WindowsRuntime;

namespace BLL
{
    public class Visit_BLL
    {
        Visit_DAL dal = new Visit_DAL();

        public string Create(Visit v, int id)
        {
           return dal.Create(v, id);
        }

        public List<Visit> Read(DateTime time1, DateTime time2, int id)
        {
            return dal.Read(time1, time2, id);
        }

        public List<Visit> Read_Payed(int id)
        {
            return dal.Read_Payed(id);
        }

        public List<Visit> Read_UnPayed(int id)
        {
            return dal.Read_UnPayed(id);
        }

        public Visit Find(int id)
        {
            return dal.Find(id);
        }

        public string Update(Visit v, int id)
        {
           return dal.Update(v, id);  
        }

        public string Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}
