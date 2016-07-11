namespace EatThatChicken.Contracts
{
    using EatThatChicken.Misc;
    using System;

    interface IWPFGameRenderer : IGameRenderer
    {
        event EventHandler<EndGameEventArgs> EndGameAction;
    }
}
