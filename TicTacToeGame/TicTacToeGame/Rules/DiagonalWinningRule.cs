using TicTacToeGame.Domain;

namespace TicTacToeGame.Rules
{
    public class DiagonalWinningRule : IGameRule
    {
        private readonly IBoard _board;

        public DiagonalWinningRule(IBoard board)
        {
            _board = board;
        }

        public bool Apply()
        {
            var boardPositions = _board.BoardPositions;
            return (boardPositions[1] == boardPositions[5] && boardPositions[5] == boardPositions[9]) ||
                   (boardPositions[3] == boardPositions[5] && boardPositions[5] == boardPositions[7]);

        }
    }
}