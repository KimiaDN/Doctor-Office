using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class User_DAL
    {
        DB db = new DB();

        public User find(string s)
        {
            return db.Users.Where(i => i.Name == s).FirstOrDefault();
        }

        public User Login(string u, string p)
        {
            return db.Users.Where(i => i.UserName == u && i.Password == p).Include("usergroup").FirstOrDefault();
        }

        public List<string> Read_UsersName()
        {
            return db.Users.Select(i => i.Name).ToList();
        }

        public bool IsRegistered()
        {
            return db.Users.Count() > 0;
        }

        public bool IsDoctor(User u)
        {
            UserGroup ug = db.UserGroups.Where(i => i.id == u.usergroup.id).FirstOrDefault();
            if (ug.Title == "پزشک")
            {
                return true;
            }
            return false;
        }

        public bool IsSecretary(User u)
        {
            UserGroup ug = db.UserGroups.Where(i => i.id == u.usergroup.id).FirstOrDefault();
            if (ug.Title == "منشی")
            {
                return true;
            }
            return false;
        }

        public bool Access(User u, int code, int a)
        {
            UserGroup ug = db.UserGroups.Where(i => i.id == u.usergroup.id).Include("UserAccessRoles").FirstOrDefault();
            UserAccessRole uac = ug.UserAccessRoles.Where(i => i.Code == code).FirstOrDefault();
            if (a == 1)
            {
                return uac.CanEnter;
            }
            else if (a == 2)
            {
                return uac.CanCreate;
            }
            else if (a == 3)
            {
                return uac.CanUpdate;
            }
            else
            {
                return uac.CanDelete;
            }
        }
    }
}
