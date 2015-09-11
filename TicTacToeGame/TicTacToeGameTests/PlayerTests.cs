using NUnit.Framework;
using Rhino.Mocks;
using TicTacToeGame.Domain;

namespace TicTacToeGameTests
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void MakeMove_GivenAPositionToMove_CallsUpdateOnTheBoard()
        {
            IBoard board = MockRepository.GenerateMock<IBoard>();
            var player = new Player(board) {Name ="username", SymbolOnTheBoard = 'Y'};
            int positionToMove =3;

            player.MakeMove(positionToMove);

            board.AssertWasCalled(b => b.Update(positionToMove, player.SymbolOnTheBoard));
        }
    }
}