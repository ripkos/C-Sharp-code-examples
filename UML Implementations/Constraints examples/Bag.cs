using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mp4
{
    public class Client
    {
        private List<Order> Orders { get; set; }
        public string Name { get; set; }
        public Client(string n)
        {
            Name = n;
            Orders = new List<Order>();
        }
        public bool AddOrder(Order o)
        {
            if (Orders.Contains(o))
            {
                return false;
            }
            else
            {
                Orders.Add(o);
                return true;
            }
            
        }
    }
    public class Order
    {
        public Client Client { get; private set; }
        public Shop Shop { get; private set; }
        public DateTime OrderDate { get; set; }
        public Order(Client c, Shop s, DateTime d) 
        {
            Client = c;
            Shop = s;
            OrderDate = d;
            c.AddOrder(this);
            s.AddOrder(this);
        }
    }
    public class Shop
    {
        private List<Order> Orders { get; set; }
        public string Name { get; set; }
        public Shop(string n)
        {
            Name = n;
            Orders = new List<Order>();
        }
        public bool AddOrder(Order o)
        {
            if (Orders.Contains(o))
            {
                return false;
            }
            else
            {
                Orders.Add(o);
                return true;
            }
        }
    }
}
