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

        //variable der holde bedste move
        int bestMoveX;
        int bestMoveY;
        //variable der holder den bedste score
        int bestScore;
        int tempScore;

        public MiniMaxPlayer(Board board, int player)
        {
            this.board = board;
            this.player = player;
        }

        public void Play()
        {
            int bestMoveX = -1;
            int bestMoveY = -1;
            int bestScore = -999;
            int tempScpre = -999;
            tempBoard = board.getTempBoard();

            MiniMax(board);
        }
        private void MiniMax(Board board)
        {
            for (int x = 0; x < 3; x++) //find alle mulige træk
            {
                for (int y = 0; y < 3; y++)
                {
                    if (tempBoard[x, y] == 0)
                    {
                        tempBoard[x, y] = player;
                        tempScore = Min();
                        if (tempScore < bestScore)
                        {
                            //tjek alle træk på min og sæt best score
                            bestScore = tempScore;
                            bestMoveX = x;
                            bestMoveY = y;
                        }
                        tempBoard[x, y] = 0;
                    }
                }
            }
            //lav det bedste træk på boarded
            board.placeBrick(player, bestMoveX, bestMoveY);

        }
        private int Min()
        {
            if (DidIWin() == true || DidILoose() == true)
            {
                return EVAL();
            }
            else
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        if (tempBoard[x, y] == 0)
                        {
                            tempBoard[x, y] = 1; //det skal da være den her som rykker modstanderen, ellers rykker jeg to gange jo...
                            tempScore = Max();
                            if (tempScore < bestScore)
                            {
                                bestScore = tempScore;
                            }
                            tempBoard[x, y] = 0;
                        }
                    }
                }
                return bestScore;
            }
        }
        private int Max()
        {
            if (DidIWin() == true || DidILoose() == true)
            {
                return EVAL();
            }
            else
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        if (tempBoard[x, y] == 0)
                        {
                            tempBoard[x, y] = player;
                            tempScore = Min();
                            if (tempScore > bestScore)
                            {
                                bestScore = tempScore;
                            }
                            tempBoard[x, y] = 0;
                        }
                    }
                }
                return bestScore;
            }
        }
        private int EVAL()
        {
            if (DidIWin() == true)
            {
                return -1;
            }
            if (DidILoose() == true)
            {
                return 1;
            }
            return 0;

        }
        private bool DidIWin() //holder ikke styr på turene, så bliver den kaldt i en situation hvos boarded ikke er fyldt og ingen vinder, så fejler den
        {
            if (tempBoard[0, 0] == player && tempBoard[0, 1] == player && tempBoard[0, 2] == player)
            { //de 3 vandret øverste er ens
                return true;
            }
            if (tempBoard[1, 0] == player && tempBoard[1, 1] == player && tempBoard[1, 2] == player)
            { //de 3  vandret midten er ens
                return true;
            }
            if (tempBoard[2, 0] == player && tempBoard[2, 1] == player && tempBoard[2, 2] == player)
            { //de 3 vandret nederste er ens
                return true;
            }
            if (tempBoard[0, 0] == player && tempBoard[1, 0] == player && tempBoard[2, 0] == player)
            { //de 3 til lodret venstre er ens
                return true;
            }
            if (tempBoard[0, 1] == player && tempBoard[1, 1] == player && tempBoard[1, 2] == player)
            { //de 3 i lodret midten er ens
                return true;
            }
            if (tempBoard[2, 0] == player && tempBoard[2, 1] == player && tempBoard[2, 2] == player)
            { //de 3 til lodret højre er ens
                return true;
            }
            if (tempBoard[0, 0] == player && tempBoard[1, 1] == player && tempBoard[2, 2] == player)
            { //de 3 på tværs fra øverste ventre
                return true;
            }
            if (tempBoard[0, 2] == player && tempBoard[1, 1] == player && tempBoard[2, 0] == player)
            { //de 3 på tværs fra øverste højre
                return true;
            }
            return false;
        }
        private bool DidILoose()
        {
            if (tempBoard[0, 0] != player && tempBoard[0, 1] != player && tempBoard[0, 2] != player 
                && tempBoard[0, 0] != 0 && tempBoard[0, 1] != 0 && tempBoard[0, 2] != 0)
            { //de 3 vandret øverste er ens
                return true;
            }
            if (tempBoard[1, 0] != player && tempBoard[1, 1] != player && tempBoard[1, 2] != player 
                && tempBoard[1, 0] != 0 && tempBoard[1, 1] != 0 && tempBoard[1, 2] != 0)
            { //de 3  vandret midten er ens
                return true;
            }
            if (tempBoard[2, 0] != player && tempBoard[2, 1] != player && tempBoard[2, 2] != player 
                && tempBoard[2, 0] != 0 && tempBoard[2, 1] != 0 && tempBoard[2, 2] != 0)
            { //de 3 vandret nederste er ens
                return true;
            }
            if (tempBoard[0, 0] != player && tempBoard[1, 0] != player && tempBoard[2, 0] != player 
                && tempBoard[0, 0] != 0 && tempBoard[1, 0] != 0 && tempBoard[2, 0] != 0)
            { //de 3 til lodret venstre er ens
                return true;
            }
            if (tempBoard[0, 1] != player && tempBoard[1, 1] != player && tempBoard[1, 2] != player 
                && tempBoard[0, 1] != 0 && tempBoard[1, 1] != 0 && tempBoard[1, 2] != 0)
            { //de 3 i lodret midten er ens
                return true;
            }
            if (tempBoard[2, 0] != player && tempBoard[2, 1] != player && tempBoard[2, 2] != player 
                && tempBoard[2, 0] != 0 && tempBoard[2, 1] != 0 && tempBoard[2, 2] != 0)
            { //de 3 til lodret højre er ens
                return true;
            }
            if (tempBoard[0, 0] != player && tempBoard[1, 1] != player && tempBoard[2, 2] != player 
                && tempBoard[0, 0] != 0 && tempBoard[1, 1] != 0 && tempBoard[2, 2] != 0)
            { //de 3 på tværs fra øverste ventre
                return true;
            }
            if (tempBoard[0, 2] != player && tempBoard[1, 1] != player && tempBoard[2, 0] != player 
                && tempBoard[0, 2] != 0 && tempBoard[1, 1] != 0 && tempBoard[2, 0] != 0)
            { //de 3 på tværs fra øverste højre
                return true;
            }
            return false;
        }
    }
}
