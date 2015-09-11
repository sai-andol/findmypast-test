# Tic Tac Toe Console app:

----------

##  Solution:  ##
1. The TicTacToeGame solution has two projects:
2. TicTacToe console app project
3. TicTacToe test project
## Explaining the solution: ##
- Main method in Program.cs first registers the players 
- Then starts the Game by calling the play() method on the Game object.
- Game Object is dependent on Board and ResultsCheckingService 
- Board responsibility is to render and update the board
- ResultCheckingService is dependent on a bunch of GameRule objects to Check for any results
- Game Object manages the flow of the Game.

With proper naming in place, the code should read well hopefully.

Note: I did not use an IOC container as this small app would not need one yet. But all dependencies are constructor injected.

User interface: should be intuitive enough to follow.



