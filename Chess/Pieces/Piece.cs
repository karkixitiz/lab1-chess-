using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Chess
{
    abstract class Piece
    {
        
        public abstract  bool movementLegal(int dx, int dy);
        public char getLetter()
        {
            return letterDisplay;
        }
        public col getColor()
        {
            return color;
        }
        protected char letterDisplay;
        protected col color;
        protected bool hasBeenMoved = false;

        
    }
}
