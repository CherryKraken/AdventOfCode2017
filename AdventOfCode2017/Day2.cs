using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public class Day2 : AocBase
    {
        public Day2() : base(@"day2.txt")
        {
        }

        public override string Solve()
        {
            string[] lines = inputString.Split('\n');
            int sum = 0;

            foreach (string line in lines)
            {
                string[] vals = line.Split('\t');

                sum += (Max(vals) - Min(vals));
            }

            return sum + "";
        }

        public override string Solve2()
        {
            string[] lines = inputString.Split('\n');
            int sum = 0;

            foreach (string line in lines)
            {
                string[] vals = line.Split('\t');

                for(int i = 0; i < vals.Length; i++)
                {
                    for (int j = 0; j < vals.Length; j++)
                    {
                        if (i != j && int.Parse(vals[i]) % int.Parse(vals[j]) == 0)
                        {
                            sum += (int.Parse(vals[i]) / int.Parse(vals[j]));
                        }
                    }
                }
            }

            return sum + "";
        }

        private int Max(string[] arr)
        {
            int i = int.Parse(arr[0]);

            foreach (string s in arr)
            {
                if (int.Parse(s) > i)
                {
                    i = int.Parse(s);
                }
            }

            return i;
        }

        private int Min(string[] arr)
        {
            int i = int.Parse(arr[0]);

            foreach (string s in arr)
            {
                if (int.Parse(s) < i)
                {
                    i = int.Parse(s);
                }
            }

            return i;
        }
    }
}
