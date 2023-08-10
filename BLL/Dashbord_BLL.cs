using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BLL
{
    public class Dashbord_BLL
    {
        Dashbord_DAL dal = new Dashbord_DAL();
        public int CountReminders(User u)
        {
            return dal.CountReminders(u);
        }

        public List<Reminder> ReadReminders(User u)
        {
            return dal.ReadReminders(u);
        }

        public int CountPatients()
        {
            return dal.CountPatients();
        }

        public int Today_TotalPatients(string name)
        {
            return dal.Today_TotalPatients(name);
        }

        public int Today_TotalPatients()
        {
            return dal.Today_TotalPatients();
        }

        public int Office_TotalPatients()
        {
            return dal.Office_TotalPatients();
        }
    }
}
