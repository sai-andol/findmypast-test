namespace TicTacToeGame.Services
{
    public interface IResultsCheckingService
    {
        bool CheckForAnyResult();
        bool CheckForDraw();
    }
}