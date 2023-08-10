using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Patient
    {
        public Patient()
        {
            DeleteStatus = false;
        }
        public int id { get; set; }
        public string Name { get; set; }
        public string Credit { get; set; }
        public string Phone { get; set; }
        public string Code { get; set; }
        public string Picture { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }   // true -> female , false -> male
        public DateTime RegDate { get; set; }
        public InsuranceType Insurance { get; set; }
        public bool DeleteStatus { get; set; }
        public Doctor doctor { get; set; }

        public List<Visit> Visits  = new List<Visit>();
        public List<Test> Tests = new List<Test>(); 
    }
    public enum InsuranceType
    {
        TaminEjtemaee,
        Salamat,
        NiroohayeMosallah,
        NoOne
    }
}
