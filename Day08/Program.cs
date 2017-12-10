using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day08
{
    class Program
    {
        static Dictionary<string, int> v = new Dictionary<string, int>();
        static int highestValue = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code 2017 - Day 6\n");

            var testinput = new[] {
                "b inc 5 if a > 1",
                "a inc 1 if b < 5",
                "c dec -10 if a >= 1",
                "c inc -20 if c == 10"
                };

            var testresult = ProcessInstructions(testinput);
            Console.WriteLine($"Highest register value: {testresult}");
            Console.WriteLine($"Highest value ever: {highestValue}\n");

            v.Clear();
            highestValue = 0;

            var input = File.ReadAllLines("input.txt");
            var result = ProcessInstructions(input);
            Console.WriteLine($"Highest register value: {result}");
            Console.WriteLine($"Highest value ever: {highestValue}\n");            
        }

        private static int ProcessInstructions(string[] input)
        {
            foreach (var line in input)
            {
                var s = line.Split(' ');

                var reg = s[0];                
                var op = s[1];
                var val = Int32.Parse(s[2]);
                var c_reg = s[4];
                var c_op = s[5];
                var c_val = Int32.Parse(s[6]);

                if (!v.ContainsKey(reg)) v.Add(reg, 0);
                if (!v.ContainsKey(c_reg)) v.Add(c_reg, 0);

                if (ConditionTrue(c_reg, c_op, c_val))
                    SetRegister(reg, op, val);

                if (v[reg] > highestValue)
                    highestValue = v[reg];
            }

            return v.Max(k => k.Value);
        }

        private static bool ConditionTrue(string reg, string op, int val)
        {
            if (op == "==") return v[reg] == val;
            if (op == "!=") return v[reg] != val;
            if (op == "<") return v[reg] < val;
            if (op == "<=") return v[reg] <= val;
            if (op == ">") return v[reg] > val;
            if (op == ">=") return v[reg] >= val;
            throw new InvalidOperationException($"Comparison operator {op} not supported.");
        }

        private static void SetRegister(string reg, string op, int val)
        {
            if (op == "inc")
                v[reg] += val;
            else if (op == "dec")
                v[reg] -= val;
            else
                throw new InvalidOperationException($"Operator {op} not supported.");
        }
    }
}
