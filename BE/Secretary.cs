using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Secretary : User
    {
        public Doctor doctor { get; set; }
        public Admin admin { get; set; }
        public string Education { get; set; }

    }
}
