namespace EatThatChicken.GameObjects.Birds
{
    using System;
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Bird : GameObject, IMoveable, IUpdateable
    {
        public Bird()
            :base()
        {
        }

        public Size Bounds { get; set; }

        public Position Position { get; set; }

        public virtual bool IsAlive { get; set; }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}
