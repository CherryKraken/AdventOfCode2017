using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphAdjacencyList;
using Graph;

namespace AdventOfCode2017
{
    class Day7 : AocBase
    {
        DGraphAL<string> Tower { get; set; }

        public Day7() : base("day7.txt")
        {
            Tower = new DGraphAL<string>();
        }

        public override string Solve()
        {
            string[] lines = inputString.Split('\n');

            foreach (string line in lines)
            {
                string[] parts = line.Split(new string[] { " -> " }, StringSplitOptions.None);
                Tower.AddVertex(parts[0].Split()[0]);
            }

            foreach (string line in lines)
            {
                string[] parts = line.Split(new string[] { " -> " }, StringSplitOptions.None);
                if (parts.Length > 1)
                {
                    foreach (string s in parts[1].Split(new string[] { ", " }, StringSplitOptions.None))
                    {
                        Tower.AddEdge(parts[0].Split()[0], s.Trim());
                    }
                }
            }

            Dictionary<string, List<string>> lookup = new Dictionary<string, List<string>>();

            foreach (Vertex<string> v in Tower.EnumerateVertices())
            {
                List<Vertex<string>> list = Tower.EnumerateNeighbours(v.Data).ToList();

                if (list.Count == 0)
                    lookup.Add(v.Data, new List<string>());
                else
                    lookup.Add(v.Data, list.Select(l => l.Data).ToList());
            }

            return lookup.Select(m => m.Key).Except(lookup.SelectMany(n => n.Value)).First();
        }

        public override string Solve2()
        {
            throw new NotImplementedException();
        }
    }
}
