# CardGames

# CONNECTION

la connection entre le serveur et le client se fait grace à la librairie networkcomms.net.
notre communication est basé sur l'envoie d'un object PlayerObject:

 
    public class PlayerObject
    {
        public int Id { get; private set; }

       public List<Cards> Hand { get; private set; }

        public string msg { get; private set; }
        
        public PlayerObject() { }
        
        public PlayerObject(int _id,List<Cards> _hand,string _msg)
        {
            this.Id = _id;
            this.Hand = _hand;
            this.msg = _msg;
        }
    }
 
 
 A chaque fois que le client ou le serveur envoie un message, celui-ci se différencie avec un ID différents ou un message différents pour chaque joueur.

Chaque PlayerObject envoyé se compose d'une List<Cards> qui est la main du joueur. La class Cards se compose de : 



      public class Card {
        public string color;

        public string rank;

       public Cards() { }
        public override string ToString()
        {
            return String.Format("{0} of {1};", rank, color);
        }
    }
# SERVEUR
Le serveur va s'occuper de gérer l'algorithme du jeu, de créer les cartes et il s'occupe de relier les différents messages du serveur a une fonction précise 

# CLIENT

Le client envoie la commande PLAY qui permet de jouer la première carte de sa main 
