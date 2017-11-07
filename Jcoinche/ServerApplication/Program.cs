using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Trigger the method PrintIncomingMessage when a packet of type 'Message' is received
            //We expect the incoming object to be a string which we state explicitly by using <string>
            NetworkComms.AppendGlobalIncomingPacketHandler<messageObject>("Message", PrintIncomingMessage);
            //Start listening for incoming connections
            Connection.StartListening(ConnectionType.TCP, new System.Net.IPEndPoint(System.Net.IPAddress.Any, 0));
/*
           //Print out the IPs and ports we are now listening on
           Console.WriteLine("Server listening for TCP connection on:");
           foreach (System.Net.IPEndPoint localEndPoint in Connection.ExistingLocalListenEndPoints(ConnectionType.TCP))
              Console.WriteLine("{0}:{1}", localEndPoint.Address, localEndPoint.Port);
              */
            //Let the user close the server
            Console.WriteLine("\nPress any key to close server.");
            Console.ReadKey(true);

            NetworkComms.Shutdown();
        }


        private static void PrintIncomingMessage(PacketHeader header, Connection connection, messageObject message)
        {
            Console.WriteLine("\nA message was received from " + connection.ToString() + " which said '" + message.msg + "'.");
        }
    }
}
