using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Castle:Piece
    {
        public Castle(col color)
        {
            this.color = color;
            letterDisplay = 'C';
        }
        public override bool movementLegal(int dx, int dy)
        {
            return (dx == 0) || (dy == 0);
        }
    }
}
