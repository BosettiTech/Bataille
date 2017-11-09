using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication
{
    [ProtoContract]
    public class Cards
    {
      [ProtoMember(1)]
        public string color;
      [ProtoMember(2)]
        public string rank;

       public Cards() { }
        public override string ToString()
        {
            return String.Format("{0} of {1};", rank, color);
        }
    }
}
