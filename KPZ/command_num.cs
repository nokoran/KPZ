using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPZ
{
    class command_num
    {
        public int command { get; set; }
        public string variable { get; set; }
        public int compare { get; set; }
        public string sign { get; set; }

        public command_num(int command, string variable)
        {
            this.command = command;
            this.variable = variable;
            this.compare = 0;
            this.sign = null;
        }
        public command_num(int command, string variable, int compare, string sign)
        {
            this.command = command;
            this.variable = variable;
            this.compare = compare;
            this.sign = sign;
        }
    }
}
