using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class WorkDay_DAL
    {

        DB db = new DB();

        public string create(WorkDay wd, int id)
        {
            try
            {
                wd.user = db.Users.Find(id);    
                db.WorkDays.Add(wd);
                db.SaveChanges();
                return "ثبت برنامه کاری با موفقیت انجام شد";
            }
            catch (Exception e)
            {
                return "خطایی در ثبت برنامه کاری رخ داده است" + e.Message;
            }
        }

        public string Update(WorkDay wd, int id)
        {
            WorkDay w = db.WorkDays.Where(i => i.id == id).FirstOrDefault();
            w.Day = wd.Day;
            w.From = wd.From;
            w.Until = wd.Until;
            w.user = db.Users.Find(wd.user.id);

            db.SaveChanges();
            return "ویرایش برنامه کاری با موفقیت انجام شد";
        }

        public string Delete(int id)
        {
            var q =  db.WorkDays.Where(i => i.user.id == id).ToList();
            foreach (var item in q)
            {
                item.DeleteStatus = true;
            }
            db.SaveChanges();
            return "حدف برنامه کاری با موفقیت انجام شد";
        }
    }
}
