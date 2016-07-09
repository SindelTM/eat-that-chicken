using EatThatChicken.Contracts;
using EatThatChicken.GameObjects;
using EatThatChicken.GameObjects.Hunters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EatThatChicken.Common;

namespace EatThatChicken.Factories
{
    class HunterFactory : IGameObjectFactory<Hunter>
    {
        private const int HunterBoundsHeight = 190;
        private const int HunterBoundsWidth = 90;
                          
        private const int HunterSpeed = 10;

        public Hunter Get(int left, int top)
        {
            Position position = new Position(left, top);
            Size bounds = new Size(HunterBoundsWidth, HunterBoundsHeight);

            return new Hunter(bounds, position, HunterSpeed);
        }
    }
}
