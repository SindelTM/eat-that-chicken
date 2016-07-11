namespace EatThatChicken.Contracts
{
    using System;
    using EatThatChicken.Common.Events;

    interface IWPFGameRenderer : IGameRenderer
    {
        event EventHandler<EndGameEventArgs> EndGameAction;
    }
}
