using BE;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DB : DbContext
    {
        public DB(): base("Constr")
        {

        }

        public DbSet<User> Users { get; set; }  
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Secretary> Secretaries { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<WorkDay> WorkDays { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserAccessRole> UserAccessRoles { get; set; }
        public DbSet<Turn> Turns { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
    }
}
