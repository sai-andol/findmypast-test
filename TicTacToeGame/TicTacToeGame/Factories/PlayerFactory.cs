using TicTacToeGame.Domain;

namespace TicTacToeGame.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private readonly IBoard _board;

        public PlayerFactory(IBoard board)
        {
            _board = board;
        }

        public Player Create(string name, char symbolOnTheBoard)
        {
            return new Player(_board) {Name = name, SymbolOnTheBoard = symbolOnTheBoard};
        }
    }
}