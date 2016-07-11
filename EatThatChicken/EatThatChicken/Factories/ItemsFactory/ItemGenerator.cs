namespace EatThatChicken.Factories.ItemsFactory
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Common;
    using Common.Structs;
    using GameObjects.GameItems;

    public class ItemGenerator
    {
        private Random Rand = new Random();

        private const int ItemDefaultSpeed = 10;
        private const int ItemDefaultWidth = 20;
        private const int ItemDefaultHeight = 20;

        public Item GenerateItems(int left, int top)
        {
            var allItems = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass)
                .Where(t => t.GetCustomAttributes(typeof(ItemAttribute), false).Any())
                .ToArray();

            int randomIndex = Rand.Next(0, allItems.Length);

            Size bounds = new Size(ItemDefaultWidth, ItemDefaultHeight);
            var item =
                   Activator.CreateInstance(allItems[randomIndex], ItemDefaultSpeed, bounds, new Position(left, top)) as
                   Item;

            return item;
        }
    }
}
