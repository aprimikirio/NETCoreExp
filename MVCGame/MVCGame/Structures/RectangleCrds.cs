using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCGame.Structures
{
    struct RectangleCrds
    {
        public CoOrds LB, RB, RT, LT;

        public RectangleCrds(
            CoOrds LeftBottomCoords, 
            CoOrds LeftTopCoords, 
            CoOrds RightTopCoords, 
            CoOrds RightBottomCoords)
        {
            LB = LeftBottomCoords;
            RB = RightBottomCoords;
            RT = RightTopCoords;
            LT = LeftTopCoords;
        }
    }
}
