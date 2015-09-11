﻿namespace TicTacToeGame
{
    public class PlayerFactory : IPlayerFactory
    {
        public Player Create(string name, char symbolOnTheBoard)
        {
            return new Player() {Name = name, SymbolOnTheBoard = symbolOnTheBoard};
        }
    }
}