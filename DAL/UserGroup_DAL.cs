using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class UserGroup_DAL
    {
        DB db = new DB();

        public string Create(UserGroup ug)
        {
            db.UserGroups.Add(ug);
            db.SaveChanges();
            return "ثبت گروه کاربری با موفقیت انجام شد";
        }

        public List<UserGroup> Read()
        {
            return db.UserGroups.Where(i => i.DeleteStatus == false).ToList();
        }

        public List<string> Read_ByName()
        {
            return db.UserGroups.Where(i => i.DeleteStatus == false).Select(i => i.Title).ToList();
        }

        public UserGroup Find(int id)
        {
            return db.UserGroups.Where(i => i.id == id).Include("UserAccessRoles").FirstOrDefault();
        }


        public UserGroup Find_ByName(string s)
        {
            return db.UserGroups.Where(i => i.Title == s).FirstOrDefault();
        }
        public string Delete(int id)
        {
            var q = db.UserGroups.Where(i => i.id == id).FirstOrDefault();
            q.DeleteStatus = true;
            db.SaveChanges();
            return "حدف گروه کاربری با موفقیت انجام شد";
        }
    }
}
