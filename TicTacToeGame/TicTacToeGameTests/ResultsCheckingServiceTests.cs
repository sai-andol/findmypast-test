using NUnit.Framework;
using Rhino.Mocks;
using TicTacToeGame.Domain;
using TicTacToeGame.Rules;
using TicTacToeGame.Services;

namespace TicTacToeGameTests
{
    [TestFixture]
    public class ResultsCheckingServiceTests
    {
        [Test]
        public void CheckForAnyResult_ReturnsTrue_WhenAnyOfTheRulesPasses()
        {
            IGameRule diagonalWinningRule = MockRepository.GenerateMock<IGameRule>();
            IGameRule verticalWinningRule = MockRepository.GenerateMock<IGameRule>();
            IGameRule horizantalWinningRule = MockRepository.GenerateMock<IGameRule>();
            IGameRule gameIsADrawRule = MockRepository.GenerateMock<IGameRule>();

            diagonalWinningRule.Stub(r => r.Apply()).Return(true);
            verticalWinningRule.Stub(r => r.Apply()).Return(false);
            horizantalWinningRule.Stub(r => r.Apply()).Return(false);
            gameIsADrawRule.Stub(r => r.Apply()).Return(false);
            IGameRule[] gameRules =
            {
                diagonalWinningRule,verticalWinningRule,horizantalWinningRule,gameIsADrawRule
            };

            var resultsCheckingService = new ResultsCheckingService(gameRules);

            Assert.IsTrue(resultsCheckingService.CheckForAnyResult());
        }

        [Test]
        public void CheckForAnyResult_ReturnsFalse_WhenAllRulesFails()
        {
            IGameRule diagonalWinningRule = MockRepository.GenerateMock<IGameRule>();
            IGameRule verticalWinningRule = MockRepository.GenerateMock<IGameRule>();
            IGameRule horizantalWinningRule = MockRepository.GenerateMock<IGameRule>();
            IGameRule gameIsADrawRule = MockRepository.GenerateMock<IGameRule>();

            diagonalWinningRule.Stub(r => r.Apply()).Return(false);
            verticalWinningRule.Stub(r => r.Apply()).Return(false);
            horizantalWinningRule.Stub(r => r.Apply()).Return(false);
            gameIsADrawRule.Stub(r => r.Apply()).Return(false);
            IGameRule[] gameRules =
            {
                diagonalWinningRule,verticalWinningRule,horizantalWinningRule,gameIsADrawRule
            };

            var resultsCheckingService = new ResultsCheckingService(gameRules);

            Assert.IsFalse(resultsCheckingService.CheckForAnyResult());
        }

        [Test]
        public void CheckForDraw_ReturnsTrue_WhenDrawRulePasses()
        {
            IGameRule diagonalWinningRule = MockRepository.GenerateMock<IGameRule>();
            IGameRule verticalWinningRule = MockRepository.GenerateMock<IGameRule>();
            IGameRule horizantalWinningRule = MockRepository.GenerateMock<IGameRule>();
            IBoard board = MockRepository.GenerateMock<IBoard>();
            char[] drawBoardPositions = { '0', 'A', 'B', 'C', 'E', 'D', 'G', 'H', 'P', 'X' };
            board.Stub(b => b.BoardPositions).Return(drawBoardPositions);
            IGameRule gameIsADrawRule = new GameIsADrawRule(board);

            diagonalWinningRule.Stub(r => r.Apply()).Return(false);
            verticalWinningRule.Stub(r => r.Apply()).Return(false);
            horizantalWinningRule.Stub(r => r.Apply()).Return(false);
            IGameRule[] gameRules =
            {
                diagonalWinningRule,verticalWinningRule,horizantalWinningRule,gameIsADrawRule
            };

            var resultsCheckingService = new ResultsCheckingService(gameRules);

            Assert.IsTrue(resultsCheckingService.CheckForDraw());
        }

        [Test]
        public void CheckForDraw_ReturnsFalse_WhenDrawRuleFails()
        {
            IGameRule diagonalWinningRule = MockRepository.GenerateMock<IGameRule>();
            IGameRule verticalWinningRule = MockRepository.GenerateMock<IGameRule>();
            IGameRule horizantalWinningRule = MockRepository.GenerateMock<IGameRule>();
            IBoard board = MockRepository.GenerateMock<IBoard>();
            char[] drawBoardPositions = { '0', 'X', 'X', 'X', '4', '5', '6', '7', '8', '9' };
            board.Stub(b => b.BoardPositions).Return(drawBoardPositions);
            IGameRule gameIsADrawRule = new GameIsADrawRule(board);

            diagonalWinningRule.Stub(r => r.Apply()).Return(false);
            verticalWinningRule.Stub(r => r.Apply()).Return(false);
            horizantalWinningRule.Stub(r => r.Apply()).Return(false);
            IGameRule[] gameRules =
            {
                diagonalWinningRule,verticalWinningRule,horizantalWinningRule,gameIsADrawRule
            };

            var resultsCheckingService = new ResultsCheckingService(gameRules);

            Assert.IsFalse(resultsCheckingService.CheckForDraw());
        }
    }
}