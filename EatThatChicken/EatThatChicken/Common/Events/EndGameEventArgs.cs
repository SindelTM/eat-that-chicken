using System;

namespace EatThatChicken.Common.Events
{
    public class EndGameEventArgs : EventArgs
    {
        public EndGameEventArgs(int points)
        {
            this.Points = points;
        }

        public int Points { get; }
    }
}
