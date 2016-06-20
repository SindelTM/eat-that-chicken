using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatThatChicken.GameObjects.Birds
{
    public class NaughtyTurkey: SkinyTurkey
    {
        private const int NaughtyBirdDefaultHealth = 4;

        public NaughtyTurkey()
            :base(NaughtyBirdDefaultHealth)
        {
        }
    }
}
