using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Vacation
    {
        public int id { get; set; }
        public DateTime Date { get; set; }
        public DateTime RegDate { get; set; }
        public string Info { get; set; }
        public bool DeleteStatus { get; set; }

        public User user { get; set; }
    }
}
