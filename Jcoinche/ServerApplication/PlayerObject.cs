using NetworkCommsDotNet.Connections;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//    Class serialize pour envoyer entre server et client 

namespace ServerApplication
{
    [ProtoContract]
    class PlayerObject
    {
        [ProtoMember(1)]
        public int Id { get; private set; }

        [ProtoMember(2)]
        public List<Cards> Hand { get; private set; }

        [ProtoMember(3)]
        public Connection Connect { get; private set; }
       // protected PlayerObject() { }
        public PlayerObject(int _id, Connection _connect, List<Cards> _hand)
        {
            this.Id = _id;
            this.Connect = _connect;
            this.Hand = _hand;
        }
    }
}
