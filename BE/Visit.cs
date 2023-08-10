using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Visit
    {
        public Visit()
        {
            PayDate = DateTime.MinValue;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string PatientSigns { get; set; }
        public string DoctorIdea { get; set; }
        public string Drugs { get; set; }
        public DateTime RegDate { get; set; }
        public bool DeleteStatus { get; set; }
        public bool IsPayed { get; set; }
        public double Cost { get; set; }
        public DateTime PayDate { get; set; }

        public Patient patient { get; set; }

    }
}
