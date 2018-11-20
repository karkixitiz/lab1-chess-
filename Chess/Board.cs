using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess;

namespace Chess
{
    class Board
    {

        private

            Field[,] fields;
        static col pieceColor;
        static col sourcePieceColor, destinationPieceColor;
        static MovementResult m;
        static int pawnCounter = 0;
        public Board()
        {
            fields = new Field[8, 8];
            col current;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (((i + j) % 2) != 0) current = col.Black;
                    else
                        current = col.White;
                    fields[i, j] = new Field(current);
                }
            }
            for (int i = 0; i < 8; i++)
            {
                fields[1, i].myPice = new Pawn(col.Black);
                fields[0, 0].myPice = new Castle(col.Black);
                fields[0, 7].myPice = new Castle(col.Black);
                fields[0, 1].myPice = new Knight(col.Black);
                fields[0, 6].myPice = new Knight(col.Black);
                fields[0, 2].myPice = new Bishop(col.Black);
                fields[0, 5].myPice = new Bishop(col.Black);
                fields[0, 3].myPice = new Queen(col.Black);
                fields[0, 4].myPice = new King(col.Black);


                fields[6, i].myPice = new Pawn(col.White);
                fields[7, 0].myPice = new Castle(col.White);
                fields[7, 7].myPice = new Castle(col.White);
                fields[7, 1].myPice = new Knight(col.White);
                fields[7, 6].myPice = new Knight(col.White);
                fields[7, 2].myPice = new Bishop(col.White);
                fields[7, 5].myPice = new Bishop(col.White);
                fields[7, 3].myPice = new Queen(col.White);
                fields[7, 4].myPice = new King(col.White);
            }
        }
        public void drawChessBoard()
        {
            Console.Write("┌");
            for (int i = 0; i < 7; i++)
            {
                Console.Write("───" + "┬");
            }
            Console.Write("───" + "┐\n");
            for (int l = 0; l < 7; l++)
            {
                Console.Write("│");

                for (int j = 0; j < 8; j++)
                {
                    fields[l, j].drawField();
                    Console.Write("│");
                    // fillColor();
                }
                Console.Write("\n├");
                for (int k = 0; k < 7; k++)
                {
                    Console.Write("───" + "┼");
                }
                Console.Write("───┤\n");

            }
            Console.Write("│");
            for (int m = 0; m < 8; m++)
            {
                fields[7, m].drawField();
                Console.Write("│");
            }
            Console.Write("\n");
            Console.Write("└");
            for (int m = 0; m < 7; m++)
            {
                Console.Write("───" + "┴");
            }
            Console.Write("───┘");
        }

        public MovementResult move(int x1, int y1, int x2, int y2)
        {
            m = MovementResult.LegalMove;
            #region For Checking Collision of Bishop
            if (fields[x1, y1].myPice.GetType() == typeof(Bishop))
            {
                if (x2 > x1 && y1 < y2)
                {
                    int j = y1 + 1;
                    for (int i = x1 + 1; i <= x2; i++)
                    {
                        if (fields[i, j].myPice != null && sourcePieceColor == destinationPieceColor)
                        {
                            m = MovementResult.Collision;
                            break;

                        }
                        j++;
                    }
                }

                if (x2 < x1 && y1 > y2)
                {
                    int j = y1 - 1;
                    for (int i = x1 + 1; i <= x2; i++)
                    {
                        if (fields[i, j].myPice != null && sourcePieceColor == destinationPieceColor)
                        {
                            m = MovementResult.Collision;
                            break;

                        }
                        j--;
                    }
                }

                if (x1 > x2 && y1 > y2)
                {
                    int j = y1 - 1;
                    for (int i = x1 - 1; i >= x2; i--)
                    {
                        if (fields[i, j].myPice != null && sourcePieceColor == destinationPieceColor)
                        {
                            m = MovementResult.Collision;
                            break;

                        }
                        j--;
                    }
                }
                if (x1 > x2 && y1 < y2)
                {
                    int j = y1 + 1;
                    for (int i = x1 - 1; i >= x2; i--)
                    {
                        if (fields[i, j].myPice != null && sourcePieceColor == destinationPieceColor)
                        {
                            m = MovementResult.Collision;
                            break;

                        }
                        j++;
                    }
                }

            }
            #endregion
            #region For Checking Collision of Castle
            if (fields[x1, y1].myPice.GetType() == typeof(Castle))
            {
                if (x2 > x1 && y1 == y2)
                {
                    int j = y1;
                    for (int i = x1 + 1; i <= x2; i++)
                    {
                        if (fields[i, j].myPice != null && sourcePieceColor==destinationPieceColor)
                        {
                            m = MovementResult.Collision;
                            break;

                        }
                    }
                }
                if (y2 > y1 && x1 == x2)
                {
                    int j = y1 + 1;
                    for (int i = y1 + 1; i <= x2; i++)
                    {
                        if (fields[i, j].myPice != null && sourcePieceColor == destinationPieceColor)
                        {
                            m = MovementResult.Collision;
                            break;

                        }
                        j++;
                    }
                }
                if (x2 < x1 && y1 == y2)
                {
                    int j = y1;
                    for (int i = x1 + 1; i <= x2; i++)
                    {
                        if (fields[i, j].myPice != null && sourcePieceColor == destinationPieceColor)
                        {
                            m = MovementResult.Collision;
                            break;

                        }
                    }
                }
                if (y2 < y1 && x1 == x2)
                {
                    int j = y1 - 1;
                    for (int i = y1 - 1; i <= y2; i--)
                    {
                        if (fields[i, j].myPice != null && sourcePieceColor == destinationPieceColor)
                        {
                            m = MovementResult.Collision;
                            break;

                        }
                    }
                }
            }
            #endregion
            #region For Checking Collision of Queen
            if (fields[x1, y1].myPice.GetType() == typeof(Queen))
            {

                if (x2 > x1 && y1 < y2)
                {
                    int j = y1 + 1;
                    for (int i = x1 + 1; i < x2; i++)
                    {
                        if (fields[i, j].myPice != null && sourcePieceColor == destinationPieceColor)
                        {
                            m = MovementResult.Collision;
                            break;

                        }
                        j++;
                    }
                }

                if (x1 < x2 && y1 > y2)
                {
                    int j = y1 - 1;
                    for (int i = x1 + 1; i < x2; i++)
                    {
                        if (fields[i, j].myPice != null && sourcePieceColor == destinationPieceColor)
                        {
                            m = MovementResult.Collision;
                            break;

                        }
                        j--;
                    }
                }

                if (x1 > x2 && y1 > y2)
                {
                    int j = y1 - 1;
                    for (int i = x1 - 1; i > x2; i--)
                    {
                        if (fields[i, j].myPice != null && sourcePieceColor == destinationPieceColor)
                        {
                            m = MovementResult.Collision;
                            break;

                        }
                        j--;
                    }
                }
                if (x1 > x2 && y1 < y2)
                {
                    int j = y1 + 1;
                    for (int i = x1 - 1; i > x2; i--)
                    {
                        if (fields[i, j].myPice != null && sourcePieceColor == destinationPieceColor)
                        {
                            m = MovementResult.Collision;
                            break;

                        }
                        j++;
                    }
                }
                if (x2 > x1 && y1 == y2)
                {
                    int j = y1;
                    for (int i = x1 + 1; i < x2; i++)
                    {
                        if (fields[i, j].myPice != null)
                        {
                            m = MovementResult.Collision;
                            break;

                        }
                    }
                }
                if (y2 > y1 && x1 == x2)
                {
                    int j = y1 + 1;
                    for (int i = y1 + 1; i < x2; i++)
                    {
                        if (fields[i, j].myPice != null && sourcePieceColor == destinationPieceColor)
                        {
                            m = MovementResult.Collision;
                            break;

                        }
                        j++;
                    }
                }
                if (x2 < x1 && y1 == y2)
                {
                    int j = y1;
                    for (int i = x1 - 1; i < x2; i--)
                    {
                        if (fields[i, j].myPice != null && sourcePieceColor == destinationPieceColor)
                        {
                            m = MovementResult.Collision;
                            break;

                        }
                    }
                }
                if (y2 < y1 && x1 == x2)
                {
                    int j = y1 - 1;
                    for (int i = y1 - 1; i < y2; i--)
                    {
                        if (fields[i, j].myPice != null && sourcePieceColor == destinationPieceColor)
                        {
                            m = MovementResult.Collision;
                            break;

                        }
                    }
                }
            }
            #endregion
            if (m != MovementResult.Collision)
            {
                if (fields[x1, y1].myPice == null)
                {
                    m = MovementResult.NoPieceOnSource;
                }
                if (fields[x1, y1].myPice.movementLegal(x1 - x2, y1 - y2))
                {
                    if (sourcePieceColor == destinationPieceColor)
                    {
                        m = MovementResult.TargetOccupiedByOwnPiece;
                    }
                    else
                    {
                        if((fields[x1, y1].myPice== fields[1, y2].myPice && fields[x1, y1].myPice == fields[6, y2].myPice))
                        {
                            m = MovementResult.LegalMove;
                            return m;
                        }
                       
                        if ((Math.Abs(y1 - y2) != 0) && fields[x2, y2].myPice == null && fields[x1, y1].myPice.GetType() == typeof(Pawn))
                        {
                            m = MovementResult.IllegalMovement;
                            return m;
                        }
                        if (fields[x2, y2].myPice != null && fields[x1, y1].myPice.GetType() == typeof(Pawn) && Math.Abs(y2 - y1) == 0)
                        {
                            m = MovementResult.IllegalMovement;
                            return m;
                        }
                        if (fields[x2, y2].myPice != null)
                        {
                            fields[x2, y2].myPice = fields[x1, y1].myPice;
                            fields[x1, y1].myPice = null;
                            m = MovementResult.Hit;
                            return m;
                        }
                        fields[x2, y2].myPice = fields[x1, y1].myPice;
                        fields[x1, y1].myPice = null;
                        m = MovementResult.LegalMove;
                    }

                }
                else
                {
                    m = MovementResult.IllegalMovement;
                }
            }
            return m;

        }

        //Call from main method
        public static void TestMovement(Board myBoard, int x1, int y1, int x2, int y2)
        {
            Console.Clear();
            if (myBoard.fields[x1, y1] != null && (myBoard.fields[x2, y2]) != null)
            {
                //Get source piece color
                sourcePieceColor = GetPieceColor(myBoard, x1, y1);
                if (myBoard.fields[x2, y2].myPice != null)
                {
                    //Get destination color
                    destinationPieceColor = GetPieceColor(myBoard, x2, y2);
                }
                //Call move method
                MovementResult myres = myBoard.move(x1, y1, x2, y2);
                if (myres == MovementResult.LegalMove)
                {
                    myBoard.drawChessBoard();
                    Console.Write("\n" + myres);
                    Console.WriteLine("\nTry another move......! Click Enter !!!");
                    System.Threading.Thread.Sleep(1000);
                }
                else
                {
                    myBoard.drawChessBoard();
                    Console.Write("\n" + myres);
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("\nTry another move......! Click Enter !!!");
                }
            }
        }
        //Function return color of piece
        public static col GetPieceColor(Board myBoard, int x1, int y1)
        {
            if (myBoard.fields[x1, y1].myPice.getColor() == col.Black)
            {
                pieceColor = col.Red;
            }
            else
            {
                pieceColor = col.White;
            }
            return pieceColor;
        }


    }
}
