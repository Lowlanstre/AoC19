using System;
using System.Text.RegularExpressions;
namespace Aoc19.Days
{
    public class Day2
    {
        public static long Part1(string[] stringIntegers)
        {
            stringIntegers = Regex.Replace(stringIntegers[0], ",", " ").Split(' ');
            int[] numbers = Array.ConvertAll(stringIntegers, int.Parse);
            numbers[1] = 12;
            numbers[2] = 2;
            for (var i = 0; i < numbers.Length; i += 4)
            {
                if (numbers[i] == 1)
                {
                    numbers[numbers[i + 3]] = numbers[numbers[i + 1]] + numbers[numbers[i + 2]];
                }
                else if (numbers[i] == 2)
                {
                    numbers[numbers[i + 3]] = numbers[numbers[i + 1]] * numbers[numbers[i + 2]];
                }
                else if (numbers[i] == 99)
                {
                    break;
                }
            }
            return numbers[0];
        }        
        public static long Part2(string[] stringIntegers)
        {
            var middleman = Regex.Replace(stringIntegers[0], ",", " ");
            stringIntegers = middleman.Split(' ');
            for (int a = 0; a < 100; ++a)
            {
                for (int b = 0; b < 100; ++b)
                {
                    int[] numbers = Array.ConvertAll(stringIntegers, int.Parse);
                    numbers[1] = a;
                    numbers[2] = b;
                    for (int i = 0; i < numbers.Length; i += 4)
                    {
                        if (numbers[i] == 1)
                        {
                            numbers[numbers[i + 3]] = numbers[numbers[i + 1]] + numbers[numbers[i + 2]];
                        }
                        else if (numbers[i] == 2)
                        {
                            numbers[numbers[i + 3]] = numbers[numbers[i + 1]] * numbers[numbers[i + 2]];
                        }
                        else if (numbers[i] == 99)
                        {
                            break;
                        }
                    }

                    if (numbers[0] == 19690720)
                    {
                        return 100 * a + b;
                    }
                }
            }
            return 0;
        }
    }
}