using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    public class Basedrum : IDrumParts
    {
        //constructor
        public Basedrum(string material, decimal diameter, string unit, string pedal)
        {
            if (string.IsNullOrWhiteSpace(material)) throw new ArgumentException("Material must not be empty.");
            if (diameter < 0) throw new ArgumentOutOfRangeException("Diameter must not be neagtive.");
            if (string.IsNullOrWhiteSpace(unit) || (unit != "cm" && unit != "inch")) throw new ArgumentException("Unit must be cm or inch.");
            if (string.IsNullOrWhiteSpace(pedal)) throw new ArgumentException("Pedal must not be empty.");
            if (pedal != "single" && pedal != "double") throw new ArgumentException("Pedal must be single or double.");

            Material = material;
            UpdateDiameter(diameter, unit);
            Pedal = pedal;
        }

        //public properties
        public string Material { get; }
        public string Unit { get; private set; }
        public string Pedal { get; private set; }

        //private field
        private decimal Diameter;

        //public method
        public decimal GetDiameter(string Unit)
        {
            if (Unit == "inch") return Diameter;

            decimal Rate = 2.54M;
            return Diameter / Rate;
        }

        //public method
        public void UpdateDiameter(decimal diameter, string unit)
        {
            if (diameter < 0) throw new ArgumentOutOfRangeException("Diameter must not be negative");

            Diameter = diameter;
            Unit = unit;
        }

        public void UpdatePedal(string pedal)
        {
            if (string.IsNullOrWhiteSpace(pedal)) throw new ArgumentException("Pedal must not be empty.");
            if (pedal != "pinned" && pedal != "loosened") throw new ArgumentException("Pedal must be single or double.");

            Pedal = pedal;
        }

        override public string ToString()
        {
            return Material + ", " + GetDiameter(Unit) + "inch, " + Pedal + " pedal";
        }
    }

}
