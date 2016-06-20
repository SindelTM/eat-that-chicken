using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatThatChicken.GameObjects.Birds
{
    public class MuscleTurkey: SkinyTurkey
    {
        private const int MuscleBirdDefaultHealth = 5;

        public MuscleTurkey()
            :base(MuscleBirdDefaultHealth)
        {
        }
    }
}
