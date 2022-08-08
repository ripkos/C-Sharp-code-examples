using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mp4
{
    public class Item
    {
        private static List<Item> Items= new List<Item>();
        public bool AddItem(Item i)
        {
            if (Items.Contains(i))
            {
                return false;
            }
            else
            {
                Items.Add(i);
                Items = Items.OrderByDescending(i => i.Price).ToList();
                return true;
            }
        }
        public static void ShowPrices()
        {
            foreach(Item i in Items)
            {
                Console.WriteLine(i.Price);
            }
        }
        public Item(int p)
        {
            Price = p;
            AddItem(this);
        }
        public int Price { get; set; }
    }

}
