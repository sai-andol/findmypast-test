using NUnit.Framework;
using Rhino.Mocks;
using TicTacToeGame.Domain;
using TicTacToeGame.Rules;

namespace TicTacToeGameTests
{
    [TestFixture]
    public class HorizantalWinningRuleTests
    {
        [Test]
        public void HorizantalWinningRulePasses_WhenAnyRowInTheTicTacToeHasSamePlayerSymbol()
        {
            IBoard board = MockRepository.GenerateMock<IBoard>();
            char[] horizantalWinningBoardPositions = { '0', 'X', 'X', 'X', '4', '5', '6', '7', '8', '9' }; ;
            board.Stub(b => b.BoardPositions).Return(horizantalWinningBoardPositions);

            var horizantalWinningRule = new HorizantalWinningRule(board);

            Assert.IsTrue(horizantalWinningRule.Apply());
        }

        [Test]
        public void HorizantalWinningRuleFails_WhenNoneOfTheRowInTheTicTacToeHasSamePlayerSymbol()
        {
            IBoard board = MockRepository.GenerateMock<IBoard>();
            char[] horizantalWinningBoardPositions = { '0', 'X', 'Y', 'X', 'X', 'Y', 'X', 'X', 'Y', 'X' }; ;
            board.Stub(b => b.BoardPositions).Return(horizantalWinningBoardPositions);

            var horizantalWinningRule = new HorizantalWinningRule(board);

            Assert.IsFalse(horizantalWinningRule.Apply());
        }
    }
}