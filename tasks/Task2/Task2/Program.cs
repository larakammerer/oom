using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class drums
    {
        //1 constructor
        public drums (string newpart, string newmaterial, decimal newdiameter, string newunit)
        { 
            if (string.IsNullOrWhiteSpace(newpart)) throw new ArgumentException("Part must not be empty.");
            if (string.IsNullOrWhiteSpace(newmaterial)) throw new ArgumentException("Material must not be empty.");
            if (newdiameter < 0) throw new ArgumentOutOfRangeException("Diameter must not be neagtive.");
            if (string.IsNullOrWhiteSpace(newunit) || (newunit != "cm" && newunit != "inch")) throw new ArgumentException("Unit must be cm or inch.");

            part = newpart;
            material = newmaterial;
            UpdateDiameter(newdiameter, newunit);
        }

        //2 public properties (like title or ISBN)
        public string part { get; }
        public string material { get; private set; } //mögliche Materialien begrenzen!
        public string unit { get; private set; }

        //min 1 private field (like m_price)
        private decimal diameter;

        //1 public method
        public decimal getdiameter(string Unit)
        {
            if (Unit == "inch") return diameter;

            decimal rate = 2.54M;
            return diameter / rate;
        }

        //1 public method (like UpdatePrice)
        public void UpdateDiameter(decimal newdiameter, string Unit)
        {
            if (newdiameter < 0) throw new ArgumentOutOfRangeException("Diameter must not be negative");

            diameter = newdiameter;
            unit = Unit;
        }

        public string tostring()
        {
            return part + ", " + material + ", " + getdiameter(unit) + "inch";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //create objects with 'new'-operator
            drums Set_a = new drums("Snare", "Wood", 14, "inch");
            drums Set_b = new drums("Tom1", "Wood", 30,"cm");
            drums Set_c = new drums("Tom2", "Wood", 40,"cm");
            drums Set_d = new drums("Hi-Hat_Lower", "B20", 14,"inch");
            drums Set_e = new drums("Hi-Hat_Upper", "B20", 14,"inch");
            drums Set_f = new drums("Crash", "Bronze", 16,"inch");
            drums Set_g = new drums("Base", "Wood", 22,"inch");

            //print properties of objects to console using Console.Writeline
            Console.WriteLine(Set_a.tostring());
            Console.WriteLine(Set_b.tostring());
            Console.WriteLine(Set_c.tostring());
            Console.WriteLine(Set_d.tostring());
            Console.WriteLine(Set_e.tostring());
            Console.WriteLine(Set_f.tostring());
            Console.WriteLine(Set_g.tostring());


            //call methods on objects an print effects to console
            Set_f.UpdateDiameter(18, "inch");
            Console.WriteLine("");
            Console.WriteLine("Changed part: "+Set_f.tostring());
        }
    }
}
