namespace TicTacToeGame
{
    public interface IPlayerFactory
    {
        Player Create(string name, char symbolOnTheBoard);
    }
}