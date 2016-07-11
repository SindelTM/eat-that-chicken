namespace EatThatChicken.Common.Structs
{
    public struct Position
    {
        public Position(int left, int top) : this()
        {
            this.Left = left;
            this.Top = top;
        }

        public int Left { get; set; }

        public int Top { get; set; }
    }
}
