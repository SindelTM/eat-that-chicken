using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatThatChicken.GameObjects.Birds
{
    public class AngryTurkey: SkinyTurkey
    {
        private const int AngryBirdDefaultHealth = 3; 

        public AngryTurkey()
            :base(AngryBirdDefaultHealth)
        {
        }



    }
}
