using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class Vacation_DAL
    {

        DB db = new DB();

        public string Create(Vacation v, int id)
        {
            var q = db.Users.Find(id);
            v.user = q;
            db.Vacations.Add(v);
            db.SaveChanges();
            return "درخواست مرخصی با موفقیت ثبت شد";
        }

        public List<Vacation> Read(int id)
        {
            return db.Vacations.Where(i => i.user.id == id && i.DeleteStatus == false).ToList();
        }

        public Vacation Find(int id)
        {
            return db.Vacations.Where(i => i.id ==id && i.DeleteStatus == false).FirstOrDefault();
        }

        public List<Vacation> Search(DateTime date, int id)
        {
            return db.Vacations.Where(i => i.user.id == id && i.Date == date && i.DeleteStatus == false).ToList();
        }

        public string Update(Vacation v, int id)
        {
            var q = db.Vacations.Where(i => i.id == id).FirstOrDefault();
            q.Date = v.Date;
            q.Info = v.Info;
            q.RegDate = v.RegDate;

            db.SaveChanges();
            return "ویرایش مرخصی با موفقیت انجام شد";
        }

        public string Delete(int id)
        {
            var q = db.Vacations.Where(i => i.id == id).FirstOrDefault();
            q.DeleteStatus = true;
            db.SaveChanges();
            return "حدف مرخصی با موفقیت انجام شد";
        }

        public bool CheckForCreate(Vacation v, int id)
        {
            var q = db.Users.Where(i => i.id == id).FirstOrDefault();
            if (q.VacationNum < 3 && v.Date > DateTime.Now)
            {
                return true;
            }
            return false;
        }

        public bool CheckForUpdateDelete(int id)
        {
            var q = db.Vacations.Where(i => i.id == id).FirstOrDefault();
            if (q.Date > DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}
