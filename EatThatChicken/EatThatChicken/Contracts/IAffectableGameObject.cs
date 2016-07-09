using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EatThatChicken.GameObjects.Birds;

namespace EatThatChicken.Contracts
{
    public interface IAffectableGameObject : IGameObject
    {
        void AffectHunter(IHunter hunter);
    }
}
