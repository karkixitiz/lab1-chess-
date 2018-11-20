using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
   
        public enum col
        {
            Black,
            White,
            Red
        }
    public enum MovementResult
        {
            Hit, LegalMove, NoPieceOnSource, TargetOccupiedByOwnPiece,
            TargetOutsideBoard, Collision, IllegalMovement
        }
    
}
