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
    public class Turn_BLL
    {
        Turn_DAL dal = new Turn_DAL();
        public string Create(Turn t)
        {
            return dal.Create(t);   
        }

        public List<Turn> Read(string name, DateTime date)
        {
            return dal.Read(name, date);
        }

        public Turn Find(int id)
        {
            return dal.Find(id);
        }
        public string Update(Turn t, int id)
        {
            return dal.Update(t, id);
        }

        public string Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}
