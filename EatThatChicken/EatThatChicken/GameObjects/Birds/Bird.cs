﻿namespace EatThatChicken.GameObjects.Birds
{
    using Common;
    using Contracts;
    using Enumerations;
    public abstract class Bird : GameObject, IMoveable, IAffectableGameObject
    {
        private const MoveType Top = MoveType.Decremental;
        private const MoveType Left = MoveType.None;
        private int health;

        protected Bird(int health, int score, Size bounds, Position position, int speed)
            : base(bounds, position, new MoveAction(Left, Top, speed))
        {
            this.Health = health;
        }

        protected int Health { get; set; }

        public override bool IsAlive
        {
            get
            {
                return this.Health > 0;
            }
            set
            {
                if (!value)
                {
                    --this.Health;
                }
            }
        }

        public virtual void AffectHunter(IHunter hunter)
        {
            if (hunter.NumberOfLifes >= 1 && hunter.NumberOfLifes <= 3)
            {
                hunter.NumberOfLifes--;
            }
        }
    }
}
