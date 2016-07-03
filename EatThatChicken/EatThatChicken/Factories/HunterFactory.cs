using EatThatChicken.Contracts;
using EatThatChicken.GameObjects;
using EatThatChicken.GameObjects.Hunters;

namespace EatThatChicken.Factories
{
    public class HunterFactory : IGameObjectFactory<Hunter>
    {
        const int HunterHeight = 190;
        const int HunterWidth = 90;
        const int HunterPoints = 100;

        public Hunter Get(int screenHeight, int screenWidth)
        {
            Position position = new Position((screenWidth - HunterWidth)/2, (screenHeight - HunterHeight));
            Size bounds = new Size(HunterWidth, HunterHeight);

            return new Hunter(bounds, position);
        }
    }
}