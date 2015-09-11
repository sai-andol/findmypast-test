using NUnit.Framework;
using Rhino.Mocks;
using TicTacToeGame.Domain;
using TicTacToeGame.Rules;

namespace TicTacToeGameTests
{
    [TestFixture]
    public class GameIsADrawRuleTests
    {
        [Test]
        public void GameIsADrawRulePasses_WhenAllResultRulesFail()
        {
            IBoard board = MockRepository.GenerateMock<IBoard>();
            char[] drawBoardPositions = { '0', 'A', 'B', 'C', 'E', 'D', 'G', 'H', 'P', 'X' };
            board.Stub(b => b.BoardPositions).Return(drawBoardPositions);

            var gameIsADrawRule = new GameIsADrawRule(board);

            Assert.IsTrue(gameIsADrawRule.Apply());
        }

        [Test]
        public void GameIsADrawRuleFails_WhenNoneOfTheDiagonals_InTheTicTacToeHasSamePlayerSymbol()
        {
            IBoard board = MockRepository.GenerateMock<IBoard>();
            char[] drawBoardPositions = { '0', 'X', 'X', 'X', '4', '5', '6', '7', '8', '9' };
            board.Stub(b => b.BoardPositions).Return(drawBoardPositions);

            var gameIsADrawRule = new GameIsADrawRule(board);

            Assert.IsFalse(gameIsADrawRule.Apply());
        }
    }
}