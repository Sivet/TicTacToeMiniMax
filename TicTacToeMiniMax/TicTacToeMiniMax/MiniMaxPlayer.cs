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
        int playerMe;
        int playerOther;

        int[,] tempBoard;

        //variable der holde bedste move
        int bestMoveX;
        int bestMoveY;
        //variable der holder den bedste score
        int bestScore;
        

        public MiniMaxPlayer(Board board, int player)
        {
            this.board = board;
            this.playerMe = player;
            if (playerMe == 1)
            {
                playerOther = 2;
            }
            else
            {
                playerOther = 1;
            }
        }

        public void Play()
        {
            bestMoveX = -1;
            bestMoveY = -1;
            bestScore = 999;
            //tempScore = -999;
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
                        tempBoard[x, y] = playerMe;
                        int tempScore = Min();
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
            board.placeBrick(playerMe, bestMoveX, bestMoveY);

        }
        private int Min()
        {
            if (DidIWin(playerMe) == true)
            {
                return -999;
            }
            else
            {
                int bestScore = -999;
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        if (tempBoard[x, y] == 0)
                        {
                            tempBoard[x, y] = 1; //det skal da være den her som rykker modstanderen, ellers rykker jeg to gange jo...
                            int tempScore = Max();
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
            if (DidIWin(playerOther) == true)
            {
                return 999;
            }
            else
            {
                int bestScore = 999;
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        if (tempBoard[x, y] == 0)
                        {
                            tempBoard[x, y] = playerMe;
                            int tempScore = Min();
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
        //private int EVAL() //ikke brugt lige nu
        //{
        //    if (DidIWin() == true)
        //    {
        //        return -1;
        //    }
        //    if (DidILoose() == true)
        //    {
        //        return 1;
        //    }
        //    return 0;

        //}
        private bool DidIWin(int player) //holder ikke styr på turene, så bliver den kaldt i en situation hvos boarded ikke er fyldt og ingen vinder, så fejler den
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
            if (tempBoard[0, 2] == player && tempBoard[1, 2] == player && tempBoard[2, 2] == player)
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
        //private bool DidILoose() //unødvendig
        //{
        //    if (tempBoard[0, 0] != player && tempBoard[0, 1] != player && tempBoard[0, 2] != player 
        //        && tempBoard[0, 0] != 0 && tempBoard[0, 1] != 0 && tempBoard[0, 2] != 0)
        //    { //de 3 vandret øverste er ens
        //        return true;
        //    }
        //    if (tempBoard[1, 0] != player && tempBoard[1, 1] != player && tempBoard[1, 2] != player 
        //        && tempBoard[1, 0] != 0 && tempBoard[1, 1] != 0 && tempBoard[1, 2] != 0)
        //    { //de 3  vandret midten er ens
        //        return true;
        //    }
        //    if (tempBoard[2, 0] != player && tempBoard[2, 1] != player && tempBoard[2, 2] != player 
        //        && tempBoard[2, 0] != 0 && tempBoard[2, 1] != 0 && tempBoard[2, 2] != 0)
        //    { //de 3 vandret nederste er ens
        //        return true;
        //    }
        //    if (tempBoard[0, 0] != player && tempBoard[1, 0] != player && tempBoard[2, 0] != player 
        //        && tempBoard[0, 0] != 0 && tempBoard[1, 0] != 0 && tempBoard[2, 0] != 0)
        //    { //de 3 til lodret venstre er ens
        //        return true;
        //    }
        //    if (tempBoard[0, 1] != player && tempBoard[1, 1] != player && tempBoard[1, 2] != player 
        //        && tempBoard[0, 1] != 0 && tempBoard[1, 1] != 0 && tempBoard[1, 2] != 0)
        //    { //de 3 i lodret midten er ens
        //        return true;
        //    }
        //    if (tempBoard[0, 2] != player && tempBoard[1, 2] != player && tempBoard[2, 2] != player 
        //        && tempBoard[0, 2] != 0 && tempBoard[1, 2] != 0 && tempBoard[2, 2] != 0)
        //    { //de 3 til lodret højre er ens
        //        return true;
        //    }
        //    if (tempBoard[0, 0] != player && tempBoard[1, 1] != player && tempBoard[2, 2] != player 
        //        && tempBoard[0, 0] != 0 && tempBoard[1, 1] != 0 && tempBoard[2, 2] != 0)
        //    { //de 3 på tværs fra øverste ventre
        //        return true;
        //    }
        //    if (tempBoard[0, 2] != player && tempBoard[1, 1] != player && tempBoard[2, 0] != player 
        //        && tempBoard[0, 2] != 0 && tempBoard[1, 1] != 0 && tempBoard[2, 0] != 0)
        //    { //de 3 på tværs fra øverste højre
        //        return true;
        //    }
        //    return false;
        //}
    }
}
