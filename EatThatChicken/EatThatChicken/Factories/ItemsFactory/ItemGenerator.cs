namespace EatThatChicken.Factories.ItemsFactory
{
    using System;
    using System.Linq;
    using System.Reflection;
    using GameObjects;
    using GameObjects.GameItems;

    public class ItemGenerator
    {
        private Random Rand = new Random();

        private const int ItemDefaultSpeed = 6;
        private const int ItemDefaultWidth = 20;
        private const int ItemDefaultHeight = 20;

        public GameObject GenerateItems(int left, int top)
        {
            var allItems = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass)
                .Where(t => t.GetCustomAttributes(typeof(ItemAttribute), false).Any())
                .ToArray();

            int entityIndex = Rand.Next(0, allItems.Length);

            Size bounds = new Size(ItemDefaultWidth, ItemDefaultHeight);
            var entity =
                   Activator.CreateInstance(allItems[entityIndex], ItemDefaultSpeed, bounds, new Position(left, top)) as
                   GameObject;

            return entity;

        }
    }
}
