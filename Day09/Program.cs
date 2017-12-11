using System;
using System.IO;
using System.Text;

namespace Day09
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code 2017 - Day 9\n");
            var x = new X();
            x.Main();
        }
    }

    class X
    {

        public void Main()
        {
            ScoreGroup("{}", 1);
            ScoreGroup("{{{}}}", 6);
            ScoreGroup("{{},{}}", 5);
            ScoreGroup("{{{},{},{{}}}}", 16);
            ScoreGroup("{<a>,<a>,<a>,<a>}", 1);
            ScoreGroup("{{<ab>},{<ab>},{<ab>},{<ab>}}", 9);
            ScoreGroup("{{<!!>},{<!!>},{<!!>},{<!!>}}", 9);
            ScoreGroup("{{<a!>},{<a!>},{<a!>},{<ab>}}", 3);

            var input = File.ReadAllText("input.txt");
            ScoreGroup(input);
        }

        private void ScoreGroup(string group, int expected = 0)
        {
            Console.WriteLine($"Scoring group: {group.Substring(0, Math.Min(group.Length, 40))}");

            var s = ClearGarbage(group, 0);            

            var result = GetScore(s);
            Console.WriteLine($"Result: {result}" + ((result == expected) ? " OK!\n" : $", Expected = {expected}\n"));
        }

        private string ClearGarbage(string s, int start)
        {
            var inGarbage = false;
            var cancelNext = false;
            var garbageLen = 0;
            var sb = new StringBuilder();

            for (int i = start; i < s.Length; i++)
            {
                if (cancelNext)
                {
                    cancelNext = false;
                    continue;
                }

                if (s[i] == '!')
                {
                    cancelNext = true;
                    continue;
                }

                if (inGarbage)
                {
                    
                    if (s[i] == '>')
                    {
                        inGarbage = false;
                    }
                    else
                    {
                        garbageLen++;
                    }
                }
                else
                {
                    if (s[i] == '<')
                    {
                        inGarbage = true;
                    }
                    else
                    {
                        sb.Append(s[i]);
                    }
                }
            }
            Console.WriteLine("Garbage removed: " + garbageLen);
            return sb.ToString();
        }

        static int i = 0;

        int GetScore(string s)
        {
            var depth = 0;
            var score = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ',') continue;
                if (s[i] == '{') depth++;
                if (s[i] == '}')
                {
                    score += depth;
                    depth--;
                }
            }
            return score;
        }
    }
}
