using System;

namespace TicTacToeGame.Domain
{
    public class Board : IBoard
    {
        public char[] BoardPositions { get; } = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public void Render()
        {
            Draw();
        }

        private void Draw()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", BoardPositions[1], BoardPositions[2], BoardPositions[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", BoardPositions[4], BoardPositions[5], BoardPositions[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", BoardPositions[7], BoardPositions[8], BoardPositions[9]);
            Console.WriteLine("     |     |      ");
        }
    }
}