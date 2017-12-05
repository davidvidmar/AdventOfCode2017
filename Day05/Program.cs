using System;
using System.Linq;
using System.IO;

namespace Day05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code 2017 - Day 4\n\nPart 1\n");

            var input = new[] { 0, 3, 0, 1, -3 };
            var result = DoJumps1(input);
            Console.WriteLine($"Result: {result}");

            var bigInput = File.ReadAllLines("input.txt");
            var bigIntInput = bigInput.Select(s => int.Parse(s)).ToArray();
            result = DoJumps1(bigIntInput);
            Console.WriteLine($"Result: {result}");

            Console.WriteLine("\nPart 2\n");

            input = new[] { 0, 3, 0, 1, -3 };
            result = DoJumps2(input);
            Console.WriteLine($"Result: {result}");

            bigIntInput = bigInput.Select(s => int.Parse(s)).ToArray();
            result = DoJumps2(bigIntInput);
            Console.WriteLine($"Result: {result}");

        }

        public static int DoJumps1(int[] input)
        {
            var index = 0;
            var jumps = 0;
            while (index >= 0 && index < input.Length)
            {
                var oldIndex = index;
                var step = input[index];
                index += step;
                input[oldIndex]++;
                jumps++;
                //Console.WriteLine($"index: {index}, jumps: {jumps}, list: {string.Join(" ", input)}");
            }
            return jumps;
        }

        public static int DoJumps2(int[] input)
        {
            var index = 0;
            var jumps = 0;
            while (index >= 0 && index < input.Length)
            {
                var oldIndex = index;
                var step = input[index];
                index += step;
                if (step >= 3)
                    input[oldIndex]--;
                else
                    input[oldIndex]++;
                jumps++;
                //Console.WriteLine($"index: {index}, jumps: {jumps}, list: {string.Join(" ", input)}");
            }
            return jumps;
        }
    }
}
