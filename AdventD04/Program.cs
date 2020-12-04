using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventD04 {
    class Program {
        private static bool DoesPassportHaveAllFields(string passport) {
            var fields = new string[] { "byr:", "iyr:", "eyr:", "hgt:", "hcl:", "ecl:", "pid:" };
            return fields.All(x => passport.Contains(x));
        }
        private static bool IsDataValid(string passport) {
            var fields = new string[] { @"byr:(19[2-9][0-9]|200[0-2])",
                                        @"iyr:(201[0-9]|2020)",
                                        @"eyr:(202[0-9]|2030)",
                                        @"hgt:((1[5-8][0-9]|19[0-3])cm)|hgt:(7[0-6]|59|6[0-9])in",
                                        @"hcl:(#[0-9a-f]{6})",
                                        @"ecl:(amb|blu|brn|gry|grn|hzl|oth)",
                                        @"pid:(\d{9}\b)" };
            return fields.All(x => Regex.IsMatch(passport, x));
        }
        static void Main(string[] args) {
            try {
                var passports = File.ReadAllText("input.txt")
                    .Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None)
                    .Select(x => x.Replace(Environment.NewLine, " "));

                // PART 1
                int count1 = passports
                    .Where(x => DoesPassportHaveAllFields(x))
                    .Count();
                Console.WriteLine("Part 1:" + count1);

                // PART 2
                int count2 = passports
                    .Where(x => IsDataValid(x))
                    .Count();
                Console.WriteLine("Part 2:" + count2);
                

            }
            catch (IOException e) {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
