using System;
using System.Collections.Generic;

namespace mp3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Abstract");
            {
                Fruit apple = new Apple { Size = 5 };
                Fruit pineapple = new PineApple { Size = 5};
                List<Fruit> fruits = new List<Fruit> { apple, pineapple};
                fruits.ForEach(fruit =>
                {
                    Console.WriteLine(fruit);
                });
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine("Overlapping");
            {
                SpaceShip ship = new SpaceShip { Name = "Ship1"};
                ship.assaultShip = new SpaceShip.AssaultShip(ship, 5);
                ship.motherShip = new SpaceShip.MotherShip(ship, 3);
                ship.supplyShip = new SpaceShip.SupplyShip(ship, 4);
                Console.WriteLine($"{ship.Name} dmg:{ship.assaultShip.Damage} cap:{ship.motherShip.Capacity} cargo:{ship.supplyShip.Cargo}");
                SpaceShip ship2 = new SpaceShip { Name = "Ship2" };
                try
                {
                    Console.WriteLine($"{ship2.Name} dmg:{ship2.assaultShip.Damage} cap:{ship2.motherShip.Capacity} cargo:{ship2.supplyShip.Cargo}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine("Multi");
            {
                FlyingTower flyingTower = new FlyingTower { Damage = 5, Destination = "England", Speed = 3 };
                flyingTower.TravelTo("Spain");
                Console.WriteLine($"{flyingTower.Damage} {flyingTower.Speed} {flyingTower.Destination}");
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine("MultiAspect");
            {
                BuildingMaterial material = new ();
                material.Color = new BrightColor(material);
                material.Material = new SoftMaterial(material);
                Console.WriteLine($"{material.Material} {material.Color}");
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine("Dynamic");
            {
                Figure f = new Circle("Adam", 5.3);
                Console.WriteLine($"{f.Name}: {f.Area}");
                f = new Rectangle(f, 5.3, 5.4);
                Console.WriteLine($"{f.Name}: {f.Area}");
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }

    
}
