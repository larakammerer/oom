using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public interface drumparts
    {
        string Material { get; }
        string Unit { get; }
        void UpdateDiameter(decimal newdiameter, string unit);
    }

    public class Snaredrum:drumparts
    {
        //constructor
        public Snaredrum(string newmaterial, decimal newdiameter, string newunit, string newsnares)
        {
            if (string.IsNullOrWhiteSpace(newmaterial)) throw new ArgumentException("Material must not be empty.");
            if (newdiameter < 0) throw new ArgumentOutOfRangeException("Diameter must not be neagtive.");
            if (string.IsNullOrWhiteSpace(newunit) || (newunit != "cm" && newunit != "inch")) throw new ArgumentException("Unit must be cm or inch.");
            if (string.IsNullOrWhiteSpace(newsnares)) throw new ArgumentException("Snares must not be empty.");
            
            Material = newmaterial;
            UpdateDiameter(newdiameter, newunit);
            Snares = newsnares;
        }
    
        //public properties
        public string Material { get; }
        public string Unit { get; private set; }
        public string Snares { get; }

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

        override public string ToString()
        {
            return Material + ", " + GetDiameter(Unit) + "inch, snares " + Snares;
        }
    }

    public class Basedrum : drumparts
    {
        //constructor
        public Basedrum(string newmaterial, decimal newdiameter, string newunit, string newpedal)
        {
            if (string.IsNullOrWhiteSpace(newmaterial)) throw new ArgumentException("Material must not be empty.");
            if (newdiameter < 0) throw new ArgumentOutOfRangeException("Diameter must not be neagtive.");
            if (string.IsNullOrWhiteSpace(newunit) || (newunit != "cm" && newunit != "inch")) throw new ArgumentException("Unit must be cm or inch.");
            if (string.IsNullOrWhiteSpace(newpedal)) throw new ArgumentException("Pedal must not be empty.");

            Material = newmaterial;
            UpdateDiameter(newdiameter, newunit);
            Pedal = newpedal;
        }

        //public properties
        public string Material { get; }
        public string Unit { get; private set; }
        public string Pedal { get; }

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

        override public string ToString()
        {
            return Material + ", " + GetDiameter(Unit) + "inch, " + Pedal + " pedal";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //create objects with 'new'-operator
            Snaredrum SnareJazzset = new Snaredrum("Wood", 38.6M, "cm", "pinned");
            Basedrum BaseRockset  = new Basedrum("Wood", 22, "inch", "single");
            Basedrum BaseMetalset = new Basedrum("Wood", 24, "inch", "double");

            //print properties of objects to console using Console.Writeline
            Console.WriteLine(SnareJazzset.ToString());
            Console.WriteLine(BaseRockset.ToString());
            Console.WriteLine(BaseMetalset.ToString());

            //call methods on objects an print effects to console
            SnareJazzset.UpdateDiameter(14, "inch");
            Console.WriteLine("");
            Console.WriteLine("Changed part: " + SnareJazzset.ToString());

            //Create an array containing a mix of instances of all your classes which implement this interface
            var parts = new drumparts[]
            {
                new Snaredrum("Wood",16, "inch", "loosened"),
                new Basedrum ("Wood", 56, "cm", "double"),
            };

            Console.WriteLine("");

            //add some test code similar to the lesson3 example (e.g. a loop which prints properties or returns values of method calls)
            foreach (var x in parts)
                Console.WriteLine(x.ToString());
        }
    }
}
