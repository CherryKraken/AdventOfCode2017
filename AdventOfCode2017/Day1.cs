using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public class Day1 : AocBase
    {
        public Day1() : base(@"day1.txt")
        {
        }

        public override string Solve()
        {
            char[] chars = inputString.ToCharArray();
            int sum = 0;

            for (int i = 0; i < chars.Length - 1; i++)
            {
                if (chars[i].Equals(chars[i+1]))
                {
                    sum += int.Parse(chars[i] + "");
                }
            }

            if (chars[0].Equals(chars[chars.Length - 1]))
            {
                sum += int.Parse(chars[0] + "");
            }

            return sum + "";
        }

        public override string Solve2()
        {
            char[] chars = inputString.ToCharArray();
            int sum = 0;

            for (int i = 0; i < chars.Length; i++)
            {
                int hemi = (i + (chars.Length / 2)) % chars.Length;
                if (chars[i].Equals(chars[hemi]))
                {
                    sum += int.Parse(chars[i] + "");
                }
            }

            return sum + "";
        }
    }
}
