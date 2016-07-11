namespace EatThatChicken.Common.Events
{
    using System;
    using EatThatChicken.Common.Enumerations;

    public class KeyDownEventArgs : EventArgs
    {
        public GameAction Action { get; set; }

        public KeyDownEventArgs(GameAction action)
        {
            this.Action = action;
        }
    }
}
