using System;

namespace EatThatChicken.Misc
{
    public class KeyDownEventArgs : EventArgs
    {
        public GameAction Action { get; set; }

        public KeyDownEventArgs(GameAction action)
        {
            this.Action = action;
        }
    }
}
