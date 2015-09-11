using TicTacToeGame.Domain;

namespace TicTacToeGame.Factories
{
    public interface IPlayerFactory
    {
        Player Create(string name, char symbolOnTheBoard);
    }
}