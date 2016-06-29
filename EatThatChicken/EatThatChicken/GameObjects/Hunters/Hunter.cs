using System.Windows.Controls;

namespace EatThatChicken.GameObjects.Hunters
{
    using Contracts;
    using Enumerations;

    public class Hunter : GameObject, IHunter
    {
        public Hunter(Size bounds, Position position)
            : base(bounds, position, new MoveAction(15)) { }

        public void MoveLeft()
        {
            int left = this.Position.Left - ((int)MoveType.Incremental * this.moveAction.Speed);

            this.Position = new Position(left, this.Position.Top);
        }

        public void MoveRight()
        {
            int left = this.Position.Left - ((int)MoveType.Decremental * this.moveAction.Speed);

            this.Position = new Position(left, this.Position.Top);
        }

        public override void Draw(Canvas playgroundCanvas)
        {
            var image = this.CreateImage("/Images/Hunter.png", this.Position, this.Bounds);
            playgroundCanvas.Children.Add(image);
        }
    }
}
