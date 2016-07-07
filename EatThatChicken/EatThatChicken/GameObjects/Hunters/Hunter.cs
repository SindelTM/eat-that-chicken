using System.Windows.Controls;

namespace EatThatChicken.GameObjects.Hunters
{
    using Contracts;
    using Enumerations;

    public class Hunter : GameObject, IHunter
    {
        public Hunter(Size bounds, Position position, int speed)
            : base(bounds, position, new MoveAction(speed)) { }

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

        public override void Draw(Canvas playgroundCanvas)
        {
            var image = this.CreateImage("/Images/Hunter.png", this.Position, this.Bounds);
            playgroundCanvas.Children.Add(image);
        }
    }
}
