using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToeGame.Services;

namespace TicTacToeGame.Domain
{
    public class Game
    {
        private readonly IBoard _board;
        public readonly IResultsCheckingService _resultsCheckingService;

        public Game(IBoard board, IResultsCheckingService resultsCheckingService)
        {
            _board = board;
            _resultsCheckingService = resultsCheckingService;
        }

        public void Play(List<IPlayer> players)
        {
            try
            {
                int currentPlayer = 1;
                var firstPlayer = players.First();
                var secondPlayer = players.Last();
                do
                {
                    Console.Clear();
                    _board.Render();
                    if (currentPlayer % 2 == 0)
                    {
                        Console.WriteLine("{0}, your turn, make your move by entering your boardposition:",
                            secondPlayer.Name);
                        int positionToMove = Convert.ToInt32(Console.ReadLine());
                        if (_board.BoardPositions[positionToMove] != firstPlayer.SymbolOnTheBoard &&
                            _board.BoardPositions[positionToMove] != secondPlayer.SymbolOnTheBoard)
                        {
                            secondPlayer.MakeMove(positionToMove);
                        }
                        else
                        {
                            Console.WriteLine("Sorry the position {0} is already taken! Try a diffrent position...",
                                positionToMove);
                        }
                        currentPlayer++;
                    }
                    else
                    {
                        Console.WriteLine("{0}, your turn, make your move by entering your boardposition:",
                            firstPlayer.Name);
                        int positionToMove = Convert.ToInt32(Console.ReadLine());
                        if (_board.BoardPositions[positionToMove] != firstPlayer.SymbolOnTheBoard &&
                            _board.BoardPositions[positionToMove] != secondPlayer.SymbolOnTheBoard)
                        {
                            firstPlayer.MakeMove(positionToMove);
                        }
                        else
                        {
                            Console.WriteLine("Sorry the position {0} is already taken! Try a diffrent position...",
                                positionToMove);
                        }
                        currentPlayer++;
                    }
                } while (!_resultsCheckingService.CheckForAnyResult());

                if (_resultsCheckingService.CheckForDraw())
                {
                    Console.WriteLine("Draw! Game over!");
                }
                else
                {
                    Console.WriteLine(currentPlayer % 2 == 0
                        ? string.Format("{0} won!", firstPlayer.Name)
                        : string.Format("{0} won!", secondPlayer.Name));

                }
            }
            catch (Exception exception)
            {
                throw;
            }

        }
    }
}