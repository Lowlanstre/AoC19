using System;
using System.Text.RegularExpressions;

namespace Aoc19.Days
{
    public class Day5
    { 
        public static void BothParts(string[] args)
        {
            args = Regex.Replace(args[0], ",", " ").Split(' ');
            int[] numbers = Array.ConvertAll(args, int.Parse);
            bool[] modes = {true, true, true};
            int[] numIndex = {0, 0, 0};
            for (int index = 0; index < numbers.Length;)
            {
                modes[0] = true;
                modes[1] = true;
                modes[2] = true;
                string instruction = Convert.ToString(numbers[index]);
                int translator = 0;
                for (int pos = instruction.Length - 3; pos >= 0; pos--)
                {
                    if (instruction[pos] == '1')
                    {
                        modes[translator] = false;
                    }

                    ++translator;
                }

                if (instruction == "99")
                    break;
                numIndex[2] = numbers[index + 3];
                for (int slot = 0; slot < 2; ++slot)
                {
                    if (!modes[slot])
                    {
                        numIndex[slot] = index + slot + 1;
                    }
                    else
                    {
                        numIndex[slot] = numbers[index + slot + 1];
                    }
                }

                switch (instruction[instruction.Length - 1])
                {
                    case '1':
                        numbers[numIndex[2]] = numbers[numIndex[0]] + numbers[numIndex[1]];
                        index += 4;
                        break;
                    case '2':
                        numbers[numIndex[2]] = numbers[numIndex[0]] * numbers[numIndex[1]];
                        index += 4;
                        break;
                    case '3':
                        Console.WriteLine("Enter the prescribed number:");
                        numbers[numbers[index + 1]] = Convert.ToInt32(Console.ReadLine());
                        index += 2;
                        break;
                    case '4':
                        Console.WriteLine(numbers[numIndex[0]]);
                        index += 2;
                        break;
                    case '5':
                        if (numbers[numIndex[0]] != 0)
                        {
                            index = numbers[numIndex[1]];
                            break;
                        }
                        index += 3;
                        break;
                    case '6' :
                        if (numbers[numIndex[0]] == 0)
                        {
                            index = numbers[numIndex[1]];
                            break;
                        }
                        index += 3;
                        break;
                    case '7' :
                        if (numbers[numIndex[0]] < numbers[numIndex[1]])
                        {
                            numbers[numIndex[2]] = 1;
                        }
                        else
                        {
                            numbers[numIndex[2]] = 0;   
                        }
                        index += 4;
                        break;
                    case '8':
                        if (numbers[numIndex[0]] == numbers[numIndex[1]])
                        {
                            numbers[numIndex[2]] = 1;
                        }
                        else
                        {
                            numbers[numIndex[2]] = 0;
                        }
                        index += 4;
                        break;
                }
            }
        }
    }
}