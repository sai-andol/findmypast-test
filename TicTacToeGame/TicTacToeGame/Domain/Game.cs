using System;
using System.Collections.Generic;

namespace TicTacToeGame.Domain
{
    public class Game
    {
        private readonly IBoard _board;

        public Game(IBoard board)
        {
            _board = board;
        }

        public void Play(List<IPlayer> players)
        {
            Console.Clear();
            _board.Render();
        }
    }
}