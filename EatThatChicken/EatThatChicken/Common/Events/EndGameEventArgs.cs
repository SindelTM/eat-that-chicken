namespace EatThatChicken.Common.Events
{
    using System;

    public class EndGameEventArgs : EventArgs
    {
        public EndGameEventArgs(int points)
        {
            this.Points = points;
        }

        public int Points { get; }
    }
}
