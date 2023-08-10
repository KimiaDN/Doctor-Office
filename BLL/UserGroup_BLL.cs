using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;

namespace BLL
{
    public class UserGroup_BLL
    {
        UserGroup_DAL dal = new UserGroup_DAL();

        public string Create(UserGroup ug)
        {
            return dal.Create(ug);
        }

        public List<UserGroup> Read()
        {
            return dal.Read();
        }

        public List<string> Read_ByName()
        {
            return dal.Read_ByName();
        }
        public UserGroup Find(int id)
        {
            return dal.Find(id);
        }


        public UserGroup Find_ByName(string s)
        {
            return dal.Find_ByName(s);
        }

        public string Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}
