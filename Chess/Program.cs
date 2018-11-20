
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Program
    {
         static col pieceColor;
        static void Main(string[] args)
        {
            Board b = new Board();
            col turn = col.White;
            b.drawChessBoard();
            while (true)
            {
                Console.WriteLine("\nGive movement instruction\n");
                int x1 = Convert.ToInt32(Console.ReadLine());
                int x2 = Convert.ToInt32(Console.ReadLine());
                int y1 = Convert.ToInt32(Console.ReadLine());
                int y2 = Convert.ToInt32(Console.ReadLine());
                pieceColor=Board.GetPieceColor(b, x1, x2);
              
                if (turn == col.White)
                {
                    if(turn==pieceColor)
                    {
                        Board.TestMovement(b, x1, x2, y1, y2);
                        turn = col.Red;
                    }
                    else
                    {
                        Console.WriteLine("\n It's white turn......Please Enter!!");
                    }
                }
                else
                { 
                    if (turn == pieceColor)
                    {
                        Board.TestMovement(b, x1, x2, y1, y2);
                        turn = col.White;
                    }
                    else
                    {
                        Console.WriteLine("\n It's Black turn....Please Enter!!");
                    }
                }
                Console.ReadKey();
            }

        }

    }
}
