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
        static void Main(string[] args)
        {
            Program myPrgram = new Program();
            myPrgram.Run();
        }
        public void Run()
        {
            FIFOPlayer player1 = new FIFOPlayer(board, 1);
            FIFOPlayer player2 = new FIFOPlayer(board, 2);

            while (board.checkForWin() == false)
            {
                player1.Play();
                if (board.checkForWin() == true)
                {
                    break;
                }
                player2.Play();
            }
            Console.WriteLine("Result: ");
            Console.WriteLine(board.getBoard().ToString());
            Console.ReadKey();
             
        }
    }
}
