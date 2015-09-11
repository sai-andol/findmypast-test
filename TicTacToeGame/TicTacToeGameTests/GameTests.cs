using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using TicTacToeGame;
using TicTacToeGame.Domain;

namespace TicTacToeGameTests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void Play_CallsBoardGame_ToDrawTheTicTacToeBoard()
        {
            //Arrange
            IBoard board = MockRepository.GenerateMock<IBoard>();
            var players = new List<IPlayer>();
            var game = new Game(board);

            //Act
            game.Play(players);

            //Assert
            board.AssertWasCalled(b => b.Render());
        }
    }
}