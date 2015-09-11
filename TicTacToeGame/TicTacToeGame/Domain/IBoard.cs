namespace TicTacToeGame.Domain
{
    public interface IBoard
    {
        void Render();
        char[] BoardPositions { get; }
    }
}