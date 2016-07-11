namespace EatThatChicken.GameObjects.Bullets
{
    using Common;
    using Common.Enumerations;
    using Common.Structs;
    using Contracts;
    using Size = Common.Structs.Size;

    public class Bullet : GameObject, IBullet
    {
        private const int defaultSpeed = 40;
        private const MoveType defaultTop = MoveType.Incremental;
        private const MoveType defaultLeft = MoveType.None;

        public Bullet(Size bounds, Position position)
            : base(bounds, position, new MoveAction(defaultLeft, defaultTop, defaultSpeed)) { }
    }
}