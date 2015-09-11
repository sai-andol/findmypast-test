namespace TicTacToeGame.Domain
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public char SymbolOnTheBoard { get; set; }
        public void MakeMove(int positionToMOve)
        {
            throw new System.NotImplementedException();
        }
    }
}