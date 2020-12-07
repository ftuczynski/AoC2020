using System;
using System.IO;
using System.Linq;

namespace AdventD05 {
    class Program {
        private static int GetBinary(string line) {
            return Convert.ToInt32(line.Replace('F', '0')
                                       .Replace('B', '1')
                                       .Replace('L', '0')
                                       .Replace('R', '1'),2);
        }
        static void Main(string[] args) {
            try {
                var input = File.ReadAllLines("input.txt");
                // PART 1
                Console.WriteLine($"Part 1: {input.Max(x => GetBinary(x))}");

                // PART 2
                var seats = input.Select(x => GetBinary(x)).OrderBy(y => y).ToList();
                for(int i = 1; i < seats.Count; i++) {
                    if(seats[i] - seats[i - 1] != 1) {
                        Console.WriteLine($"Part 2: {seats[i] - 1}");
                        break;
                    }
                }
            }
            catch (IOException e) {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
