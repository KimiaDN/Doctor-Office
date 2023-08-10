using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class Visit_DAL
    {
        DB db = new DB();

        public string Create(Visit v, int id)
        {
           try
            {
                v.patient = db.Patient.Find(id);
                db.Visits.Add(v);
                db.SaveChanges();
                return "ثبت ویزیت با موفقیت انجام شد";
            }
            catch (Exception e)
            {
                return " مشکلی در ثبت ویزیت رخ داده است\n" + e.Message;
            }
        }

        public List<Visit> Read(DateTime time1, DateTime time2, int id)
        {
            return db.Visits.Where(i => i.patient.id == id && i.RegDate >= time1 && 
                    i.RegDate <= time2 && i.DeleteStatus == false).ToList();
        }

        public List<Visit> Read_Payed(int id)
        {
            return db.Visits.Where(i => i.patient.id == id && i.IsPayed == true 
                    && i.DeleteStatus == false ).ToList();
        }

        public List<Visit> Read_UnPayed(int id)
        {
            return db.Visits.Where(i => i.patient.id == id && i.IsPayed == false &&
                   i.DeleteStatus == false).ToList();
        }

        public Visit Find(int id)
        {
            return db.Visits.Where(i => i.Id == id).FirstOrDefault();
        }

        public string Update(Visit v, int id)
        {
            try
            {
                var visit = db.Visits.Where(i => i.Id == id).FirstOrDefault();
                visit.Title = v.Title;
                visit.PatientSigns = v.PatientSigns;
                visit.Drugs = v.Drugs;
                visit.DoctorIdea = v.DoctorIdea;
                visit.RegDate = v.RegDate;
                visit.IsPayed = v.IsPayed;
                visit.Cost = v.Cost;
                visit.PayDate = v.PayDate;
                db.SaveChanges();
                return "ویرایش ویزیت با موفقیت انجام شد";
            }
            catch (Exception e)
            {
                return " مشکلی در ویرایش ویزیت رخ داده است\n" + e.Message;
            }
        }

        public string Delete(int id)
        {
            try
            {
                Visit visit = db.Visits.Where(i => i.Id == id).FirstOrDefault();
                visit.DeleteStatus = true;
                db.SaveChanges();
                return "حذف ویزیت با موفقیت انجام شد";
            }
            catch (Exception e)
            {
                return " مشکلی در حذف ویزیت رخ داده است\n" + e.Message;
            }
           
        }
    }
}
