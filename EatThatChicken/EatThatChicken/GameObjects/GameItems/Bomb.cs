using System.Windows.Controls;
using EatThatChicken.Common;
using EatThatChicken.Common.Structs;
using EatThatChicken.Contracts;

namespace EatThatChicken.GameObjects.GameItems
{
    [Item]
    public class Bomb : Item
    {
        public Bomb(int speed, Size bounds, Position position)
            : base(bounds, position, speed, 0)
        {
        }

        public override void AffectHunter(IHunter hunter)
        {
            if (hunter.NumberOfLifes >= 1 && hunter.NumberOfLifes <= 3)
            {
                hunter.NumberOfLifes--;
            }
        }
    }
}
