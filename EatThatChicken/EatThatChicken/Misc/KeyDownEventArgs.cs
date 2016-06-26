namespace EatThatChicken.Misc
{
    using System;

    public class KeyDownEventArgs : EventArgs
    {
        public GameAction Action { get; set; }

        public KeyDownEventArgs(GameAction action)
        {
            this.Action = action;
        }
    }
}
