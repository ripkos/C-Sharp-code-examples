using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mp4
{
    public class Warrior
    {
        public int HP { get; set; }
        private int _Strength;
        private const int _minStrength = 10;
        private const int _maxStrength = 17;

        public int Strength { 
            get { return _Strength; } 
            set {
            if (value > _minStrength || value < _maxStrength)
                {
                    throw new ArgumentException($"Strength must be between {_minStrength} and {_maxStrength} , got {value} isntead");
                }
            else
                {
                    _Strength = value;
                }
            } }
    }
}
