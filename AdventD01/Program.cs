using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventD01 {
    class Program {
        static void Main(string[] args) {
            List<int> data = new List<int>();
            try {
                using (var sr = new StreamReader("data.txt")) {
                    while (!sr.EndOfStream) {
                        data.Add(Convert.ToInt32(sr.ReadLine()));
                    }
                }
                // PART 1
                for (int i = 0; i < data.Count; i++) {
                    for (int j = i + 1; j < data.Count; j++) {
                        if (data[i] + data[j] == 2020) {
                            Console.WriteLine(data[i] * data[j]);
                        }
                    }
                }
                // PART 2
                for (int i = 0; i < data.Count; i++) {
                    for (int j = i + 1; j < data.Count; j++) {
                        for (int k = j + 1; k < data.Count; k++) {
                            if (data[i] + data[j] + data[k] == 2020) {
                                Console.WriteLine(data[i] * data[j] * data[k]);
                            }
                        }
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
