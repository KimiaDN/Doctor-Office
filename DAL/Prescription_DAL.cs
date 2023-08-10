using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class Prescription_DAL
    {
        DB db = new DB();
        /*
        public string Create(Prescription p)
        {
            try
            {
                db.Prescriptions.Add(p);
                db.SaveChanges();
                return "ثبت تجویز با موفقیت انجام شد";
            }
            catch (Exception e)
            {
                return "مسکلی در ثبت تجویز رخ داده است\n" + e.Message;
            }
        }

        public Prescription Find(int id)
        {
            foreach (var item in db.Prescriptions)
            {
                if (item.id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public List<Prescription> Read(int id)
        {
            List<Prescription> list = new List<Prescription>();
            foreach (var item in db.Prescriptions)
            {
                if (item.id == id)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        public string Update(Prescription p, int id)
        {
            bool check = false;
            try
            {
                foreach (var item in db.Prescriptions)
                {
                    if (item.id == id)
                    {
                        check = true;
                        item.Title = p.Title;
                        item.Info = p.Info;
                    }
                }
                if (check)
                {
                    db.SaveChanges();
                    return "ویرایش نسخه با موفقیت انجام شد";
                }
                return "نشخه مورد نظر یافت نشد";
            }
            catch (Exception e)
            {
                return "مشکلی در ویرایش نسخه به وجود آمده است\n" + e.Message;
            }
        }

        public string Delete(int id)
        {
            bool check = false;
            try
            {
                foreach (var item in db.Prescriptions)
                {
                    if (item.id == id)
                    {
                        item.DeleteStatus = true;
                        check = true;
                    }
                }
                if (check)
                {
                    db.SaveChanges();
                    return "حذف نسخه با موفقیت انجام شد";
                }
                return "نسخه مورد نظر یافت نشد";
            }
            catch (Exception e)
            {
                return "مشکلی در حذف نسخه رخ داده است\n" + e.Message;
            }

        }*/
    }
}
