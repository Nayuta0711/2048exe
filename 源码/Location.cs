using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048Consolo
{
    class Location
    {
        public int Rindex { get; set; }
        public int Cindex { get; set; }
        public Location()
        {

        }
        public Location(int Rindex, int Cindex) : this()
        {
            this.Rindex = Rindex;
            this.Cindex = Cindex;
        }
    }
}
