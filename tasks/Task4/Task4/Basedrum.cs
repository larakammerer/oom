using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Basedrum : drumparts
    {
        //constructor
        public Basedrum(string newmaterial, decimal newdiameter, string newunit, string newpedal)
        {
            if (string.IsNullOrWhiteSpace(newmaterial)) throw new ArgumentException("Material must not be empty.");
            if (newdiameter < 0) throw new ArgumentOutOfRangeException("Diameter must not be neagtive.");
            if (string.IsNullOrWhiteSpace(newunit) || (newunit != "cm" && newunit != "inch")) throw new ArgumentException("Unit must be cm or inch.");
            if (string.IsNullOrWhiteSpace(newpedal)) throw new ArgumentException("Pedal must not be empty.");
            if (newpedal != "single" && newpedal != "double") throw new ArgumentException("Pedal must be single or double.");

            Material = newmaterial;
            UpdateDiameter(newdiameter, newunit);
            Pedal = newpedal;
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
        public void UpdateDiameter(decimal newdiameter, string newunit)
        {
            if (newdiameter < 0) throw new ArgumentOutOfRangeException("Diameter must not be negative");

            Diameter = newdiameter;
            Unit = newunit;
        }

        public void UpdatePedal(string newpedal)
        {
            if (string.IsNullOrWhiteSpace(newpedal)) throw new ArgumentException("Pedal must not be empty.");
            if (newpedal != "pinned" && newpedal != "loosened") throw new ArgumentException("Pedal must be single or double.");

            Pedal = newpedal;
        }

        override public string ToString()
        {
            return Material + ", " + GetDiameter(Unit) + "inch, " + Pedal + " pedal";
        }
    }

}
