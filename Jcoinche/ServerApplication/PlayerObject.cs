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
        public int id { get; private set; }

        [ProtoMember(2)]
        public List<string> hand { get; private set; }

        [ProtoMember(3)]
        public Connection connect { get; private set; }
       // protected PlayerObject() { }

        public PlayerObject(int _id, Connection _connect, List<string> _hand)
        {
            this.id = _id;
            this.connect = _connect;
            this.hand = _hand;
        }
    }
}
