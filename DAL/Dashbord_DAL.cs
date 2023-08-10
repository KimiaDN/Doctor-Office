using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class Dashbord_DAL
    {
        DB db = new DB();

        public int CountReminders(User u)
        {
            var q = db.Reminders.Where(i => i.user.id == u.id).ToList();
            return q.Count();
        }

        public List<Reminder> ReadReminders(User u)
        {
            return db.Reminders.Where(i => i.user.id == u.id).ToList();
        }

        public int CountPatients()
        {
            return db.Patient.Count();
        }

        public int Today_TotalPatients(string name)
        {
            int count = 0;
            foreach (var item in db.Turns)
            {
                if (item.Date == DateTime.Now.Date && item.DoctorName == name)
                {
                    count++;
                }
            }
            return count;
        }

        public int Today_TotalPatients()
        {
            int count = 0;
            foreach (var item in db.Turns)
            {
                if (item.Date == DateTime.Now.Date )
                {
                    count++;
                }
            }
            return count;
        }

        public int Office_TotalPatients()
        {
            return db.Patient.Count();
        }

    }
}
