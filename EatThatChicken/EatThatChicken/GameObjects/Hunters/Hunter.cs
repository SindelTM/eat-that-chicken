namespace EatThatChicken.GameObjects.Hunters
{
    using Common;
    using Contracts;
    using Common.Enumerations;
    using Common.Structs;

    public class Hunter : GameObject, IHunter
    {
        public const uint InitialNumberOfLifes = 3;

        public Hunter(Size bounds, Position position, int speed)
            : base(bounds, position, new MoveAction(speed))
        {
            this.NumberOfLifes = InitialNumberOfLifes;
        }

        public int Points { get; set; }

        public uint NumberOfLifes { get; set; }

        public void MoveLeft()
        {
            int left = this.Position.Left - ((int)MoveType.Incremental * this.MoveAction.Speed);

            this.Position = new Position(left, this.Position.Top);
        }

        public void MoveRight()
        {
            int left = this.Position.Left - ((int)MoveType.Decremental * this.MoveAction.Speed);

            this.Position = new Position(left, this.Position.Top);
        }
    }
}
