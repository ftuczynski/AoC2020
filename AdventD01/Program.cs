using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventD01 {
    class Program {
        static void Main(string[] args) {
            var data = new HashSet<int>();
            try {
                using (var sr = new StreamReader("data.txt")) {
                    while (!sr.EndOfStream) {
                        data.Add(int.Parse(sr.ReadLine()));
                    }
                }

                // PART 1
                foreach (int a in data) {
                    int b = 2020 - a;
                    if (data.Except(new[] {a}).Contains(b)) {
                        Console.WriteLine(a * b);
                        break;
                    }
                }

                // PART 2
                bool found = false;
                foreach (int i in data) {
                    int a = 2020 - i;
                    foreach (int j in data.Except(new[] {i})) {
                        int b = a - j;
                        if (data.Except(new[] {i,j}).Contains(b)) {
                            Console.WriteLine(i * j * b);
                            found = true;
                            break;
                        }
                    }
                    if (found) {
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
