using NUnit.Framework;
using Rhino.Mocks;
using TicTacToeGame.Domain;
using TicTacToeGame.Rules;

namespace TicTacToeGameTests
{
    [TestFixture]
    public class DiagonalWinningRuleTests
    {
        [Test]
        public void DiagonalWinningRulePasses_WhenAnyDiagonal_InTheTicTacToeHasSamePlayerSymbol()
        {
            IBoard board = MockRepository.GenerateMock<IBoard>();
            char[] diagonalBoardPositions = { '0', 'X', '2', '3', '4', 'X', '6', '7', '8', 'X' };
            board.Stub(b => b.BoardPositions).Return(diagonalBoardPositions);

            var diagonalWinningRule = new DiagonalWinningRule(board);

            Assert.IsTrue(diagonalWinningRule.Apply());
        }

        [Test]
        public void DiagonalWinningRuleFails_WhenNoneOfTheDiagonals_InTheTicTacToeHasSamePlayerSymbol()
        {
            IBoard board = MockRepository.GenerateMock<IBoard>();
            char[] diagonalBoardPositions = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            board.Stub(b => b.BoardPositions).Return(diagonalBoardPositions);

            var diagonalWinningRule = new DiagonalWinningRule(board);

            Assert.IsFalse(diagonalWinningRule.Apply());
        }
    }
}