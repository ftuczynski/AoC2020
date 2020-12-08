using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventD08 {
    class Program {
        private static int Part1(string[] input) {
            var acc = 0;
            var executed = new HashSet<int>();
            var i = 0;
            while (!executed.Contains(i)) {
                executed.Add(i);
                var op = input[i].Split(' ');
                switch (op[0]) {
                    case "acc":
                        acc += int.Parse(op[1]);
                        i++;
                        break;
                    case "jmp":
                        i += int.Parse(op[1]);
                        break;
                    case "nop":
                        i++;
                        break;
                }
            }
            return acc;
        }
        private static int Part2(string[] input) {
            var acc = 0;
            var i = 0;
            HashSet<int> executedIndex;
            var changedIndex = new HashSet<int>();

            while (i < input.Length) {
                var newInput = input.ToList();
                bool changed = false;
                i = 0;
                executedIndex = new HashSet<int>();
                acc = 0;

                while (executedIndex.Add(i) && i < newInput.Count) {
                    var op = newInput[i].Split(' ');
                    switch (op[0]) {
                        case "acc":
                            break;
                        case "jmp":
                            if (!changedIndex.Contains(i) && !changed) {
                                newInput[i] = newInput[i].Replace("jmp", "nop");
                                changedIndex.Add(i);
                                changed = true;
                            }
                            break;
                        case "nop":
                            if (!changedIndex.Contains(i) && !changed) {
                                newInput[i] = newInput[i].Replace("nop", "jmp");
                                changedIndex.Add(i);
                                changed = true;
                            }
                            break;
                    }
                    op = newInput[i].Split(' ');
                    switch (op[0]) {
                        case "acc":
                            acc += int.Parse(op[1]);
                            i++;
                            break;
                        case "jmp":
                            i += int.Parse(op[1]);
                            break;
                        case "nop":
                            i++;
                            break;
                    }
                }
            }
            return acc;
        }
        static void Main(string[] args) {
            try {
                var input = File.ReadAllLines("input.txt");

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
