namespace EatThatChicken.GameObjects.Bullets
{
    using Enumerations;
    public class Bullet : GameObject
    {
        private const int defaultSpeed = 40;
        private const MoveType defaultTop = MoveType.Incremental;
        private const MoveType defaultLeft = MoveType.None;

        public Bullet(Size bounds, Position position)
            : base(bounds, position, new MoveAction(defaultLeft, defaultTop, defaultSpeed)) { }

    }
}