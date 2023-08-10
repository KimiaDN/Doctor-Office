using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Doctor :User
    {
        public string Speciality { get; set; }
        public string SpecialityNum { get; set; }
        public string SecretaryName { get; set; }

        public List<Patient> Patients = new List<Patient>();
        public Admin admin { get; set; }

    }
}
