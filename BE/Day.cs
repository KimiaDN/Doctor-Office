using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Day
    {
        public int id { get; set; }
        public DateTime CorrentDate { get; set; }
        public bool SecretaryCome { get; set; }
        public bool AccountantCome { get; set; }
        public float SecretaryHours { get; set; }
        public float AccountantHour { get; set; }
    }
}
