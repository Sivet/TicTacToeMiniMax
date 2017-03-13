using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeMiniMax
{
    class Program
    {
        Board board = new Board();

        int player1Wins = 0;
        int player2Wins = 0;
        int drawWin = 0;

        
        static void Main(string[] args)
        {
            Program myPrgram = new Program();
            myPrgram.Run();
        }
        public void Run()
        {
            RandomPlayer player1 = new RandomPlayer(board, 1);
            FIFOPlayer player2 = new FIFOPlayer(board, 2);

            for (int i = 0; i < 10; i++)
            {
                int turnCounter = 0;
                while (board.checkForWin() == -1)
                {
                    player1.Play();
                    if (board.checkForWin() != -1)
                    {
                        break;
                    }
                    player2.Play();
                    turnCounter++;
                    if (turnCounter == 9)
                    {
                        break;
                    }
                }

                if (board.checkForWin() == 1)
                {
                    player1Wins++;
                }
                if (board.checkForWin() == 2)
                {
                    player2Wins++;
                }
                if (board.checkForWin() == -1)
                {
                    drawWin++;
                }
                
                board.ClearBoard();
            }

            Console.WriteLine("Player 1 won: " + player1Wins);
            Console.WriteLine("Player 2 won: " + player2Wins);
            Console.WriteLine("Number of draws: " + drawWin);
            Console.ReadKey();
             
        }
    }
}
