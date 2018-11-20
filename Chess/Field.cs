using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Field 
    {
        public col color;
        public Piece myPice;
        public Field(col color)
        {
            this.color = color;
        }

        public void drawField()
        {
            if (color == col.Black)
            {
             Console.Write(" ");
            drawChessLetter();
            Console.Write(" ");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Write(" ");
               drawChessLetter();
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Black;

            }
        }
        private void drawChessLetter()
        {
            if (myPice == null)
            { Console.Write(" "); }
            else
            {
                if (myPice.getColor() == col.White) { 
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else
                { 
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(myPice.getLetter());
                Console.ForegroundColor = ConsoleColor.White;

            }

        }




    }
}
