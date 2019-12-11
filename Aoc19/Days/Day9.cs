using System;
using System.Text.RegularExpressions;

namespace Aoc19.Days
{
    public class Day9
    {
        public enum Modes
        {
            Position,
            Immediate,
            Relative
        }
        public static void BothParts(string[] args) // Puzzle input goes into program arguments
        {
            args = Regex.Replace(args[0], ",", " ").Split(' ');
            long[] inputNumbers = Array.ConvertAll(args, long.Parse);
            Modes[] modes = {Modes.Position, Modes.Position, Modes.Position};
            long[] numIndex = {0, 0, 0};
            long relativeIndex = 0;
            long[] numbers = new long[10000]; // I estimated this value and 10 000 is more than enough, 1100 seems to suffice also
            for (int i = 0; i < inputNumbers.Length; ++i)
            {
                numbers[i] = inputNumbers[i];
            }

            for (long index = 0; index < numbers.Length;)
            {
                modes[0] = Modes.Position;
                modes[1] = Modes.Position;
                modes[2] = Modes.Position;
                string instruction = Convert.ToString(numbers[index]);
                int translator = 0;
                for (int pos = instruction.Length - 3; pos >= 0; pos--)
                {
                    if (instruction[pos] == '2')
                    {
                        modes[translator] = Modes.Relative;
                    }
                    else if (instruction[pos] == '1')
                    {
                        modes[translator] = Modes.Immediate;
                    }

                    ++translator;
                }

                if (instruction == "99")
                    break;

                if (modes[2] == Modes.Relative)
                {
                    numIndex[2] = numbers[index + 3] + relativeIndex;
                }
                else
                {
                    numIndex[2] = numbers[index + 3];
                }

            for (int slot = 0; slot < 2; ++slot)
            {
                switch (modes[slot])
                {
                    case Modes.Relative:
                        numIndex[slot] = numbers[index + slot + 1]+relativeIndex;
                        break;
                    case Modes.Immediate:
                        numIndex[slot] = index + slot + 1;
                        break;
                    default: // Modes.Position
                        numIndex[slot] = numbers[index + slot + 1];
                        break;
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
                        numbers[numIndex[0]] = Convert.ToInt32(Console.ReadLine());
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
                    case '6':
                        if (numbers[numIndex[0]] == 0)
                        {
                            index = numbers[numIndex[1]];
                            break;
                        }

                        index += 3;
                        break;
                    case '7':
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
                    case '9':
                        relativeIndex += numbers[numIndex[0]];
                        index += 2;
                        break;
                }
            }
        }
    }
}