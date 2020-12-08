using System;
using System.IO;
using System.Linq;

namespace AdventD07 {
    class Program {
        static void Main(string[] args) {
            try {
                var input = File.ReadAllLines("input.txt");
                var bags = input.Select(x => new Bag(x)).ToList();

                // PART 1
                var ans1 = bags.Count(x => x.ContainsBag("shiny gold", bags));
                Console.WriteLine($"Part 1: {ans1}");

                // PART 2
                var ans2 = Bag.GetBag("shiny gold", bags).HowManyBags(bags);
                Console.WriteLine($"Part 2: {ans2}");
            }
            catch (IOException e) {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
