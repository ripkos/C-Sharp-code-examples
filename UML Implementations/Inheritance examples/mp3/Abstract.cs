using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mp3
{
    public abstract class Fruit
    {
        public virtual int Mass { get => Size; }
        public int Size { get; set; }
    }

    public class Apple : Fruit
    {
        public override int Mass { get => 2 * Size; }
        public override string ToString()
        {
            return $"Apple {Mass}kg";
        }
    }
    public class PineApple : Fruit
    {
        public override int Mass { get => 3 * Size; }
        public override string ToString()
        {
            return $"PineApple {Mass}kg";
        }
    }
}
