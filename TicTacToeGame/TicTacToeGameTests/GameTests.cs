using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;
using TicTacToeGame;
using TicTacToeGame.Domain;
using TicTacToeGame.Services;

namespace TicTacToeGameTests
{
    [TestFixture]
    public class GameTests
    {
        private IBoard _board;

        [SetUp]
        public void Setup()
        {
            _board = MockRepository.GenerateMock<IBoard>();

        }

        [Test]
        public void Play_CallsBoardGame_ToDrawTheTicTacToeBoard()
        {
            //Arrange
            var players = new List<IPlayer>();
            IResultsCheckingService resultsCheckingService
                = new ResultsCheckingService();
            var game = new Game(_board, resultsCheckingService);

            //Act
            game.Play(players);

            //Assert
            _board.AssertWasCalled(b => b.Render());
        }

        [Test]
        public void Play_MustAlternateBetweenThePlayersWhenCalled()
        {
            //Arrange
            var player1 = MockRepository.GenerateMock<IPlayer>();
            var player2 = MockRepository.GenerateMock<IPlayer>();
            var players = new List<IPlayer>() { player1, player2 };
            _board.Stub(b => b.Render());
            IResultsCheckingService resultsCheckingService
                = new ResultsCheckingService();
            var game = new Game(_board, resultsCheckingService);

            //Act
            for (int i = 0; i < 2; i++)
            {
                game.Play(players);

            }

            //Assert
            player1.AssertWasCalled(p1 => p1.MakeMove(Arg<int>.Is.Anything), options => options.Repeat.Once());
            player2.AssertWasCalled(p2 => p2.MakeMove(Arg<int>.Is.Anything), options => options.Repeat.Once());


        }


    }
}