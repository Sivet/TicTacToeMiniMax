using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeMiniMax
{
    class RandomPlayer
    {
        Board board;
        Random rand;
        int x, y, player;
        int[,] tempBoard;

        public RandomPlayer(Board board, int player)
        {
            this.board = board;
            this.player = player;
        }
        public void Play()
        {
            tempBoard = board.getTempBoard();
            rand = new Random();

            while (tempBoard[x, y] != 0)
            {
                x = rand.Next(0, 2);
                y = rand.Next(0, 2);
            }
            board.placeBrick(x, y, player);
        }
    }
}
