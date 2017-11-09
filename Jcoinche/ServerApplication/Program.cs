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
        private static int nb_client = 0;
        private static bool end = false;
        private static bool once = true;
        private static bool receiving = false;
        static Dealer Deal = new Dealer();
        static Hand hand = new Hand();
        static Handler fnatic = new Handler();
        static void Main(string[] args)
        {
            NetworkComms.AppendGlobalIncomingPacketHandler<PlayerObject>("Message", ConnectionHandler);

            Connection.StartListening(ConnectionType.TCP, new System.Net.IPEndPoint(System.Net.IPAddress.Any, 0));

           Console.WriteLine("Server listening for TCP connection on:");
           foreach (System.Net.IPEndPoint localEndPoint in Connection.ExistingLocalListenEndPoints(ConnectionType.TCP))
            Console.WriteLine("{0}:{1}", localEndPoint.Address, localEndPoint.Port);

           while (end != true)
            {
                if (nb_client == 2)
                {
                    if (once == true)
                    {
                        once = false;
                        Console.WriteLine("Two Client Connected");
                        Deal.CreateDeck();
                        Deal.CardDistribution(hand.HandPlayer1, hand.HandPlayer2);

                        PlayerObject playerOne = new PlayerObject(1, hand.HandPlayer1,"Test");
                        PlayerObject playerTwo = new PlayerObject(2,hand.HandPlayer2,"Salut");
                      
                        GameManager gm = new GameManager(playerOne, playerTwo,fnatic.connectOne,fnatic.connectTwo);

                        gm.startGame();
                    }
                }
            }
            Console.WriteLine("\nPress any key to close server.");
            Console.ReadKey(true);

            NetworkComms.Shutdown();
        }

        private static void ConnectionHandler(PacketHeader header, Connection connection, PlayerObject player)
        {
            if (Equals(player.msg, "Connected") == true)
                nb_client++;
            if (nb_client == 1)
            {
                fnatic.connectOne = connection;
            }
            if (nb_client == 2)
            {
                fnatic.connectTwo = connection;
            }
            if (Equals(player.Id, 10) == true)
            {
                if (Equals(player.msg, "Hand received from player1") == true)
                {
                    PlayerObject playerTmp = new PlayerObject(11, hand.HandPlayer1, "The game can begin, anytime it's your turn to play just write PLAY");
                    fnatic.connectOne.SendObject("Message", playerTmp);
                }
                if (Equals(player.msg, "Hand received from player2") == true)
                {
                    PlayerObject player2 = new PlayerObject(12, hand.HandPlayer2, "The game can begin, anytime it's your turn to play just write PLAY");
                    fnatic.connectTwo.SendObject("Message", player2);
                }      
            }
        }
    }
}
