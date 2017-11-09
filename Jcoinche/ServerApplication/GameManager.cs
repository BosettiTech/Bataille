using NetworkCommsDotNet.Connections;

namespace ServerApplication
{
    class GameManager
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
    }
}
