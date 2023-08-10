using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BLL;
using DAL;

namespace BLL
{
    public class WorkDay_BLL
    {
        WorkDay_DAL dal = new WorkDay_DAL();

        public string create(WorkDay wd, int id)
        {
           return dal.create(wd, id);
        }

        public string Update(WorkDay wd, int id)
        {
            return dal.Update(wd, id);
        }

        public string Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}
