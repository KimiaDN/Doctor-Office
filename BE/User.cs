using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class User
    {
        public User()
        {
            DeleteStatus = false;
        }
        public int id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public string Cart { get; set; }
        public string Picture { get; set; }
        public DateTime RegDate { get; set; }
        public bool DeleteStatus { get; set; }
        public int VacationNum { get; set; }
        public UserGroup usergroup { get; set; }



        public List<Vacation> Vacations = new List<Vacation>();

        public List<WorkDay> WorkDays = new List<WorkDay>();

        public List<Reminder> reminders = new List<Reminder>();

        public List<Deposit> Deposits = new List<Deposit>(); 
    }
}
