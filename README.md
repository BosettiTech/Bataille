### The President Game

# What is this project ? 

In this project we are going to make the president card game into an C# application.

# What are the rules of this game ? 

Here, the server is the game manager and the clients are the players.


The President game is a game between 3 and 8 players. The player with the Queen of Hearts start the game. 
Every trick can be started by any single card or any set of cards of equal rank (for example three fives). Each player in turn must then either pass (i.e. not play any cards), or play face up a card or set of cards, which beats the previous play. 
Any higher single card beats a single card. A set of cards can only be beaten by a higher set containing the same number of cards. So for example if the previous player played two sixes you can beat this with two kings, or two sevens, but not with a single king, and not with three sevens.

It is not necessary to beat the previous play just because you can - passing is always allowed. Also passing does not prevent you from playing the next time your turn comes round.

The play continues as many times around the table as necessary until someone makes a play which everyone else passes.

the player who played last (and highest) to the previous "trick" starts again by leading any card or set of equal cards.
The first player who is out of cards is awarded the highest social rank - this is President. The last player to be left with any cards is known as the Scum.


# What are using to build this project ? 

We are going to go with Networkcomms for .net for the connection between multiple clients and a server.

In the repositor, they are two branches, ****Master*** and ****dev***.

All modifications must be pushed on dev without adding unnecessary files. Which means, if you work on two files, don't git add --all.

When the first version of the game is finished and added to the dev branch, we will push the dev branch into master. 

In the future, we will be adding Unity to build a graphical interface.

# How To Connect differents client to a server

By starting serverApplication.exe, you will be generating an ip and a port to connect to. Then, you connect between 3 and 8 clients by starting clientApplication.exe 

At 8 clients, the server will start the game automatically. If you wish to play without 8 clients, you can send the command start to the server and it will launch the game.



# How to play the game 

The server will deal cards to each players by starting with player one. When there is none card left, the server will select the player with the Queen of Hearts to play first. The game will follow the rule stated before. When a 2 is played, it automatically makes the the player win the trick.

When the Scum is designated, the party will reset to start a new game if players wants to play again. 


# Card Value

The card value will be as follow :

 Three < Four < Five < Six < Seven < Eight < Nine < Ten < Jack < Queen < King < As < 2

# What command is available 

The players will have two commands. 

****Play <number of cards> <card value>****
  
 	Ex : Play single 6 
  
****Pass****

	Ex : Pass

