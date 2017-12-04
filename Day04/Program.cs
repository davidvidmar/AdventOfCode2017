using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code 2017 - Day 4\n\nPart 1\n");

            var input = File.ReadAllLines("input.txt");
            
            Console.WriteLine($"Result part 1: {CountValidPasswordsPart1(input)}");
            Console.WriteLine($"Result part 2: {CountValidPasswordsPart2(input)}");
        }

        private static int CountValidPasswordsPart1(string[] input)
        {
            int i = 0;
            foreach (var phrase in input)
            {
                var words = phrase.Split(' ');
                if (words.Count() == words.Distinct().Count())
                {
                    i++;
                }
            }

            return i;
        }

        private static int CountValidPasswordsPart2(string[] input)
        {
            int i = 0;
            foreach (var phrase in input)
            {
                var words = phrase.Split(' ');
                var sortedWords = new List<string>();
                foreach (var word in words)
                {
                    sortedWords.Add(String.Concat(word.OrderBy(s => s)));
                }
                if (sortedWords.Count() == sortedWords.Distinct().Count())
                {
                    i++;
                }
            }

            return i;
        }
    }
}
