using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatThatChicken.GameObjects.Birds
{
    public class SkinyBird: Bird
    {
        private const int SkinnyBirdHealth = 1;

        public SkinyBird()
            :base(SkinnyBirdHealth)
        {
        }
    }
}
