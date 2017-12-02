using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code 2017 - Day 1\n\nPart 1\n");

        var input = File.ReadAllText("input.txt");

        SolveCaptcha("1122", 3);
        SolveCaptcha("1111", 4);
        SolveCaptcha("1234", 0);
        SolveCaptcha("91212129", 9);
                
        SolveCaptcha(input);

        Console.WriteLine("\nPart 2\n");

        SolveCaptcha2("1212", 6);
        SolveCaptcha2("1221", 0);
        SolveCaptcha2("123425", 4);
        SolveCaptcha2("123123", 12);
        SolveCaptcha2("12131415", 4);

        SolveCaptcha2(input);
    }

    private static void SolveCaptcha(string input, int? solution = null)
    {
        var result = 0;
        var num = 0;

        var input2 = input + input;

        int i = 0;
        while (i < input.Length)
        {
            if (input[i] == input2[i + 1])
            {
                num = Int32.Parse(input[i].ToString());
                Console.Write(num + "+");
                result += num;
            }                
            i++;
        }
                    
        Console.Write($"\nResult: {result}");

        if (solution != null) 
            Console.Write(result == solution ? " - CORRECT!" : $"NOPE! Should be {solution}");

        Console.WriteLine("\n");
    }
    
    private static void SolveCaptcha2(string input, int? solution = null)
    {
        var result = 0;
        var num = 0;

        var input2 = input + input;

        int i = 0;
        while (i < input.Length)
        {
            if (input[i] == input2[i + input.Length / 2])
            {
                num = Int32.Parse(input[i].ToString());
                Console.Write(num + "+");
                result += num;
            }
            i++;
        }

        Console.Write($"\nResult: {result}");
        
        if (solution != null)
            Console.Write(result == solution ? " - CORRECT!" : $" - NOPE! Should be {solution}");

        Console.WriteLine("\n");
    }

}