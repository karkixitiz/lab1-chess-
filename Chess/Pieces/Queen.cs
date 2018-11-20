using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Queen:Piece
    {
        public Queen(col color)
        {
            this.color = color;
            letterDisplay = 'Q';
        }

       
        public override bool movementLegal(int dx, int dy)
        {
            if ((Math.Abs(dx) <= 8) && (Math.Abs(dy) <= 8))
            {
                if((dx == 0) || (dy == 0))
                {
                    return true;
                }
                else
                {
                    if ((dx-dy) %2 !=0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                
                //if((Math.Abs(dx)>=1) || Math.Abs(dy) >= 1)
                //{
                //    if (Math.Abs(dx) != 0 || Math.Abs(dy) != 0)
                //    {
                //        return false;
                //    }
                //}
                hasBeenMoved = true;
                //return true;
            }
            return false;
        }
    }
}
