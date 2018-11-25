using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCGame.Structures;

namespace MVCGame.Models.GameModels
{
    class GameObject
    {
        public double height;
        public double width;
        public string name;
        public RectangleCrds Crds;

        public GameObject(double height, double width, CoOrds сoordinatеs, string name)
        {
            this.height = height;
            this.width = width;
            this.name = name;

            Crds.LB.x = сoordinatеs.x;
            Crds.LB.y = сoordinatеs.y;

            Crds.RB.x = Crds.LB.x + width;
            Crds.RB.y = Crds.LB.y;

            Crds.RT.x = Crds.LB.x + width;
            Crds.RT.y = Crds.LB.y + height;

            Crds.LT.x = Crds.LB.x;
            Crds.LT.y = Crds.LB.y + height;
        }
    }
}
