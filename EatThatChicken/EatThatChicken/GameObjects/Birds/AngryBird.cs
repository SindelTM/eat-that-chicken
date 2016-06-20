using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatThatChicken.GameObjects.Birds
{
    public class AngryBird: SkinyBird
    {
        private const int AngryBirdDefaultHealth = 3; 

        public AngryBird()
            :base(AngryBirdDefaultHealth)
        {
        }



    }
}
