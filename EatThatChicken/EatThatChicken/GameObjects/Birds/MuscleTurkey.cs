using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatThatChicken.GameObjects.Birds
{
    public class MuscleTurkey: Bird
    {
        public MuscleTurkey(Size bounds, Position position, bool isAlive, int points)
            :base(bounds, position, isAlive, points)
        {
        }
    }
}
