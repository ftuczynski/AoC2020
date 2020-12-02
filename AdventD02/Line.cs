using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventD02 {
    class Line {
        private readonly char[] delimiterChars = { ' ','-',':' };
        public int FirstDigit { get; }
        public int SecondDigit { get; }
        public char Char { get; }
        public string Text { get; }

        public Line(string line) {
            string[] lines = line.Split(delimiterChars);
            FirstDigit = int.Parse(lines[0]);
            SecondDigit = int.Parse(lines[1]);
            Char = char.Parse(lines[2]);
            Text = lines[4];
        }

        public bool PartOneIsValid() {
            int count = Text.Length - Text.Replace(Char.ToString(), "").Length;
            if(count >= FirstDigit && count <= SecondDigit)
                return true;
            return false;
        }
        public bool PartTwoIsValid() {
            char[] text = Text.ToArray();
            if (text[FirstDigit - 1] == Char ^ text[SecondDigit - 1] == Char)
                return true;
            return false;
        }
    }
}
