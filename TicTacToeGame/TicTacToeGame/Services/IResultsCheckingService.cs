namespace TicTacToeGame.Services
{
    public interface IResultsCheckingService
    {
        bool CheckForAnyResult();
        bool CheckForAWin();
        bool CheckForDraw();
    }
}