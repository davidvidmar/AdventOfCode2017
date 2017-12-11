using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code 2017 - Day 6\n");

            var input = @"pbga (66)
xhth (57)
ebii (61)
havc (66)
ktlj (57)
fwft (72) -> ktlj, cntj, xhth
qoyq (66)
padx (45) -> pbga, havc, qoyq
tknk (41) -> ugml, padx, fwft
jptl (61)
ugml (68) -> gyxo, ebii, jptl
gyxo (61)
cntj (57)".Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            var c = Part1(input);
            Part2(c);            

            input = File.ReadAllLines("input.txt");
            c = Part1(input);
            Part2(c);            
            
        }

        private static Container Part1(string[] input)
        {
            var c = new Container();            

            foreach (var s in input.OrderBy(i => i.Length))
            {
                var name = s.Substring(0, s.IndexOf('(') - 1);
                var weight = Int32.Parse(s.Substring(s.IndexOf('(') + 1, s.IndexOf(')') - s.IndexOf('(') - 1));
                var childNames = s.Contains("->") ? s.Substring(s.IndexOf('>') + 2) : null;

                c.Discs.Add(new Disc(name, weight, childNames));                               
            }

            foreach (var disc in c.Discs)
            {                
                disc.PopulateChildDiscs(c.Discs);                
            }
            
            Console.WriteLine($"Base disc: {c.GetBaseDisc().Name}\n");
            
            return c;

        }

        private static void Part2(Container c)
        {
            var disc = c.GetBaseDisc();

            while (!disc.IsBalanced())
            {
                disc = disc.GetUnbalancedDisc();
            }

            foreach (var d in disc.Parent.ChildDiscs)
            {
                Console.WriteLine($"Disc =  {d.Name}, Weight = {d.Weight}, Child Weight = {d.GetWeight()}");
            }

            Console.WriteLine();
        }

        private class Container
        {
            public List<Disc> Discs { get; set; }

            public Disc GetBaseDisc()
            {
                if (Discs.Count == 0) return null;
                var disc = Discs.First();
                while (disc.Parent != null)
                    disc = disc.Parent;
                return disc;
            }

            public Container()
            {
                Discs = new List<Disc>();
            }
        }

        private class Disc
        {
            public string Name { get; set; }
            public int Weight { get; set; }
            public List<Disc> ChildDiscs { get; set; }
            public string[] ChildNames { get; set; }
            public Disc Parent { get; set; }

            public Disc(string name, int weight, string childNames)
            {
                ChildDiscs = new List<Disc>();

                Name = name;
                Weight = weight;
                if (childNames != null)
                    ChildNames = childNames.Split(new[] { ", " }, StringSplitOptions.None);
            }

            public void PopulateChildDiscs(List<Disc> discs)
            {
                if (ChildNames == null) return;
                foreach (var discName in ChildNames)
                {
                    var childDisc = discs.First(d => d.Name == discName);
                    childDisc.Parent = this;
                    ChildDiscs.Add(childDisc);                    
                }
            }

            public int GetWeight()
            {
                return Weight + ChildDiscs.Sum(c => c.GetWeight());
            }

            public bool IsBalanced()
            {
                var r = ChildDiscs.GroupBy(d => d.GetWeight());
                return r.Count() == 1;
            }

            public Disc GetUnbalancedDisc()
            {
                var r = ChildDiscs.GroupBy(d => d.GetWeight());
                return r.First(g => g.Count() == 1).First();
            }
        }
    }
}
