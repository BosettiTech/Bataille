using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication
{
    // C'est la qu'on va init le jeu et qu'on fait la logique du serveur 
    class GameManager
    {
        public PlayerObject playerOne;
        public PlayerObject playerTwo;

        public void startGame()
        {
            messageObject message = new messageObject("Hello");

            playerOne.Connect.SendObject("Message", message);
        }
        public GameManager(PlayerObject _playerOne, PlayerObject _playerTwo)
        {
            this.playerOne = _playerOne;
            this.playerTwo = _playerTwo;
        }
    }
}
