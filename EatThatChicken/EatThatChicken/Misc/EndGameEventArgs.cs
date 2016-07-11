namespace EatThatChicken.Misc
{
    using System;

    class EndGameEventArgs : EventArgs
    {
        public EndGameEventArgs(int points)
        {
            this.Points = points;
        }

        public int Points { get; }
    }
}
