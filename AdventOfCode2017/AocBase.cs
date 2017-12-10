using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2017
{
    public abstract class AocBase
    {
        protected readonly string inputString;

        protected AocBase(string path)
        {
            inputString = File.ReadAllText(@"..\..\" + path); ;
        }

        public abstract string Solve();
        public abstract string Solve2();
    }
}
