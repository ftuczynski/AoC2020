using System;
using System.IO;
using System.Linq;

namespace AdventD06 {
    class Program {
        static void Main(string[] args) {
            try {
                var answers = File.ReadAllText("input.txt")
                    .Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None);

                // PART 1
                var ans1 = answers.Select(x => x.Replace(Environment.NewLine, "").ToCharArray().Distinct().Count()).Sum();
                Console.WriteLine($"Part 1: {ans1}");

                // PART 2
                var ans2 = answers.Select(x => x.Split('\n').Select(y => y.ToCharArray().Distinct()))
                    .Select(x => x.Aggregate((total, next) => total.Intersect(next).ToList()).Count()).Sum();
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
