using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code 2017 - Day 1\n");

        SolveCaptcha("1122");
        SolveCaptcha("1111");
        SolveCaptcha("1234");
        SolveCaptcha("91212129");

        var input = File.ReadAllText("input.txt");
        SolveCaptcha(input);
    }

    private static void SolveCaptcha(string input)
    {
        var result = 0;
        var num = 0;

        int i = 1;
        while (i < input.Length)
        {
            if (input[i] == input[i - 1])
            {
                num = Convert.ToInt32(input[i].ToString());
                Console.Write(num + "+");
                result += num;
            }                
            i++;
        }

        if (input[i - 1] == input[0])
        {
            num = Convert.ToInt32(input[i-1].ToString());
            Console.Write(num);
            result += num;
        }
            
        Console.WriteLine($"\n---\nResult: {result}\n");
    }                     
}