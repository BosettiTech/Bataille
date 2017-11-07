using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// envoyer message entre serveur et client
namespace ServerApplication
{
    [ProtoContract]
   public class messageObject
    {
        [ProtoMember(1)]
        public string msg { get; private set; }

      protected messageObject() { }

        public messageObject(string _msg)
        {
            this.msg = _msg;
        }
    }
}
