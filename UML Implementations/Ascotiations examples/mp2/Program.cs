using System;
using System.Collections.Generic;

namespace mp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Asocjacja zwykła:");
            var l1 = new LeftSide("l1");
            LeftSide l2 = new() { Name = "l2" };
            RightSide r1 = new() { Name = "r1" };
            
            r1.AddLeftSide(l1);
            r1.AddLeftSide(l1);
            r1.AddLeftSide(l2);
            l2.AddRightSide(r1);
            Console.WriteLine(r1.ToStringWithSides());
            Console.WriteLine(l1.ToStringWithSides());
            Console.WriteLine(l2.ToStringWithSides());

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Asocjacja z atrybutem");

            var a1 = new PointA("a1");
            var a2 = new PointA("a2");
            var b1 = new PointB("b1");
            var ab1 = new ABDistances(a1, b1, 3);
            var ab2 = new ABDistances(a1, b1, 4);
            var ab3 = new ABDistances(a2, b1, 5);
            a1.ShowAllDistances();
            a2.ShowAllDistances();
            b1.ShowAllDistances();

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Asocjacja kwalifikowana");
            var ship1 = new SpaceShip(1, "Alef");
            var ship2 = new SpaceShip(2, "Bet");
            var port = new SpacePort("Gimel");
            port.AddSpaceShip(ship1);
            port.AddSpaceShip(ship2);
            Console.WriteLine(port.FindSpaceShipByID(1).Name);
            try
            {
                Console.WriteLine(port.FindSpaceShipByID(3).Name);
            }
            catch
            {
                Console.WriteLine("There is no spaceship with ID 3");
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Kompozycja:");
            var k1 = new KoszykOwocowy("K1");
            var owoc1 = k1.AddOwoc("arbuz");
            var owoc2 = k1.AddOwoc("truskawka");
            KoszykOwocowy.Owoc owoc3 = new(k1, "owoc3");
            Console.WriteLine(owoc3.KoszykOwocowy);
            Console.ReadLine();

        }
    }

    public class LeftSide
    {
        public string Name { get; set; }
        public List<RightSide> RightSides { get; set; }
        public LeftSide(string name)
        {
            RightSides = new List<RightSide>();
            Name = name;
        }

        public LeftSide()
        {
            RightSides = new List<RightSide>();
        }

        public void AddRightSide(RightSide s)
        {
            if (!RightSides.Contains(s))
            {
                RightSides.Add(s);
                s.AddLeftSide(this);
            }

        }
        public string ToStringWithSides()
        {
            return Name + " + " + String.Join(" ", RightSides);
        }
        public override string ToString()
        {
            return Name;
        }

    }
    public class RightSide
    {
        public string Name { get; set; }
        public List<LeftSide> LeftSides { get; set; } = new();
        public RightSide(string name)
        {
            LeftSides = new List<LeftSide>();
            Name = name;
        }
        public RightSide()
        {
            LeftSides = new List<LeftSide>();
        }
        public void AddLeftSide(LeftSide s)
        {
            if (!LeftSides.Contains(s))
            {
                LeftSides.Add(s);
                s.AddRightSide(this);
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public string ToStringWithSides()
        {
            return Name + " + " + String.Join(" ", LeftSides);
        }

    }
    public class PointA
    {
        public List<ABDistances> ABDistances { get; set; }
        public PointA(string name)
        {
            ABDistances = new List<ABDistances>();
            Name = name;
        }
        public string Name { get; set; }
        public void AddABDistances(ABDistances abd)
        {
            ABDistances.Add(abd);
        }
        public void ShowAllDistances()
        {
            foreach(ABDistances abd in ABDistances)
            {
                Console.WriteLine($"From {Name} to {abd.PointB.Name} with distance {abd.Distance}");
            }
        }
    }

    public class PointB
    {
        public List<ABDistances> ABDistances { get; set; }
        public PointB(string name)
        {
            ABDistances = new List<ABDistances>();
            Name = name;
        }
        public string Name { get; set; }
        public void AddABDistances(ABDistances abd)
        {
            ABDistances.Add(abd);
        }

        public void ShowAllDistances()
        {
            foreach (ABDistances abd in ABDistances)
            {
                Console.WriteLine($"From {Name} to {abd.PointA.Name} with distance {abd.Distance}");
            }
        }
    }

    public class ABDistances
    {
        public PointA PointA { get; set; }
        public PointB PointB { get; set; }
        public int Distance { get; set; }
        public ABDistances(PointA a, PointB b, int d)
        {
            PointA = a;
            PointB = b;
            Distance = d;
            //link
            a.AddABDistances(this);
            b.AddABDistances(this);


    }
        
    }

    public class SpaceShip
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<SpacePort> SpacePorts { get; set; }
        public SpaceShip(int id, string n)
        {
            ID = id;
            Name = n;
            SpacePorts = new();
        }
        public void AddSpacePort(SpacePort s)
        {
            if (!SpacePorts.Contains(s))
            {
                SpacePorts.Add(s);
                s.AddSpaceShip(this);
            }
        }
    }

    public class SpacePort
    {
        public Dictionary<int, SpaceShip> SpaceShips { get; set; }
        public string Name { get; set; }
        public SpacePort(string n)
        {
            SpaceShips = new();
            Name = n;
        }
        public void AddSpaceShip(SpaceShip s)
        {
            if (!SpaceShips.ContainsKey(s.ID))
            {
                SpaceShips.Add(s.ID, s);
                s.AddSpacePort(this);
            }
        }
        public SpaceShip FindSpaceShipByID(int id)
        {
            var ship = SpaceShips.GetValueOrDefault(id, null);
            if(ship is null)
            {
                throw new KeyNotFoundException($"Cannot find spaceship with id {id}");
            }
            return ship;
        }
    }

    public class KoszykOwocowy
    {
        private List<Owoc> Owoce { get; set; }
        public string KoszName { get; set; }
        public KoszykOwocowy(string n)
        {
            Owoce = new();
            KoszName = n;
        }
        public Owoc AddOwoc(string owocName)
        {
            Owoc ow = new Owoc(this, owocName);
            return ow;
        }
        ~KoszykOwocowy()
        {
            Owoce.Clear();
        }
        private void AddOwoc(Owoc o)
        {
            if (!Owoce.Contains(o))
            {
                Owoce.Add(o);
            }
        }
        public override string ToString()
        {
            return $"{KoszName} z {String.Join(" ", Owoce)}";
        }
        public class Owoc
        {
            private KoszykOwocowy _koszykOwocowy;
            public KoszykOwocowy KoszykOwocowy { get => _koszykOwocowy; }
            public Owoc(KoszykOwocowy ko,string n)
            {
                _koszykOwocowy = ko;
                ko.AddOwoc(this);
                Name = n;
            }
            public string Name { get; set; }
            public override string ToString()
            {
                return Name;
            }
            public override bool Equals(object obj)
            {
                if(obj is Owoc)
                {
                    return this.Name.Equals(((Owoc)obj).Name);
                }
                return base.Equals(obj);
            }
        }

    }
}
