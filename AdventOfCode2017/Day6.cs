using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    class Day6 : AocBase
    {
        public Day6() : base("day6.txt")
        {
        }

        public override string Solve()
        {
            List<int> nums = (from num in inputString.Split() select int.Parse(num)).ToList();
            int count = 0;
            List<List<int>> lookup = new List<List<int>>();

            while (!HasMatchingBlocks(nums, lookup))
            {
                lookup.Add(nums.ToList());
                int index = nums.IndexOf(nums.Max());
                int max = nums[index];
                nums[index] = 0;

                while (max != 0)
                {
                    index++;
                    if (index == nums.Count) index = 0;
                    nums[index] += 1;
                    max--;
                }

                count++;
            }

            return count + "";
        }

        private bool HasMatchingBlocks(List<int> needle, List<List<int>> haystack)
        {
            foreach (List<int> l in haystack)
            {
                if (needle.SequenceEqual(l))
                {
                    return true;
                }
            }

            return false;
        }

        public override string Solve2()
        {
            int firstSeq = int.Parse(Solve());
            List<int> nums = (from num in inputString.Split() select int.Parse(num)).ToList();
            int count = 0;
            List<List<int>> lookup = new List<List<int>>();

            while (lookup.Where(m => m.SequenceEqual(nums)).ToList().Count != 2)
            {
                lookup.Add(nums.ToList());
                int index = nums.IndexOf(nums.Max());
                int max = nums[index];
                nums[index] = 0;

                while (max != 0)
                {
                    index++;
                    if (index == nums.Count) index = 0;
                    nums[index] += 1;
                    max--;
                }

                count++;
            }

            return (count - firstSeq) + "";
        }
    }
}
