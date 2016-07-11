namespace EatThatChicken.Common.Structs
{
    public struct GameObjectBounds
    {
        public GameObjectBounds(Position topLeft, Position bottomRight)
            : this(topLeft.Left, topLeft.Top, bottomRight.Left, bottomRight.Top)
        {
        }

        public GameObjectBounds(int left, int top, int right, int bottom)
            : this()
        {
            this.Left = left;
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
        }

        public int Left { get; set; }

        public int Right { get; set; }

        public int Top { get; set; }

        public int Bottom { get; set; }
    }
}




