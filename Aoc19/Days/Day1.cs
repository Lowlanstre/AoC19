using System;

namespace Aoc19.Days

{
    public static class Day1
    {
        public static long Part1(string[] modules)
        {
            long totalFuel;
            totalFuel = 0;
            foreach (var module in modules)
            {
                var mass = Convert.ToInt64(module);
                mass = mass / 3 - 2;
                    totalFuel += mass;
            }
            return totalFuel;
        }
        public static long Part2(string[] modules)
        {
            long totalFuel;
            totalFuel = 0;
            foreach (var module in modules)
            {
                var mass = Convert.ToInt64(module);
                while (mass/3 - 2 > 0)
                {
                    mass = mass / 3 - 2;
                    totalFuel += mass;
                }
            }
            return totalFuel;
        }
    }
}