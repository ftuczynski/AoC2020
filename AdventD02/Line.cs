using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventD02 {
    class Line {
        private readonly char[] delimiterChars = { ' ','-',':' };
        public int MinLimit { get; }
        public int MaxLimit { get; }
        public char Char { get; }
        public string Text { get; }

        public Line(string line) {
            string[] lines = line.Split(delimiterChars);
            MinLimit = int.Parse(lines[0]);
            MaxLimit = int.Parse(lines[1]);
            Char = char.Parse(lines[2]);
            Text = lines[4];
        }

        public bool IsValid() {
            int count = Text.Length - Text.Replace(Char.ToString(), "").Length;
            if(count >= MinLimit && count <= MaxLimit) {
                return true;
            }
            return false;
        }
    }
}
