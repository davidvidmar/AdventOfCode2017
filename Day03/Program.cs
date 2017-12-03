using System;

namespace Day03
{
    class Program
    {
        static int input = 312051;

        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code 2017 - Day 3\n\nPart 1\n");

            var input = 312051;

            CalcPart1(1);
            CalcPart1(12);
            CalcPart1(23);
            CalcPart1(1024);

            CalcPart1(input);

            Console.WriteLine("\nPart 2\n");

            var grid = GetGrid(50);
            grid = FillGrid(grid, input);
            PrintGrid(grid);
        }

        static void CalcPart1(int input)
        {
            Console.WriteLine($"Input: {input}");
            var l = (int)Math.Ceiling(Math.Sqrt(input));
            if (l % 2 == 0) l++;
            Console.WriteLine($"Grid size: {l}x{l}");
            Console.WriteLine($"Bottom right: {l*l}");

            var a = l*l;
            var center = l / 2 + 1;
            
            var x = l;
            var y = l;

            var dir = 0; // 0 = left; 1 = up; 2 = right; 3 = down

            while (a > input)
            {
                // Console.WriteLine($"a:{a}, d:{d}, x:{x}, y:{y}");

                a--;                
                if (dir == 0) // go left
                {
                    x--;
                    if (x == 1) dir++; // go up
                } else
                if (dir == 1) // go up
                {
                    y--;
                    if (y == 1) dir++; // do right
                } else
                if (dir == 2) // go right
                {
                    x++;
                    if (x == l) dir++; // do down
                } else
                if (dir == 3)
                {
                    y++;
                    if (y == l) dir = 0; // go left
                }
            }
            Console.WriteLine($"x = {x}, y = {y}");
            Console.WriteLine($"To center: {Math.Abs(x - center)} + {Math.Abs(y - center)} = {Math.Abs(x - center) + Math.Abs(y - center)}");
            Console.WriteLine();            
        }

        static int[,] GetGrid(int gridsize)
        {            
            var l = (int)Math.Ceiling(Math.Sqrt(gridsize));
            if (l % 2 == 0) l++;
            Console.WriteLine($"Grid size: {l}x{l}");
            return new int[l, l];
        }

        private static int[,] FillGrid(int[,] grid, int input)
        {
            int l = grid.GetUpperBound(0);
            int center = l / 2; // center square;

            var g = grid;
            
            g[center, center] = 1;

            int x = center;
            int y = center;            

            for (int circle = 1; circle <= center; circle++)
            {
                var a = 0;
                var dir = 2; // 0 = left; 1 = up; 2 = right; 3 = down
                var cc = (circle * 2 + 1);
                while (a < (cc * 2 + (cc - 2) * 2))
                {
                    a++;

                    if (dir == 0) // go left
                    {
                        x--;
                        if (Math.Abs(center - x) == circle) dir = 3; // go down
                    }
                    else
                    if (dir == 1) // go up
                    {
                        y--;
                        if (Math.Abs(center - y) == circle) dir--; // go left
                    }
                    else
                    if (dir == 2) // go right
                    {
                        x++;
                        if (Math.Abs(center - x) == circle) dir--; // go up
                    }
                    else
                    if (dir == 3) // go down
                    {
                        y++;
                        if (Math.Abs(center - y) == circle) dir--; // go right
                    }

                    var sum = SumN(grid, x, y);
                    g[x, y] = sum;

                    if (sum > input)
                    {
                        Console.WriteLine($"Hurray! {sum} is bigger than {input}\n");                        
                        return g;
                    }

                }
            }

            return g;
        }

        private static int SumN(int[,] grid, int x, int y)
        {
            return 
                SafeGet(grid, x - 1, y - 1) + SafeGet(grid, x, y - 1) + SafeGet(grid, x + 1, y - 1) +
                SafeGet(grid, x - 1, y) + SafeGet(grid, x + 1, y) +
                SafeGet(grid, x - 1, y + 1) + SafeGet(grid, x, y + 1) + SafeGet(grid, x + 1, y + 1);
        }

        private static int SafeGet(int[,] grid, int x, int y)
        {
            if (x < 0 || y < 0) return 0;
            if (x > grid.GetUpperBound(0) || y > grid.GetUpperBound(0)) return 0;
            return grid[x, y];
        }

        static void PrintGrid(int[,] grid)
        {
            for (int i = 0; i <= grid.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= grid.GetUpperBound(0); j++)
                {
                    Console.Write(grid[j, i].ToString().PadLeft(9));
                }
                Console.WriteLine();
            }
        }
    }
}
