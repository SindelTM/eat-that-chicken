using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatThatChicken.GameObjects.Birds
{
    public class NaughtyBird: Bird
    {
        private const int NaughtyBirdDefaultHealth = 4;

        public NaughtyBird()
            :base(NaughtyBirdDefaultHealth)
        {
        }
    }
}
