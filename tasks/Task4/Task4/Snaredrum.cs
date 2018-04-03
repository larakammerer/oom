using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Snaredrum : drumparts
    {
        //constructor
        public Snaredrum(string newmaterial, decimal newdiameter, string newunit, string newsnares)
        {
            if (string.IsNullOrWhiteSpace(newmaterial)) throw new ArgumentException("Material must not be empty.");
            if (newdiameter < 0) throw new ArgumentOutOfRangeException("Diameter must not be neagtive.");
            if (string.IsNullOrWhiteSpace(newunit) || (newunit != "cm" && newunit != "inch")) throw new ArgumentException("Unit must be cm or inch.");
            if (string.IsNullOrWhiteSpace(newsnares)) throw new ArgumentException("Snares must not be empty.");
            if (newsnares != "pinned" && newsnares != "loosened") throw new ArgumentException("Snares must be pinned or loosened.");

            Material = newmaterial;
            UpdateDiameter(newdiameter, newunit);
            Snares = newsnares;
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
        public void UpdateDiameter(decimal newdiameter, string newunit)
        {
            if (newdiameter < 0) throw new ArgumentOutOfRangeException("Diameter must not be negative");

            Diameter = newdiameter;
            Unit = newunit;
        }

        public void UpdateSnares(string newsnares)
        {
            if (string.IsNullOrWhiteSpace(newsnares)) throw new ArgumentException("Snares must not be empty.");
            if (newsnares != "pinned" && newsnares != "loosened") throw new ArgumentException("Snares must be pinned or loosened.");

            Snares = newsnares;
        }

        override public string ToString()
        {
            return Material + ", " + GetDiameter(Unit) + "inch, snares " + Snares;
        }
    }

}
