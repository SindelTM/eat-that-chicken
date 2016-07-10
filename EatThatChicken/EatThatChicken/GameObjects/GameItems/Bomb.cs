using System.Windows.Controls;
using EatThatChicken.Common;
using EatThatChicken.Contracts;
using EatThatChicken.Enumerations;

namespace EatThatChicken.GameObjects.GameItems
{
    [Item]
    public class Bomb : Item
    {
        public Bomb(int speed, Size bounds, Position position)
            : base(bounds, position, speed)
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
