using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Task6
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
            Snaredrum SnareJazzset = new Snaredrum("Wood", 38.6M, "cm", "pinned");
            Basedrum BaseRockset = new Basedrum("Wood", 22M, "inch", "single");
            Basedrum BaseMetalset = new Basedrum("Wood", 24M, "inch", "double");

            Console.WriteLine(SnareJazzset.ToString());
            Console.WriteLine(BaseRockset.ToString());
            Console.WriteLine(BaseMetalset.ToString());

            Console.WriteLine("");
            Console.WriteLine("-------------------------UpdateDiameter---------------------------");
            SnareJazzset.UpdateDiameter(14, "inch");
            Console.WriteLine("Changed part: " + SnareJazzset.ToString());

            var parts = new Snaredrum[]
            {
                new Snaredrum("Metal", 18M, "inch", "pinned"),
                new Snaredrum("Wood",16M, "inch", "loosened"),
                new Snaredrum ("Metal", 56M, "cm", "loosened"),
            };

            Console.WriteLine("");
            Console.WriteLine("-------------------------for each - array---------------------------");

            foreach (var x in parts)
                Console.WriteLine(x.ToString());

            Console.WriteLine("");
            Console.WriteLine("-------------------------Json Using---------------------------");
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Auto;
            settings.Formatting = Formatting.Indented;

            using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(System.IO.File.Open(@"C:\Users\Lara\Documents\FH Technikum\2. Semester\Objektorientierte Methoden\oom\tasks\Task4\parts.json", System.IO.FileMode.Create)))
            {
                streamWriter.Write(JsonConvert.SerializeObject(parts, settings));
                streamWriter.Flush();
            }

            string json = System.IO.File.ReadAllText(@"C:\Users\Lara\Documents\FH Technikum\2. Semester\Objektorientierte Methoden\oom\tasks\Task4\parts.json");
            Snaredrum[] readParts = JsonConvert.DeserializeObject<Snaredrum[]>(json, settings);
            Console.WriteLine(json);

            Console.WriteLine("");
            Console.WriteLine("-------------------------Subject---------------------------");

            Subject<Snaredrum> subject = new Subject<Snaredrum>();
            List<Snaredrum> target = new List<Snaredrum>();

            subject.Subscribe<Snaredrum>(s => { target.Add(s); /*Console.WriteLine(s.ToString); */});

            for (int i=1; i<=10;i++)
            {
                int copy = i;
                Task<int> wait = Task.Run(() => takesLong(copy));
                wait.ContinueWith(x => Console.WriteLine("Returned: "+ x.Result));
            }

            System.Threading.Thread.Sleep(11000);
        }

        private static int takesLong (int number)
        {
            Console.WriteLine("Got: " + number);
            System.Threading.Thread.Sleep(number * 1000);
            return number*1000;
        }
    }
}