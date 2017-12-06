using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Day06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code 2017 - Day 6\n\nPart 1\n");

            var input = "0\t2\t7\t0";
            var result = CountCycles(input);
            
            input = File.ReadAllText("input.txt");
            result = CountCycles(input, false);
            
        }

        private static int CountCycles(string input, bool debug = true)
        {
            var banks = input.Split('\t').Select(st => int.Parse(st)).ToArray();
            var history = new List<string>();            
            int count = 0;
            string s = null;
            while (!history.Contains(s))
            {
                if (debug) Console.WriteLine($"State #{count}: {s ?? input.Replace("\t", " ")}");
                history.Add(s);

                banks = Reallocate(banks);
                s = string.Join(" ", banks);

                count++;
            }
            Console.WriteLine($"Duplicate state at #{history.IndexOf(s)}: {string.Join(" ", banks)}");
            Console.WriteLine($"\nResult (Part 1): {count}");
            Console.WriteLine($"Result (Part 2): {count - history.IndexOf(s)}\n");            
            return count;
        }

        private static int[] Reallocate(int[] banks)
        {
            var biggest = GetBiggestIndex(banks);

            var target = biggest+1;
            var value = banks[biggest];
            banks[biggest] = 0;                        

            while (value > 0)
            {
                if (target > banks.Length - 1) target = 0;
                banks[target]++;
                target++;
                value--;                
            }
            return banks;
        }

        private static int GetBiggestIndex(int[] banks)
        {
            var biggestValue = 0;
            var biggestIndex = -1;
            for (int i = 0; i < banks.Length; i++)
            {
                if (banks[i] > biggestValue)
                {
                    biggestValue = banks[i];
                    biggestIndex = i;
                }
            }
            return biggestIndex;
        }
    }
}
