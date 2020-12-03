using System.Collections.Generic;

namespace AdventD03 {
    class Slope {
        public List<char[]> map { get; }

        public Slope(string[] input) {
            map = new List<char[]>();
            for(int i = 0; i < input.Length; i++) {
                map.Add(input[i].ToCharArray());
            }
        }

        public int DownSlope(int down, int right) {
            int treeCounter = 0;
            int j = 0;
            for(int i = 0; i < map.Count; i+=down) {
                if (map[i][j] == '#')
                    treeCounter++;
                j = (j + right) % map[i].Length;
            }
            return treeCounter;
        }
    }
}
