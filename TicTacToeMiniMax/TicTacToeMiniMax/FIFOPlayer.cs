using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeMiniMax
{
    class FIFOPlayer
    {
        Board board;
        Random rand;
        int x, y, player;
        int[,] tempBoard;

        public FIFOPlayer(Board board, int player)
        {
            this.board = board;
            this.player = player;
        }
        public void Play()
        {
            tempBoard = board.getTempBoard();
            rand = new Random();

            for (int x = 0; x <= 2; x++)
            {
                for (int y = 0; y <= 2; y++)
                {
                    if (tempBoard[x,y] == 0)
                    {
                        board.placeBrick(player, x, y);
                        goto done;
                    }
                }
            }
            done:;
            
        }
    }
}
