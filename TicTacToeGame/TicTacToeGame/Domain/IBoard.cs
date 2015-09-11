namespace TicTacToeGame.Domain
{
    public interface IBoard
    {
        void Render();
        char[] BoardPositions { get; }
        void Update(int positionToMove, char symbolOnTheBoard);
    }
}