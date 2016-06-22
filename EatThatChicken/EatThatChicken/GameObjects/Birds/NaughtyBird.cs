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
            this.MoveSpeed = 50;
            this.MoveTop = -1;
            this.MoveLeft = 0;
        }
    }
}
