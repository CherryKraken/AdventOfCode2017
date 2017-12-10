using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    class Day5 : AocBase
    {
        public Day5() : base("day5.txt")
        {
        }

        public override string Solve()
        {
            int[] nums = inputString.Split('\n').Select(l => int.Parse(l)).ToArray();
            int index = 0, count = 0;

            while (index < nums.Length)
            {
                int i = nums[index];
                nums[index]++;
                index += i;
                count++;
            }
            
            return count + "";
        }

        public override string Solve2()
        {
            int[] nums = inputString.Split('\n').Select(l => int.Parse(l)).ToArray();
            int index = 0, count = 0;

            while (index < nums.Length)
            {
                int i = nums[index];
                nums[index] += ((nums[index] >= 3) ? -1 : 1);
                index += i;
                count++;
            }

            return count + "";
        }
    }
}
