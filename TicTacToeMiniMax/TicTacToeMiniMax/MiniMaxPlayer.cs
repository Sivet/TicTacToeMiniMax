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
            //variable der holder den bedste score

            //find alle mulige træk
            //tjek alle træk på min og sæt best score

            //lav det bedste træk på boarded
        }
    }
}
