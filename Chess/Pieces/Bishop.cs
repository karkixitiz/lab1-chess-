using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Bishop:Piece
    {
        public Bishop(col color)
        {
            this.color = color;
            letterDisplay = 'B';
        }
       
        
        public override bool movementLegal(int dx, int dy)
        {
            return (dx!=0) && (dy!=0);
        }
    }
}
