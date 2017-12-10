using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    class Day4 : AocBase
    {
        public Day4() : base("day4.txt")
        {
        }

        public override string Solve()
        {
            string[] lines = inputString.Split('\n');
            int count = 0;

            foreach (string line in lines)
            {
                string[] words = line.Split();
                bool valid = true;

                foreach (string word in words)
                {
                    if (words.Count(w => w == word) > 1)
                    {
                        valid = false;
                    }
                }

                if (valid)
                {
                    count++;
                }
            }

            return count + "";
        }

        public override string Solve2()
        {
            string[] lines = inputString.Split('\n');
            int count = lines.Length;

            foreach (string line in lines)
            {
                string[] words = line.Split();
                var lookup = new HashSet<string>();

                foreach (string word in words)
                {
                    if (lookup.Contains(word) || SetHasAnagram(lookup, word))
                    {
                        count--;
                        break;
                    }
                    else
                        lookup.Add(word);
                }
            }

            return count + "";
        }

        private bool SetHasAnagram(HashSet<string> lookup, string word)
        {
            var a = (from l in word orderby l select l).ToList();

            foreach (string s in lookup)
            {
                var b = (from l in s orderby l select l).ToList();

                if (ListsMatch(a, b))
                {
                    return true;
                }
            }

            return false;
        }

        private bool ListsMatch(List<char> a, List<char> b)
        {
            if (a.Count != b.Count) return false;

            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
