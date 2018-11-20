using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Pawn : Piece
    {
        public Pawn(col color)
        {
            this.color = color;
            letterDisplay = 'P';
        }


        public override bool movementLegal(int dx, int dy)
        {
            if ((Math.Abs(dx) <= 2) && (Math.Abs(dy) <= 1))
                {
                 
                    return true;
                }
            return false;
        }
    }
}
