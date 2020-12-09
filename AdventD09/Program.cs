using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventD09 {
    class Program {
        private const int preambleSize = 25;
        private static long Part1(List<long> input) {
            for (int r = preambleSize; r < input.Count; r++) {
                var preamble = input.Skip(r - preambleSize).Take(preambleSize).ToList();
                if (!preamble.Any(x => preamble.Any(y => x != y && x + y == input[r])))     //Doesn't work for repeating numbers
                    return input[r];
            }
            return 0;
        }
        private static long Part2(List<long> input) {
            long part1 = Part1(input);
            var i = 0;
            var size = 0;
            long sum = 0;

            while (true) {
                sum += input[i + size];
                if (sum == part1) {
                    var range = input.Skip(i).Take(size).ToList();
                    return range.Min() + range.Max();
                }
                else if (sum > part1) {
                    i++;
                    size = 0;
                    sum = 0;
                }
                else {
                    size++;
                }
            }
        }
        static void Main(string[] args) {
            try {
                var input = File.ReadAllLines("input.txt").Select(x => long.Parse(x)).ToList();

                // PART 1
                Console.WriteLine($"Part 1: {Part1(input)}");

                // PART 2
                Console.WriteLine($"Part 2: {Part2(input)}");

            }
            catch (IOException e) {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
