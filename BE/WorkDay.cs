using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class WorkDay
    {
        public int id { get; set; }
        public string Day { get; set; }
        public string From { get; set; }
        public string Until { get; set; }

        public bool DeleteStatus { get; set; }

        public User user { get; set; }
    }
}
