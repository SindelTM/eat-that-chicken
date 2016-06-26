using EatThatChicken.Enumerations;

namespace EatThatChicken.GameObjects.GameItems
{
    class Heart : GameObject
    {
        private const int defaultSpeed = 6;
        private const MoveType defaultTop = MoveType.Decremental;
        private const MoveType defaultLeft = MoveType.None;

        private static MoveAction moveaction = new MoveAction(defaultLeft, defaultTop, defaultSpeed);

        public Heart(Size bounds, Position position, bool isAlive)
            :base(bounds, position, moveaction)
        {

        }
    }
}
