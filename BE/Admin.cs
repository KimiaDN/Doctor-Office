using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Admin: User
    {
        public List<Doctor> Doctors = new List<Doctor>();

        public List<Secretary> Secretaries = new List<Secretary>();
    }
    
}
