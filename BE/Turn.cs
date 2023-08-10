using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Turn
    {
        public int id { get; set; }
        public string DoctorName { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string PatientName { get; set; }
        public string PatientPhone { get; set; }
        public bool DeleteStatus { get; set; }
    }
}
