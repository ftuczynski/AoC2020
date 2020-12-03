using System;
using System.IO;

namespace AdventD03 {
    class Program {
        static void Main(string[] args) {
            try {
                var input = File.ReadAllLines("input.txt");
                var slop = new Slope(input);

                // PART 1
                Console.WriteLine("Part 1: " + slop.DownSlope(1, 3));

                // PART 2
                int[,] slopes = { { 1, 1 }, { 1, 3 }, { 1, 5 }, { 1, 7 }, { 2, 1 } };
                double ans = 1;
                for (int i = 0; i < slopes.GetLength(0); i++)
                    ans *= slop.DownSlope(slopes[i, 0], slopes[i, 1]);
                Console.WriteLine("Part 2: " + ans);
            }
            catch (IOException e) {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
            
        }
    }
}
