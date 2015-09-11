namespace TicTacToeGame.Domain
{
    public interface IPlayer
    {
        string Name { get; set; }
        char SymbolOnTheBoard { get; set; }
        void MakeMove(int positionToMOve);
    }
}