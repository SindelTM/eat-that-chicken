using EatThatChicken.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatThatChicken.Engines
{
    class GameEngine
    {
        private IGameRenderer renderer { get; set; }

        public GameEngine(IGameRenderer renderer)
        {
            this.renderer = renderer;
        }

        public void InitGame()
        {
            throw new NotImplementedException();
        }

        public void StartGame()
        {
            throw new NotImplementedException();
        }
    }
}
