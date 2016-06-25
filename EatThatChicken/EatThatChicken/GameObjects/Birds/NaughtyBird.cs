using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace EatThatChicken.GameObjects.Birds
{
    public class NaughtyBird: Bird
    {
        private const int NaughtyBirdDefaultHealth = 4;

        public NaughtyBird()
            :base(NaughtyBirdDefaultHealth)
        {
            this.MoveSpeed = 2;
            this.MoveTop = 0;
            this.MoveLeft = 1;
        }
    }
}
