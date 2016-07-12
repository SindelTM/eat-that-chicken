namespace EatThatChicken.Common.Events
{
    using System;
    using EatThatChicken.Common.Enumerations;

    public class KeyDownEventArgs : EventArgs
    {
        public GameActionType Action { get; set; }

        public KeyDownEventArgs(GameActionType action)
        {
            this.Action = action;
        }
    }
}
