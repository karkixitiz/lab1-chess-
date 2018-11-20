using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    class Knight : Piece
    {
        public Knight(col color)
        {
            this.color = color;
            letterDisplay = 'k';
        }
    

        public override bool movementLegal(int dx, int dy)
        {
            if ((Math.Abs(dx) <= 3) && (Math.Abs(dy) <= 3))
            {
                if ((dx == 0) || (dy == 0))
                {
                    return false;
                }
                else
                {
                    if ((dx - dy) % 2 != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                
                
                hasBeenMoved = true;
                //return true;
            }
            return false;
        }
    }
}
