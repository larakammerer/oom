using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Task4
{
    public interface IDrumParts
    {
        string Material { get; }
        string Unit { get; }
        void UpdateDiameter(decimal newdiameter, string unit);
    }

    class Program
    {
        static void Main(string[] args)
        {
            //create objects with 'new'-operator
            Snaredrum SnareJazzset = new Snaredrum("Wood", 38.6M, "cm", "pinned");
            Basedrum BaseRockset = new Basedrum("   Wood", 22M, "inch", "single");
            Basedrum BaseMetalset = new Basedrum("Wood", 24M, "inch", "double");

            //print properties of objects to console using Console.Writeline
            Console.WriteLine(SnareJazzset.ToString());
            Console.WriteLine(BaseRockset.ToString());
            Console.WriteLine(BaseMetalset.ToString());

            //call methods on objects an print effects to console
            SnareJazzset.UpdateDiameter(14, "inch");
            Console.WriteLine("");
            Console.WriteLine("Changed part: " + SnareJazzset.ToString());

            //Create an array containing a mix of instances of all your classes which implement this interface
            var parts = new Snaredrum[]
            {
                new Snaredrum("Metal", 18M, "inch", "pinned"),
                new Snaredrum("Wood",16M, "inch", "loosened"),
                new Snaredrum ("Metal", 56M, "cm", "loosened"),
            };

            Console.WriteLine("");

            //add some test code similar to the lesson3 example (e.g. a loop which prints properties or returns values of method calls)
            foreach (var x in parts)
                Console.WriteLine(x.ToString());

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Auto;
            settings.Formatting = Formatting.Indented;

            using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(System.IO.File.Open(@"C:\Users\Lara\Documents\FH Technikum\2. Semester\Objektorientierte Methoden\oom\tasks\Task4\parts.json", System.IO.FileMode.Create)))
            {
                streamWriter.Write(JsonConvert.SerializeObject(parts, settings));
                streamWriter.Flush();
            }

            string json = System.IO.File.ReadAllText(@"C:\Users\Lara\Documents\FH Technikum\2. Semester\Objektorientierte Methoden\oom\tasks\Task4\parts.json");
            Snaredrum[] readParts = JsonConvert.DeserializeObject<Snaredrum[]>(json,settings);
            Console.WriteLine(json);
        }
    }
}