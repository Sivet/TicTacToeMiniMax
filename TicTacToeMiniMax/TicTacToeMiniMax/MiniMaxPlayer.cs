using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeMiniMax
{
    class MiniMaxPlayer
    {
        Board board;
        int player;

        int[,] tempBoard;

        public MiniMaxPlayer(Board board, int player)
        {
            this.board = board;
            this.player = player;
        }

        public void Play()
        {
            int count = 0; //min nuværende dybde i træet
            int maxcount = 0; //skal være max dybden jeg går ned i træet

            MiniMax(board);
        }
        private void MiniMax(Board board)
        {
            //variable der holde bedste move
            int bestMoveX = -1;
            int bestMoveY = -1;
            //variable der holder den bedste score
            int bestScore = -999;
            int tempScore;

            for (int x = 0; x < 3; x++) //find alle mulige træk
            {
                for (int y = 0; y < 3; y++)
                {
                    if (tempBoard[x,y] == 0)
                    {
                        tempScore = Min();
                        if (tempScore > bestScore)
                        {
                            //tjek alle træk på min og sæt best score
                            bestScore = tempScore;
                            bestMoveX = x;
                            bestMoveY = y;
                        }
                    }
                }
            }
            //lav det bedste træk på boarded
            board.placeBrick(player, bestMoveX, bestMoveY);
            
        }
        private int Min()
        {

        }
        private int Max()
        {

        }
        private int EVAL()
        {
            if (//jeg vinder)
            {
                return -1;
            }
            if (//modstander vinder)
            {
                return 1;
            }
            if (//uafgjort)
            {
                return 0;
            }
            
            
        }
    }
}
