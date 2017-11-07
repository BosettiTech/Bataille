using NetworkCommsDotNet;
using System;
using System.Linq;
using ServerApplication;

namespace ClientApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Request server IP and port number
            Console.WriteLine("Please enter the server IP and port in the format 192.168.0.1:10000 and press return:");
            string serverInfo = Console.ReadLine();

            //Parse the necessary information out of the provided string
            string serverIP = serverInfo.Split(':').First();
            int serverPort = int.Parse(serverInfo.Split(':').Last());
            //Keep a loopcounter
            int loopCounter = 1;
            while (true)
            {
                ServerApplication.messageObject message = new ServerApplication.messageObject("salut");
               
                NetworkComms.SendObject("Message", serverIP, serverPort, message);

                //Check if user wants to go around the loop
                Console.WriteLine("\nPress q to quit or any other key to send another message.");
                if (Console.ReadKey(true).Key == ConsoleKey.Q) break;
                else loopCounter++;
            }

            //We have used comms so we make sure to call shutdown
            NetworkComms.Shutdown();
        }
    }
}
