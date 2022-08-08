using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mp4
{
    public class Beer
    {
        public List<BeerLover> BeerLovers { get; private set; }
        public List<BeerLover> BeerResidents { get; private set; }
        public string Name { get; set; }
        public Beer(string name)
        {
            Name = name;
            BeerLovers = new List<BeerLover>();
            BeerResidents = new List<BeerLover>();
        }
        public bool AddBeerLover(BeerLover b)
        {
            if (BeerLovers.Contains(b))
            {
                return false;
            }
            else
            {
                BeerLovers.Add(b);
                b.AddBeer(this);
                return true;
            }
        }
        public bool AddBeerResident(BeerLover b, bool force = false)
        {
            if (BeerResidents.Contains(b))
            {
                return false;
            }
            else
            {
                if (BeerLovers.Contains(b) || force)
                {
                    AddBeerLover(b);
                    BeerResidents.Add(b);
                    return true;
                }
                else
                {
                    throw new ArgumentException($"Beer {this.Name} must have BeerLover {b.FirstName} in BeerLovers! Or use force = true");
                }
            }
        }
    }
    public class BeerLover
    {
        public List<Beer> Beers { get; private set; }
        public List<Beer> FavoriteBeers { get; private set; }
        public string FirstName { get; set; }
        public BeerLover(string name)
        {
            FirstName = name;
            Beers = new List<Beer>();
            FavoriteBeers = new List<Beer>();
        }
        public bool AddBeer(Beer b)
        {
            if (Beers.Contains(b))
            {
                return false;
            }
            else
            {
                Beers.Add(b);
                b.AddBeerLover(this);
                return true;
            }
        }
        public bool AddFavoriteBeer(Beer b, bool force = false)
        {
            if (FavoriteBeers.Contains(b))
            {
                return false;
            }
            else
            {
                if(Beers.Contains(b) || force)
                {
                    AddBeer(b);
                    FavoriteBeers.Add(b);
                    b.AddBeerResident(this);
                    return true;
                }
                else
                {
                    throw new ArgumentException($"BeerLover {this.FirstName} must have Beer {b.Name} in Beers! Or use force = true");
                }
            }
        }
    }
}
