﻿using System;
using System.Collections.Generic;
using TicTacToeGame.Domain;
using TicTacToeGame.Factories;
using TicTacToeGame.Services;

namespace TicTacToeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Introduction();
            var players = RegisterPlayers();
            StartANewGame(players);
            DoYouWantToPlayAgain(players);
        }

        private static void Introduction()
        {
            Console.Title = "Tic Tac Toe";
            Console.WriteLine("Welcome to the Tic Tac Toe Game!");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Press enter to start a new game:");
            Console.ReadKey(false);
            Console.WriteLine();
        }

        private static List<IPlayer> RegisterPlayers()
        {
            Console.WriteLine("Player-1: please enter your name");
            var player1Name = Console.ReadLine();
            Console.WriteLine("Player-1: please enter a symbol to play on the board (Example: O or X)");
            var player1Symbol = Console.ReadKey();
            Console.WriteLine();

            Console.WriteLine("Player-2: please enter your name");
            var player2Name = Console.ReadLine();
            Console.WriteLine("Player-2: please enter a symbol to play on the board (Example: O or X)");
            var player2Symbol = Console.ReadKey();
            while (player2Symbol.KeyChar == player1Symbol.KeyChar)
            {
                Console.WriteLine();
                Console.WriteLine("Symbol {0} is already taken by {1}", player2Symbol.KeyChar, player1Name);
                Console.WriteLine("Please choose a different symbol");
                player2Symbol = Console.ReadKey();
            }

            var playerFactory = new PlayerFactory();
            var firstPlayer = playerFactory.Create(player1Name, player1Symbol.KeyChar);
            var secondPlayer = playerFactory.Create(player2Name, player2Symbol.KeyChar);
            Console.WriteLine();
            Console.WriteLine("Details registered. Press any key to begin playing!");
            Console.ReadKey(false);

            return new List<IPlayer> { firstPlayer, secondPlayer};
        }

        private static void StartANewGame(List<IPlayer> players)
        {
            IBoard board = new Board();
            var resultsCheckingService = new ResultsCheckingService();
            var game = new Game(board, resultsCheckingService);
            game.Play(players);
        }

        private static void DoYouWantToPlayAgain(List<IPlayer> players)
        {
            bool wantToPlay;
            do
            {
                Console.WriteLine("Do you want to play an another game?");
                Console.WriteLine("Please enter 'Y' or else Press enter to quit.");
                var wantToPlayAgain = Console.ReadKey();
                Console.WriteLine();
                wantToPlay = wantToPlayAgain.Key.ToString().ToUpperInvariant() == "Y";
                Console.Clear();
                if (wantToPlay)
                {
                    StartANewGame(players);
                }

            } while (wantToPlay);
        }
    }
}
