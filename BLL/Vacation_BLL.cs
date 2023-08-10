using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class Vacation_BLL
    {
        Vacation_DAL dal = new Vacation_DAL();

        public string Create(Vacation v, int id)
        {
            if (dal.CheckForCreate(v, id))
            {
                return dal.Create(v, id);
            }
            return "امکان ثبت مرخصی برای این کاربر وجود ندارد";
        }

        public List<Vacation> Read(int id)
        {
            return dal.Read(id);
        }

        public Vacation Find(int id)
        {
            return dal.Find(id);
        }

        public List<Vacation> Search(DateTime date, int id)
        {
            return dal.Search(date,id);
        }

        public string Update(Vacation v, int id)
        {
            if (dal.CheckForUpdateDelete(id))
            {
                return dal.Update(v, id);
            }
            return "پس از گدشت تاریخ تعطیلات امکان ویرایش آن وجود ندارد";
        }

        public string Delete(int id)
        {
            if (dal.CheckForUpdateDelete(id))
            {
                return dal.Delete(id);
            }
            return "پس از گدشت تاریخ تعطیلات امکان حذف آن وجود ندارد";
        }
    }
}
