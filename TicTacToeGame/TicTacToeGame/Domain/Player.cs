namespace TicTacToeGame.Domain
{
    public class Player : IPlayer
    {
        private readonly IBoard _board;

        public Player(IBoard board)
        {
            _board = board;
        }

        public string Name { get; set; }
        public char SymbolOnTheBoard { get; set; }

        public void MakeMove(int positionToMove)
        {
            _board.Update(positionToMove, SymbolOnTheBoard);
        }
    }
}