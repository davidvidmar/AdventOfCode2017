using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code 2017 - Day 2\n\nPart 1\n");

        var input = File.ReadAllLines("input.txt");

        CalcChecksum(new[] { "5\t1\t9\t5", "7\t5\t3", "2\t4\t6\t8" }, 18);
        CalcChecksum(input);

        Console.WriteLine("\nPart 2\n");

        CalcEvenDivide(new[] { "5\t9\t2\t8", "9\t4\t7\t3", "3\t8\t6\t5" }, 9);
        CalcEvenDivide(input);
    }

    private static void CalcChecksum(string[] lines, int? solution = null)
    {
        var result = 0;
        foreach (var line in lines)
        {            
            var nums = line.Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
            var min = Int32.Parse(nums[0]);
            var max = Int32.Parse(nums[0]);
            foreach (var num in nums)
            {
                var n = Int32.Parse(num);
                if (n < min) min = n;
                if (n > max) max = n;
            }
            var diff = max - min;
            Console.Write(diff + "+");
            result += max - min;
        }

        Console.Write($"\nResult: {result}");

        if (solution != null)
            Console.Write(result == solution ? " - CORRECT!" : $"NOPE! Should be {solution}");

        Console.WriteLine("\n");
    }

    private static void CalcEvenDivide(string[] lines, int? solution = null)
    {
        var result = 0;
        foreach (var line in lines)
        {
            var nums = line.Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i == j) continue;
                    var numi = Double.Parse(nums[i]);
                    var numj = Double.Parse(nums[j]);
                    if (numi / numj == (int)(numi / numj))
                    {
                        result += (int)(numi / numj);
                        break;  
                    }                    
                }
            }            
        }

        Console.Write($"Result: {result}");

        if (solution != null)
            Console.Write(result == solution ? " - CORRECT!" : $"NOPE! Should be {solution}");

        Console.WriteLine("\n");
    }
}