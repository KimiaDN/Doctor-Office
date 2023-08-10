using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BE
{
    public class Reminder
    {
        public int id { get; set; }
        public string  Title { get; set; }
        public string Info { get; set; }
        public DateTime Date { get; set; }
        public DateTime RegDate { get; set; }
        public bool Done { get; set; }
        public bool DeleteStatus { get; set; }

        public User user { get; set; }
    }
}
