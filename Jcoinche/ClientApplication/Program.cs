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
        static List<Cards> tmp = new List<Cards>();
        static ServerInfo serv = new ServerInfo();
        static private bool end = false;
        static private bool once = false;
        static void Main(string[] args)
        {
            NetworkComms.AppendGlobalIncomingPacketHandler<PlayerObject>("Message", PrintIncomingMessage);

            Console.WriteLine("Please enter the server IP and port in the format 192.168.0.1:10000 and press return:");
            string serverInfo = Console.ReadLine();

           serv.serverIp = serverInfo.Split(':').First();
            serv.serverPort = int.Parse(serverInfo.Split(':').Last());
            int loopCounter = 1;

            while (end != true)
            {
                if (once == false)
                {
                    PlayerObject message = new PlayerObject(5, tmp, "Connected");
                    NetworkComms.SendObject("Message", serv.serverIp, serv.serverPort, message);
                    once = true;
                }
               

                Console.WriteLine("\nPress q to quit or any other key to send another message.");
                if (Console.ReadKey(true).Key == ConsoleKey.Q) break;
                else loopCounter++;
            }
            NetworkComms.Shutdown();
        }
        private static void PrintIncomingMessage(PacketHeader header, Connection connection, PlayerObject player)
        {
            Console.WriteLine(player.msg);
            Hand _hand = new Hand();
            if (Equals(player.Id, 1) == true)
            {
                Console.WriteLine(player.msg);
                _hand.HandPlayer1 = player.Hand;
                PrintCollection(_hand.HandPlayer1);
                PlayerObject message = new PlayerObject(10, tmp, "Hand received from player1");
                NetworkComms.SendObject("Message", serv.serverIp, serv.serverPort, message);
            }
            if (Equals(player.Id,2) == true)
            {
                Console.WriteLine(player.msg);
                _hand.HandPlayer2 = player.Hand;
                PrintCollection(_hand.HandPlayer2);
                PlayerObject message = new PlayerObject(10, tmp, "Hand received from player2");
                NetworkComms.SendObject("Message", serv.serverIp, serv.serverPort, message);
            }
        }
        public static void PrintCollection<T>(IEnumerable<T> col)
        {
            foreach (var item in col)
                Console.WriteLine(item);
        }
    }
}
