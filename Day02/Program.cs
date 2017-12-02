using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {        
        Console.WriteLine("Advent of Code 2017 - Day 2\n");

        CalcChecksum(new[] { "5\t1\t9\t5", "7\t5\t3", "2\t4\t6\t8" });

        var input = File.ReadAllLines("input.txt");
        CalcChecksum(input);
    }

    private static void CalcChecksum(string[] lines)
    {
        var result = 0;
        foreach (var line in lines)
        {            
            var nums = line.Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
            var min = Convert.ToInt32(nums[0]);
            var max = Convert.ToInt32(nums[0]);
            foreach (var num in nums)
            {
                var n = Convert.ToInt32(num);
                if (n < min) min = n;
                if (n > max) max = n;
            }
            var diff = max - min;
            Console.Write(diff + "+");
            result += max - min;
        }
        Console.WriteLine($"\n---\nResult: {result}\n");        
    }
}