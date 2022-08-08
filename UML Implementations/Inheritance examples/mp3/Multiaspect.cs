using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mp3
{
    public class BuildingMaterial
    {
        private Color _Color;
        public Color Color { get => _Color; set {
                if (value.Parent != this)
                {
                    throw new ArgumentException($"Trying to assign part ({Color}) that already have parent");
                }
                else
                {
                    _Color = value;
                }
            } }
        private Material _Material;
        public Material Material
        {
            get => _Material; set
            {
                if (value.Parent != this)
                {
                    throw new ArgumentException($"Trying to assign part ({Material}) that already have parent");
                }
                else
                {
                    _Material = value;
                }
            }
        }
    }

    public abstract class Color
    {
        public int Density { get; set; }
        public Color(BuildingMaterial material)
        {
            _Parent = material;
        }
        private BuildingMaterial _Parent;
        public BuildingMaterial Parent { get => _Parent; }
    }

    public class BrightColor : Color
    {
        public BrightColor(BuildingMaterial material) : base(material)
        {
           
        }

        public override string ToString()
        {
            return "BrightColor";
        }

    }

    public class DarkColor : Color
    {
        public DarkColor(BuildingMaterial material) : base(material)
        {

        }
        public override string ToString()
        {
            return "DarkColor";
        }
    }

    public abstract class Material
    {
        public string Type { get; set; }
        public Material(BuildingMaterial material)
        {
            _Parent = material;
        }
        private BuildingMaterial _Parent;
        public BuildingMaterial Parent { get => _Parent; }

    }

    public class HardMaterial : Material
    {
        public HardMaterial(BuildingMaterial material) : base(material)
        {

        }
        public override string ToString()
        {
            return "HardMaterial";
        }
    }

    public class SoftMaterial : Material
    {
        public SoftMaterial(BuildingMaterial material) : base(material)
        {

        }
        public override string ToString()
        {
            return "SoftMaterial";
        }
    }
}
