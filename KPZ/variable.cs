using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ
{
    public class variable
    {
        public string name { get; set; }
        public int? digit { get; set; }

        public variable(string name, int? digit)
        {
            this.name = name;
            this.digit = digit;
        }

    }
}
