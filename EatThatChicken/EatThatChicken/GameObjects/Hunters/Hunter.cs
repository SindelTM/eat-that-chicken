using System.Windows.Controls;

namespace EatThatChicken.GameObjects.Hunters
{
    using Contracts;
    using Enumerations;

    public class Hunter : GameObject, IHunter
    {
        public Hunter(Size bounds, Position position)
            : base(bounds, position, new MoveAction(15)) { }

        public override void OutOfScreenUpdate(int screenHeight, int screenWidth)
        {
            int rightSide = this.Position.Left + this.Bounds.Width;
            int leftSide = this.Position.Left;

            if ((rightSide >= screenWidth) || (leftSide <= 0))
            {
                this.moveAction.Left = MoveType.None;
            }
        }
        public void MoveLeft()
        {
            this.moveAction.Left = MoveType.Incremental;

            //this.Position = new Position(left, this.Position.Top);
        }

        public void MoveRight()
        {
            this.moveAction.Left = MoveType.Decremental;

            //this.Position = new Position(left, this.Position.Top);
        }

        public void StopMove()
        {
            this.moveAction.Left = MoveType.None;
        }

        public override void Draw(Canvas playgroundCanvas)
        {
            var image = this.CreateImage("/Images/Hunter.png", this.Position, this.Bounds);
            playgroundCanvas.Children.Add(image);
        }
    }
}
