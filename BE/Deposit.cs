using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Deposit
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Cart { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public bool DeleteStatus { get; set; }

        public User user { get; set; }

    }
}
