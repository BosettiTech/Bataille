using NetworkCommsDotNet.Connections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ServerApplication
{
   public class GameManager
    {
        public PlayerObject playerOne;
        public PlayerObject playerTwo;
        public Connection c1;
        public Connection c2;

        public void startGame()
        {
            c1.SendObject("Message", playerOne);
            c2.SendObject("Message", playerTwo);
        }

        public GameManager(PlayerObject _playerOne, PlayerObject _playerTwo, Connection _c1, Connection _c2)
        {
            this.playerOne = _playerOne;
            this.playerTwo = _playerTwo;
            this.c1 = _c1;
            this.c2 = _c2;
        }
        public void CompareCards(List<Cards> tas,List<Cards>p1,List<Cards>p2)
        {
            PlayerObject _player1;
            PlayerObject _player2;
            int i = 0;
            int j = 0;
            int even = tas.Count;
            string first;
            string second;

            if (even % 2 == 0)
            {
                first = tas[even - 2].ToString().Split(' ').First();
                second = tas[even - 1].ToString().Split(' ').First();

                i = Bataille(first);
                j = Bataille(second);
            }

            if (i > j)
            {
                int tmp = tas.Count;
                p1.RemoveAt(0);
                p2.RemoveAt(0);

                for(int cpt = 0; cpt < tas.Count; cpt++)
                {
                    p1.Add(tas[cpt]);
                    tas.RemoveAt(cpt);
                }
                while(tas.Count != 0)
                {
                    tas.RemoveAt(0);
                }
                _player1 = new PlayerObject(20, p1, "You won this round");
                _player2 = new PlayerObject(20, p2, "You lost this round");
                c1.SendObject("Message", _player1);
                c2.SendObject("Message", _player2);
            }
            else if (i == j)
            {
                p2.RemoveAt(0);
                p1.RemoveAt(0);
                _player1 = new PlayerObject(20, p1, "TIE ! ITS WAR : Play another card");
                _player2 = new PlayerObject(20, p2, "TIE ! ITS WAR : Play another card");
                c1.SendObject("Message", _player1);
                c2.SendObject("Message", _player2);
            }
            else if (i < j)
            {
                int tmp = tas.Count;
                p1.RemoveAt(0);
                p2.RemoveAt(0);
                for (int cpt = 0; cpt < tas.Count; cpt++)
                {
                    p2.Add(tas[cpt]);
                    tas.RemoveAt(cpt);
                }
                while (tas.Count != 0)
                {
                    tas.RemoveAt(0);
                }
                _player1 = new PlayerObject(20, p1, "You lost this round");
                _player2 = new PlayerObject(20, p2, "You won this round");
                c1.SendObject("Message", _player1);
                c2.SendObject("Message", _player2);
            }
        }

        public int Bataille(string f)
        {
;           int i = 0;

            switch (f)
            {
                case "two":
                    i = 2;
                    break;
                case "three":
                    i = 3;
                    break;
                case "four":
                    i = 4;
                    break;
                case "five":
                    i = 5;
                    break;
                case "six":
                    i = 6;
                    break;
                case "seven":
                    i = 7;
                    break;
                case "eight":
                    i = 8;
                    break;
                case "nine":
                    i = 9;
                    break;
                case "ten":
                    i = 10;
                    break;
                case "jack":
                    i = 11;
                    break;
                case "queen":
                    i = 12;
                    break;
                case "king":
                    i = 13;
                    break;
                case "ace":
                    i = 14;
                    break;
            }
            return i;
        }
        public void PrintCollection<T>(IEnumerable<T> col)
        {
            foreach (var item in col)
                Console.WriteLine(item);
        }
    }
}
