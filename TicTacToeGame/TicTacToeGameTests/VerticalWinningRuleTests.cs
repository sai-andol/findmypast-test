using NUnit.Framework;
using Rhino.Mocks;
using TicTacToeGame.Domain;
using TicTacToeGame.Rules;

namespace TicTacToeGameTests
{
    [TestFixture]
    public class VerticalWinningRuleTests
    {
        [Test]
        public void VerticalWinningRulePasses_WhenAnyColumn_InTheTicTacToeHasSamePlayerSymbol()
        {
            IBoard board = MockRepository.GenerateMock<IBoard>();
            char[] verticalBoardPositions = { '0', 'X', '2', '3', 'X', '5', '6', 'X', '8', '9' };
            board.Stub(b => b.BoardPositions).Return(verticalBoardPositions);

            var verticalWinningRule = new VerticalWinningRule(board);

            Assert.IsTrue(verticalWinningRule.Apply());
        }

        [Test]
        public void VerticalWinningRuleFails_WhenNoneOfTheColumns_InTheTicTacToeHasSamePlayerSymbol()
        {
            IBoard board = MockRepository.GenerateMock<IBoard>();
            char[] verticalBoardPositions = { '0', 'X', '2', '3', 'Y', '5', '6', 'X', '8', '9' };
            board.Stub(b => b.BoardPositions).Return(verticalBoardPositions);

            var verticalWinningRule = new VerticalWinningRule(board);

            Assert.IsFalse(verticalWinningRule.Apply());
        }
    }
}