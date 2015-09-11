using TicTacToeGame.Domain;

namespace TicTacToeGame.Rules
{
    public class HorizantalWinningRule : IGameRule
    {
        private readonly IBoard _board;

        public HorizantalWinningRule(IBoard board)
        {
            _board = board;
        }

        public bool Apply()
        {
            var boardPositions = _board.BoardPositions;
            return (boardPositions[1] == boardPositions[2] && boardPositions[2] == boardPositions[3]) ||
                   (boardPositions[4] == boardPositions[5] && boardPositions[5] == boardPositions[6]) ||
                   (boardPositions[6] == boardPositions[7] && boardPositions[7] == boardPositions[8]);
        }
    }
}