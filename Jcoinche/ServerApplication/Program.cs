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
        private static bool player1 = false;
        private static bool player2 = false;
        static Dealer Deal = new Dealer();
        static Hand hand = new Hand();
        static Hand _hand = new Hand();
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
                        Deal.CreateDeck();
                        Deal.CardDistribution(hand.HandPlayer1, hand.HandPlayer2);

                        PlayerObject playerOne = new PlayerObject(1, hand.HandPlayer1,"Salut joueur 1 !");
                        PlayerObject playerTwo = new PlayerObject(2,hand.HandPlayer2,"Salut joueur 2 !");
                      
                        GameManager gm = new GameManager(playerOne, playerTwo,fnatic.connectOne,fnatic.connectTwo);

                        gm.startGame();
                        while(end != true)
                        {
                            while (player1 != true || player2 != true)
                            {
                                int i = 0;
                                i++;
                            }
                            if (player1 == true && player2 == true)
                            {
                                gm.CompareCards(hand.Tas, _hand.HandPlayer1, _hand.HandPlayer2);
                                player1 = false;

                            }
                            player2 = false;
                        }
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
                    PlayerObject playerTmp = new PlayerObject(10, hand.HandPlayer1, "The game can begin, anytime it's your turn to play just write PLAY p1");
                    fnatic.connectOne.SendObject("Message", playerTmp);
                }
                if (Equals(player.msg, "Hand received from player2") == true)
                {
                    PlayerObject player2 = new PlayerObject(10, hand.HandPlayer2, "The game can begin, anytime it's your turn to play just write PLAY p2");
                    fnatic.connectTwo.SendObject("Message", player2);
                }      
            }
            if (Equals(player.Id, 20) == true)
            {
                if (Equals(player.msg, "Play from player1") == true)
                {
                    if (player.Hand.Count == 0)
                    {
                        PlayerObject playerTmp = new PlayerObject(0, hand.HandPlayer1, "You have no card left, you lost");
                        fnatic.connectOne.SendObject("Message", playerTmp);
                        end = true;
                    }
                    hand.Tas.Add(player.Hand[0]);
                    _hand.HandPlayer1 = player.Hand;
                    player1 = true;  
                }
                if (Equals(player.msg, "Play from player2") == true)
                {
                    if (player.Hand.Count == 0)
                    {
                        PlayerObject playerTwo = new PlayerObject(0, hand.HandPlayer2, "You have no card left, you lost");
                        fnatic.connectTwo.SendObject("Message", playerTwo);
                        end = true;
                    }
                    hand.Tas.Add(player.Hand[0]);
                    _hand.HandPlayer2 = player.Hand;
                    player2 = true;
                }
            }
        }
    }
}
