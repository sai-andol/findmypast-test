using NUnit.Framework;
using TicTacToeGame;
using TicTacToeGame.Domain;
using TicTacToeGame.Factories;

namespace TicTacToeGameTests
{
    [TestFixture]
    public class PlayerFactoryTests
    {
        [Test]
        public void Create_GivenUsernameAndSymbol_ReturnsPlayerObject()
        {
            IBoard board = new Board();
            var factory = new PlayerFactory(board);
            string playerName = "Player1";
            char playerSymbol = 'X';
            var player = factory.Create(playerName,playerSymbol);

            Assert.IsInstanceOf<Player>(player);
            Assert.That(player.Name == playerName);
            Assert.That(player.SymbolOnTheBoard, Is.EqualTo(playerSymbol));
        }
    }
}