using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class Admin_DAL
    {
        DB db = new DB();

        public string Create(Admin a, UserGroup ug)
        {
            a.usergroup = db.UserGroups.Find(ug.id);
            db.Admins.Add(a);
            db.SaveChanges();
            return "ثبت مدیر در سیستم با موفقیت انجام شد";
        }

        public bool check(User d)
        {
            foreach (var i in db.Users)
            {
                if (i.UserName == d.UserName && i.Password == d.Password && !i.DeleteStatus)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
