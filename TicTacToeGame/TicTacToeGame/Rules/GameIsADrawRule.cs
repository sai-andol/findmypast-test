using System.Linq;
using TicTacToeGame.Domain;

namespace TicTacToeGame.Rules
{
    public class GameIsADrawRule : IGameRule
    {
        private readonly IBoard _board;
        private readonly IGameRule[] _rules;

        public GameIsADrawRule(IBoard board, params IGameRule[] rules)
        {
            _board = board;
            _rules = rules;
        }

        public bool Apply()
        {
            var boardPositions = _board.BoardPositions;
            return _rules.All(rule => !rule.Apply()) &&
                   (AreAllBoardPositionsFilled(boardPositions));
        }

        private static bool AreAllBoardPositionsFilled(char[] boardPositions)
        {
            return boardPositions[1] != '1' &&
                   boardPositions[2] != '2' &&
                   boardPositions[3] != '3' &&
                   boardPositions[4] != '4' &&
                   boardPositions[5] != '5' &&
                   boardPositions[6] != '6' &&
                   boardPositions[7] != '7' &&
                   boardPositions[8] != '8' &&
                   boardPositions[9] != '9';
        }
    }
}