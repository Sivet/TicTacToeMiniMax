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
            if (checkForWin() == 0)
            {
                return 0;
            }
            if (checkForWin() == player)
            {
                return -1;
            }
            else
            {
                return 1;
            }
            
        }
        private int checkForWin() //holder ikke styr på turene, så bliver den kaldt i en situation hvos boarded ikke er fyldt og ingen vinder, så fejler den
        {
            if (tempBoard[0, 0] == tempBoard[0, 1] && tempBoard[0, 0] == tempBoard[0, 2] && tempBoard[0, 0] != 0)
            { //de 3 vandret øverste er ens
                return tempBoard[0, 0];
            }
            if (tempBoard[1, 0] == tempBoard[1, 1] && tempBoard[1, 0] == tempBoard[1, 2] && tempBoard[1, 0] != 0)
            { //de 3  vandret midten er ens
                return tempBoard[1, 0];
            }
            if (tempBoard[2, 0] == tempBoard[2, 1] && tempBoard[2, 0] == tempBoard[2, 2] && tempBoard[2, 0] != 0)
            { //de 3 vandret nederste er ens
                return tempBoard[2, 0];
            }
            if (tempBoard[0, 0] == tempBoard[1, 0] && tempBoard[0, 0] == tempBoard[2, 0] && tempBoard[0, 0] != 0)
            { //de 3 til lodret venstre er ens
                return tempBoard[0, 0];
            }
            if (tempBoard[0, 1] == tempBoard[1, 1] && tempBoard[0, 1] == tempBoard[1, 2] && tempBoard[0, 1] != 0)
            { //de 3 i lodret midten er ens
                return tempBoard[1, 0];
            }
            if (tempBoard[2, 0] == tempBoard[2, 1] && tempBoard[2, 0] == tempBoard[2, 2] && tempBoard[2, 0] != 0)
            { //de 3 til lodret højre er ens
                return tempBoard[2, 0];
            }
            if (tempBoard[0, 0] == tempBoard[1, 1] && tempBoard[0, 0] == tempBoard[2, 2] && tempBoard[0, 0] != 0)
            { //de 3 på tværs fra øverste ventre
                return tempBoard[0, 0];
            }
            if (tempBoard[0, 2] == tempBoard[1, 1] && tempBoard[0, 2] == tempBoard[2, 0] && tempBoard[0, 2] != 0)
            { //de 3 på tværs fra øverste højre
                return tempBoard[0, 2];
            }
            return 0;
        }
    }
}
