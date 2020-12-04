using System;
using System.IO;
using System.Linq;

namespace AdventD04 {
    class Program {
        static void Main(string[] args) {
            try {
                var passports = File.ReadAllText("input.txt")
                    .Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None)
                    .Select(x => x.Replace(Environment.NewLine, " "));

                // PART 1
                int count = passports
                    .Where(x => DoesPassportHaveAllFields(x))
                    .Count();

                Console.WriteLine("Part 1:" + count);

                // PART 2

            }
            catch (IOException e) {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
        private static bool DoesPassportHaveAllFields(string passport) {
            var fields = new string[] { "byr:", "iyr:", "eyr:", "hgt:", "hcl:", "ecl:", "pid:" };
            return fields.All(x => passport.Contains(x));
        }
    }
}
