using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class Turn_DAL
    {
        DB db = new DB();
        public string Create(Turn t)
        {
            db.Turns.Add(t);
            db.SaveChanges();
            return "نوبت دهی با موفقیت انجام شد";
        }

        public List<Turn> Read(string name, DateTime date)
        {
            return db.Turns.Where(i => i.DoctorName == name && i.Date == date).ToList();
        }

        public Turn Find(int id)
        {
            return db.Turns.Where(i => i.id == id).FirstOrDefault();
        }
        public string Update(Turn t, int id)
        {
            var q = db.Turns.Where(i => i.id == id).FirstOrDefault();
            q.PatientPhone = t.PatientPhone;
            q.PatientName = t.PatientName;
            q.DoctorName = t.DoctorName;
            q.Date = t.Date;
            q.Time = t.Time;
            db.SaveChanges();

            return "ویرایش نوبت با موفقیت انجام شد";
        }

        public string Delete(int id)
        {
            var q = db.Turns.Where(i => i.id == id).FirstOrDefault();
            q.DeleteStatus = true;
            db.SaveChanges();

            return "حذف نوبت با موفقیت انجام شد";
        }
    }
}
