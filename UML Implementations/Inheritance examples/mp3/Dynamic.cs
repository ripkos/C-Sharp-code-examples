using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mp3
{
    public abstract class Figure
    {
        public string Name { get; private set; }
        public Figure(string s)
        {
            Name = s;
        }
        public Figure(Figure f)
        {
            Name = f.Name;
        }
        public virtual double Area { get; }

    }

    public class Circle : Figure
    {
        public Circle(Figure f, double r) : base(f)
        {
            R = r;
        }
        public Circle(string s, double r) : base(s)
        {
            R = r;
        }
        public double R { get; private set; }
        public override double Area => R*R*22/7;
    }

    public class Rectangle : Figure
    {
        public double Width { get; private set; }
        public double Height { get; private set; }
        public Rectangle(Figure f, double w, double h) : base(f)
        {
            Width = w;
            Height = h;
        }
        public Rectangle(string s, double w, double h) : base(s)
        {
            Width = w;
            Height = h;
        }
        public override double Area => Width*Height;
    }
}
