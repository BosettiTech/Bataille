using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication
{
    class Cards
    {
        public string color;
        public string rank;

        public override string ToString()
        {
            return String.Format("{0} of {1};", rank, color);
        }
    }
}
