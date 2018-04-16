using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Snaredrum : IDrumParts
    {
        //constructor
        public Snaredrum(string material, decimal diameter, string unit, string snares)
        {
            if (string.IsNullOrWhiteSpace(material)) throw new ArgumentException("Material must not be empty.");
            if (diameter < 0) throw new ArgumentOutOfRangeException("Diameter must not be neagtive.");
            if (string.IsNullOrWhiteSpace(unit) || (unit != "cm" && unit != "inch")) throw new ArgumentException("Unit must be cm or inch.");
            if (string.IsNullOrWhiteSpace(snares)) throw new ArgumentException("Snares must not be empty.");
            if (snares != "pinned" && snares != "loosened") throw new ArgumentException("Snares must be pinned or loosened.");

            Material = material;
            UpdateDiameter(diameter, unit);
            Snares = snares;
        }

        //public properties
        public string Material { get; }
        public string Unit { get; private set; }
        public string Snares { get; private set; }

        //field
        public decimal Diameter;

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

        public void UpdateSnares(string snares)
        {
            if (string.IsNullOrWhiteSpace(snares)) throw new ArgumentException("Snares must not be empty.");
            if (snares != "pinned" && snares != "loosened") throw new ArgumentException("Snares must be pinned or loosened.");

            Snares = snares;
        }

        override public string ToString()
        {
            return Material + ", " + GetDiameter(Unit) + "inch, snares " + Snares;
        }
    }

}
