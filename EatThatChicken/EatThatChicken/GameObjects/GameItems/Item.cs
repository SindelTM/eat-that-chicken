using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatThatChicken.GameObjects.GameItems
{
    public abstract class Item : GameObject
    {
        protected Item(Size bounds, Position position, MoveAction moveAction) 
            : base(bounds, position, moveAction)
        {
        }
    }
}
