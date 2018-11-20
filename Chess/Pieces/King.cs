using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class King:Piece
    {
        public King(col color)
        {
            this.color = color;
            letterDisplay = 'K';
        }
        public override bool movementLegal(int dx, int dy)
        {
            if ((Math.Abs(dx) <= 1) && (Math.Abs(dy) <= 1))
            {
                hasBeenMoved = true;
                return true;
            }
            return false;
        }
       

        
    }
}
