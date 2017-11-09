using NetworkCommsDotNet.Connections;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication
{
    [ProtoContract]
    public class PlayerObject
    {
        [ProtoMember(1)]
        public int Id { get; private set; }

        [ProtoMember(2)]
       public List<Cards> Hand { get; private set; }

        [ProtoMember(3)]
        public string msg { get; private set; }
        public PlayerObject() { }
        public PlayerObject(int _id,List<Cards> _hand,string _msg)
        {
            this.Id = _id;
            this.Hand = _hand;
            this.msg = _msg;
        }
    }
}
