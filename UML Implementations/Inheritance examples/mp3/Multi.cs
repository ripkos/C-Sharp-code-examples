using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mp3
{
    public interface INavigable
    {
        public string Destination { get; set; }

    }
    public static class NavigationExtention
    {
        public static void TravelTo(this INavigable navigable, string Destination)
        {
            navigable.Destination = Destination;
        }
    }
    public interface IFlying
    {
        public int Speed { get; set; }
    }
    public interface ITower
    {
        public int Damage { get; set; }
    }
    public class FlyingTower : INavigable, IFlying, ITower
    {
        public int Damage { get; set; }
        public int Speed { get; set; }
        public string Destination { get; set; }
    }
}
