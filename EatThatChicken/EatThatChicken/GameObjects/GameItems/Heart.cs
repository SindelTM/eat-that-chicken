namespace EatThatChicken.GameObjects.GameItems
{
    using EatThatChicken.Common;
    using EatThatChicken.Common.Structs;
    using EatThatChicken.Contracts;

    [Item]
    class Heart : Item
    {
        public Heart(int speed, Size bounds, Position position)
            : base(bounds, position, speed, 0)
        {
        }

        public override void AffectHunter(IHunter hunter)
        {
            hunter.NumberOfLifes++;
        }
    }
}
