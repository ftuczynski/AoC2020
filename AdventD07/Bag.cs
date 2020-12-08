using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventD07 {
    class Bag {
        private static readonly Regex colorRegex = new Regex(@"[\w]+\s+[\w]+", RegexOptions.None);
        private static readonly Regex bagsRegex = new Regex(@"(\d+) ([\w]+\s+[\w]+)", RegexOptions.None);
        public string Name { get; }
        public IDictionary<string, int> Content { get; }

        public Bag(string line) {
            Name = colorRegex.Match(line).Value;
            Content = bagsRegex.Matches(line)
                .Cast<Match>()
                .ToDictionary(
                x => x.Groups[2].Value,
                x => int.Parse(x.Groups[1].Value)
                );
        }
        public bool ContainsBag(string name, List<Bag> bags) {
            return Content.Keys.Any(x => x.Equals(name) || GetBag(x, bags).ContainsBag(name, bags));
        }
        public static Bag GetBag(string key, List<Bag> bags) {
            return bags.First(x => x.Name.Equals(key));
        }
        public int HowManyBags(List<Bag> bags) {
            return Content.Sum(x => x.Value * (GetBag(x.Key, bags).HowManyBags(bags) + 1));
        }
    }
}
