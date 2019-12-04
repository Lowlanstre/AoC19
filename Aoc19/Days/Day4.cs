using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Aoc19.Days
{
    public class Day4
    {
        public static int Part1(string[] input)
        {
            string[] range = Regex.Replace(input[0], "-", " ").Split(' ');
            int counter = 0;
            for (int number = Convert.ToInt32(range[0]); number < Convert.ToInt32(range[1]); ++number)
            {
                bool increasing = true;
                string str = Convert.ToString(number);
                for (int i = 0; i < 5; ++i)
                {
                    if (str[i] > str[i + 1])
                    {
                        increasing = false;
                        break;
                    }
                }
                if (increasing)
                {
                    for (int i = 0; i < 5; ++i)
                    {
                        if (str[i] == str[i + 1])
                        {
                            ++counter;
                            break;
                        }
                    }
                }
            }
            return counter;
        }

        public static int Part2(string[] input)
        {
            string[] range = Regex.Replace(input[0], "-", " ").Split(' ');
            int counter = 0;
            for (int number = Convert.ToInt32(range[0]); number < Convert.ToInt32(range[1]); ++number)
            {
                bool increasing = true;
                string str = Convert.ToString(number);
                for (int i = 0; i < 5; ++i)
                {
                    if (str[i] > str[i + 1])
                    {
                        increasing = false;
                        break;
                    }
                }

                if (increasing)
                {
                    for (int i = 0; i < 5; ++i)
                    {
                        if (str[i] == str[i + 1])
                        {
                            if (i - 1 >= 0 && str[i - 1] == str[i])
                                break;
                            if (i + 2 < 6 && str[i] == str[i + 2])
                            {
                                if (i + 4 < 6 && str[i + 3] == str[i + 4] && str[i + 4] != str[i + 2] ||
                                    i == 0 && str[i + 4] == str[i + 5] && str[i + 4] != str[i + 2])
                                {
                                    if (i == 0 && str[i + 3] == str[i + 5])
                                    {
                                        break;
                                    }
                                    ++counter;
                                }
                            }
                            else
                                ++counter;
                            break;
                        }
                    }
                }
            }
            return counter;
        }
    }
}