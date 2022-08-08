using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace mp3
{
    public class SpaceShip
    {
        public string Name { get; set; }

        private MotherShip _motherShip;
        public MotherShip motherShip { get
            {
                if (IsMothership())
                {
                    return _motherShip;
                }
                else
                {
                    throw new NullReferenceException($"Ship {this} is not an MotherShip!");
                }

            }
            set {
                if(_motherShip != value)
                {
                    _motherShip = value;
                    value.SpaceShip = this;
                }

            } }
        private SupplyShip _supplyShip;
        public SupplyShip supplyShip { get
            {
                if (IsSupplyShip())
                {
                    return _supplyShip;
                }
                else
                {
                    throw new NullReferenceException($"Ship {this} is not an SupplyShip!");
                }

            }
            set
            {
                if (_supplyShip != value)
                {
                    _supplyShip = value;
                    value.SpaceShip = this;
                }

            }
        }
        private AssaultShip _assaultShip;
        public AssaultShip assaultShip { get {
                if (IsAssaultShip())
                {
                    return _assaultShip;
                }
                else
                {
                    throw new NullReferenceException($"Ship {this} is not an AssaultShip!");
                }
                
            } 
            set
            {
                if (_assaultShip != value)
                {
                    _assaultShip = value;
                    value.SpaceShip = this;
                }

            }
        }
        public bool IsMothership()
        {
            return _motherShip != null;
        }
        public bool IsAssaultShip()
        {
            return _assaultShip != null;
        }
        public bool IsSupplyShip()
        {
            return _supplyShip != null;
        }
        public class MotherShip
        {
            private SpaceShip _spaceShip;
            public SpaceShip SpaceShip { get => _spaceShip; 
                set {
                    if (_spaceShip != value)
                    {
                        _spaceShip = value;
                        value.motherShip = this;
                    }
                } }
            public MotherShip(SpaceShip s, int c)
            {
                if(s == null)
                {
                    throw new ArgumentNullException("You cannot assign null as parent Spaceship!");
                }
                _spaceShip = s;
                s.motherShip = this;
                Capacity = c;
            }
            public int Capacity { get; set; }
        }

        public class SupplyShip
        {
            private SpaceShip _spaceShip;
            public SpaceShip SpaceShip
            {
                get => _spaceShip; set
                {
                    if (_spaceShip != value)
                    {
                        _spaceShip = value;
                        value.supplyShip = this;
                    }
                }
            }
            public SupplyShip(SpaceShip s, int c)
            {
                if (s == null)
                {
                    throw new ArgumentNullException("You cannot assign null as parent Spaceship!");
                }
                _spaceShip = s;
                s.supplyShip = this;
                Cargo = c;
            }
            public int Cargo { get; set; }
        }

        public class AssaultShip
        {
            private SpaceShip _spaceShip;
            public SpaceShip SpaceShip
            {
                get => _spaceShip; 
                set
                {
                    if (_spaceShip != value)
                    {
                        _spaceShip = value;
                        value.assaultShip = this;
                    }
                }
            }
            public AssaultShip(SpaceShip s, int d)
            {
                if (s == null)
                {
                    throw new ArgumentNullException("You cannot assign null as parent Spaceship!");
                }
                _spaceShip = s;
                s.assaultShip = this;

                Damage = d;
            }
            public int Damage { get; set; }
        }

    }
}
