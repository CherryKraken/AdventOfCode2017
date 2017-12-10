using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public class Day3 : AocBase
    {
        readonly int _target1;

        public Day3() : base(@"day3.txt")
        {
            _target1 = int.Parse(inputString);
        }

        public override string Solve()
        {
            const int rowcol = 601; // max value is 360,000
            int[,] array = new int[rowcol, rowcol];
            int cstart = rowcol / 2;
            int rstart = rowcol / 2;
            int cend = cstart + 1;
            int rend = rstart + 1;
            array[rstart, cstart] = 1;
            int count = 2;

            string result = $"error";

            try
            {
                while (true)
                {
                    for (int i = cstart + 1; i <= cend; i++, count++)
                    {
                        array[rstart, i] = count;
                    }
                    cstart--;
                    if (count >= rowcol * rowcol) break;

                    for (int i = rstart + 1; i <= rend; i++, count++)
                    {
                        array[i, cend] = count;
                    }
                    rstart--;
                    if (count >= rowcol * rowcol) break;

                    for (int i = cend - 1; i >= cstart; i--, count++)
                    {
                        array[rend, i] = count;
                    }
                    cend++;
                    if (count >= rowcol * rowcol) break;

                    for (int i = rend - 1; i >= rstart; i--, count++)
                    {
                        array[i, cstart] = count;
                    }
                    rend++;
                    if (count >= rowcol * rowcol) break;
                }
            }
            catch (Exception e)
            {

            }


            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == _target1)
                    {
                        return "" + (Math.Abs(rstart - i) - Math.Abs(cstart - j));
                    }
                }
            }

            return result;
        }

        public override string Solve2()
        {
            const int rowcol = 601; // max value is 360,000
            int[,] array = new int[rowcol, rowcol];
            int cstart = rowcol / 2;
            int rstart = rowcol / 2;
            int cend = cstart + 1;
            int rend = rstart + 1;
            array[rstart, cstart] = 1;

            string result = $"error";

            try
            {
                while (true)
                {
                    for (int i = cstart + 1; i <= cend; i++)
                    {
                        array[rstart, i] = SumSurroundings(array, rstart, i);
                    if (array[rstart, i] > _target1)
                            return array[rstart, i] + "";
                    }
                    cstart--;

                    for (int i = rstart + 1; i <= rend; i++)
                    {
                        array[i, cend] = SumSurroundings(array, i, cend);
                        if (array[i, cend] > _target1)
                            return array[i, cend] + "";
                    }
                    rstart--;

                    for (int i = cend - 1; i >= cstart; i--)
                    {
                        array[rend, i] = SumSurroundings(array, rend, i);
                        if (array[rend, i] > _target1)
                            return array[rend, i] + "";
                    }
                    cend++;

                    for (int i = rend - 1; i >= rstart; i--)
                    {
                        array[i, cstart] = SumSurroundings(array, i, cstart);
                        if (array[i, cstart] > _target1)
                            return array[i, cstart] + "";
                    }
                    rend++;
                }
            }
            catch (IndexOutOfRangeException e)
            {

            }

            return result;
        }

        private int SumSurroundings(int[,] array, int i, int j)
        {
            int sum = 0;

            // Left
            if (j != 0)
            {
                sum += array[i, j - 1];
            }

            // Upper left
            if (i != 0 && j != 0)
            {
                sum += array[i - 1, j - 1];
            }

            // Above
            if (i != 0)
            {
                sum += array[i - 1, j];
            }

            // Upper right
            if (i != 0 && j != array.GetLength(1) - 1)
            {
                sum += array[i - 1, j + 1];
            }

            // Right
            if (j != array.GetLength(1) - 1)
            {
                sum += array[i, j + 1];
            }

            // Lower right
            if (i != array.GetLength(0) - 1 && j != array.GetLength(1) - 1)
            {
                sum += array[i + 1, j + 1];
            }

            // Below
            if (i != array.GetLength(0) - 1)
            {
                sum += array[i + 1, j];
            }

            // Lower left
            if (i != array.GetLength(0) - 1 && j != 0)
            {
                sum += array[i + 1, j - 1];
            }

            return sum;
        }
    }
}
