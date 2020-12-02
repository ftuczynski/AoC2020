﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventD02 {
    class Program {
        static void Main(string[] args) {
            try {
                var data = new List<string>();
                using (var sr = new StreamReader("input.txt")) {
                    while (!sr.EndOfStream) {
                        data.Add(sr.ReadLine());
                    }
                }
                //PART 1
                int valid = 0;
                foreach(var a in data) {
                    var line = new Line(a);
                    if (line.IsValid())
                        valid++;
                }
                Console.WriteLine("PART 1: " + valid);
                //PART 2
            }
            catch (IOException e) {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
