using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Test
    {
        public int id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string Picture { get; set; }
        public DateTime RegDate { get; set; }
        public bool DeleteStatus { get; set; }

        public Patient patient { get; set; }
    }
}
