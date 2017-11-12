### The War Game

# What is this project ? 

In this project we are going to make the war card game into an C# application.

# What are the rules of this game ? 

Here, the server is the game manager and the clients are the players.

War is a card game typically involving two players. It uses a standard French playing card deck. The value of each card in decreasing order is: A K Q J T 9 8 7 6 5 4 3 2.

The objective of the game is to win all cards.

The deck is divided evenly among the players, giving each a down stack. In unison, each player reveals the top card of their deck – this is a "battle" – and the player with the higher card takes both of the cards played and moves them to their stack. Aces are high, and suits are ignored.

If the two cards played are of equal value, then there is a "war". Both players place the next card of their pile face down, depending on the variant, and then another card face-up. The owner of the higher face-up card wins the war and adds all four (or six) cards on the table to the bottom of their deck. If the face-up cards are again equal then the battle repeats with another set of face-down/up cards. This repeats until one player's face-up card is higher than their opponent's.

Most descriptions of War are unclear about what happens if a player runs out of cards during a war. In some variants, that player immediately loses. In others, the player may play the last card in their deck as their face-up card for the remainder of the war or replay the game from the beginning. Here, the player immediately loses.

# What are using to build this project ? 

We are going to go with Networkcomms for .net for the connection between multiple clients and a server.

In the repositor, they are two branches, **Master** and **dev**.

All modifications must be pushed on dev without adding unnecessary files. Which means, if you work on two files, don't git add --all.

When the first version of the game is finished and added to the dev branch, we will push the dev branch into master.

# How To Connect differents client to a server

By starting serverApplication.exe, you will be generating an ip and a port to connect to. Then, you connect between 2 clients by starting clientApplication.exe 

When the two clients are connected, the game immediatly starts.

# How to play the game 

The server will deal cards to each players by cutting in half a mixed package. Then, the two players can put their cards on the heap by tapping a command.

# Card Value

The card value will be as follow :

2 < Three < Four < Five < Six < Seven < Eight < Nine < Ten < Jack < Queen < King < As

# What command is available 

The players will have only one command. 

****PLAY****

	Ex : PLAY

With this command, you'll see what card is being played and, after both players played, the winner/loser will be announced. You'll need to enter the commande "PLAY" every turn of the game until the end. 
