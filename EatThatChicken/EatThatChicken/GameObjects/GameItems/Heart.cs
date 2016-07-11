using System.Windows.Controls;
using EatThatChicken.Common;
using EatThatChicken.Contracts;
using EatThatChicken.Enumerations;

namespace EatThatChicken.GameObjects.GameItems
{
    [Item]
    class Heart : Item
    {
        public Heart(int speed, Size bounds, Position position)
            : base(bounds, position, speed)
        {
        }

        public override void AffectHunter(IHunter hunter)
        {
            hunter.NumberOfLifes++;
        }
    }
}
