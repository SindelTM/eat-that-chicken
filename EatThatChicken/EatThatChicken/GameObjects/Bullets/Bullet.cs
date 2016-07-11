using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using EatThatChicken.Common;
using EatThatChicken.Common.Enumerations;
using EatThatChicken.Common.Structs;
using EatThatChicken.Contracts;
using EatThatChicken.GameObjects.Birds;
using Size = EatThatChicken.Common.Structs.Size;

namespace EatThatChicken.GameObjects.Bullets
{
    public class Bullet : GameObject, IBullet
    {
        private const int defaultSpeed = 40;
        private const MoveType defaultTop = MoveType.Incremental;
        private const MoveType defaultLeft = MoveType.None;

        public Bullet(Size bounds, Position position)
            : base(bounds, position, new MoveAction(defaultLeft, defaultTop, defaultSpeed)) { }
    }
}