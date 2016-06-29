using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EatThatChicken.Contracts;
using EatThatChicken.GameObjects;
using EatThatChicken.GameObjects.GameItems;

namespace EatThatChicken.Factories.ItemsFactory
{
    public class ItemGenerator
    {
        private Random Rand = new Random();

        public GameObject GenerateItems(int left, int top)
        {
            var allItems = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsClass)
                .Where(t => t.GetCustomAttributes(typeof(ItemAttribute), false).Any())
                .ToArray();

             int entityIndex = Rand.Next(0, allItems.Length);

             Size bounds = new Size(20,20);
             var entity =
                    Activator.CreateInstance(allItems[entityIndex], bounds, new Position(left, top)) as
                    GameObject;

            return entity;

        }
    }
}
