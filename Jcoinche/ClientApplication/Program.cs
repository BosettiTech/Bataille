using NetworkCommsDotNet;
using System;
using System.Linq;
using ServerApplication;
using NetworkCommsDotNet.Connections;
using System.Collections.Generic;

namespace ClientApplication
{
    class Program
    {
        static List<Cards> _hand = new List<Cards>(); 
        static void Main(string[] args)
        {
            NetworkComms.AppendGlobalIncomingPacketHandler<PlayerObject>("Message", PrintIncomingMessage);

            Console.WriteLine("Please enter the server IP and port in the format 192.168.0.1:10000 and press return:");
            string serverInfo = Console.ReadLine();

            string serverIP = serverInfo.Split(':').First();
            int serverPort = int.Parse(serverInfo.Split(':').Last());
            int loopCounter = 1;

            while (true)
            {
                PlayerObject message = new PlayerObject(18,_hand,"Connected");
                NetworkComms.SendObject("Message", serverIP, serverPort, message);

                Console.WriteLine("\nPress q to quit or any other key to send another message.");
                if (Console.ReadKey(true).Key == ConsoleKey.Q) break;
                else loopCounter++;
            }
            NetworkComms.Shutdown();
        }
        private static void PrintIncomingMessage(PacketHeader header, Connection connection, PlayerObject player)
        {
            Console.WriteLine(player.msg);
            PrintCollection(player.Hand);
        }
        public static void PrintCollection<T>(IEnumerable<T> col)
        {
            foreach (var item in col)
                Console.WriteLine(item);
        }
    }
}
