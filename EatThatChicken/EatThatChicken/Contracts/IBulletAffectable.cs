using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatThatChicken.Contracts
{
    public interface IBulletAffectable
    {
        void AffectHunterPointsByBullet(IHunter hunter);
    }
}
