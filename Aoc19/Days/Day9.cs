using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Aoc19.Days
{
    public static class Day9
    {
        private enum Modes
        {
            Position,
            Immediate,
            Relative
        }
        public static void BothParts(string[] args) // Puzzle input goes into program arguments
        {
            args = Regex.Replace(args[0], ",", " ").Split(' ');
            var bonusMemory = new long[1000]; // I estimated this value and 1000 suffices for our purposes.
            var numbers = Array.ConvertAll(args, long.Parse).Concat(bonusMemory).ToArray();
            Modes[] modes = {Modes.Position, Modes.Position, Modes.Position};
            long[] numIndex = {0, 0, 0};
            long relativeIndex = 0;
            for (long index = 0; index < numbers.Length;)
            {
                modes[0] = Modes.Position;
                modes[1] = Modes.Position;
                modes[2] = Modes.Position;
                var instruction = Convert.ToString(numbers[index]);
                if (instruction == "99")
                    break;
                for (var pos = instruction.Length - 3; pos >= 0; pos--)
                {
                    switch (instruction[pos])
                    {
                        case '1':
                            modes[instruction.Length-3-pos] = Modes.Immediate;
                            break;
                        case '2':
                            modes[instruction.Length-3-pos] = Modes.Relative;
                            break;
                    }
                }
                for (var slot = 0; slot < 3; ++slot)
                {
                    switch (modes[slot])
                    {
                        case Modes.Relative:
                            numIndex[slot] = numbers[index + slot + 1] + relativeIndex;
                            break;
                        case Modes.Immediate:
                            numIndex[slot] = index + slot + 1;
                            break;
                        case Modes.Position:
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
                        index = numbers[numIndex[0]] != 0 ? numbers[numIndex[1]] : index + 3;
                        break;
                    case '6':
                        index = numbers[numIndex[0]] == 0 ? numbers[numIndex[1]] : index + 3;
                        break;
                    case '7':
                        numbers[numIndex[2]] = numbers[numIndex[0]] < numbers[numIndex[1]] ? 1 : 0;
                        index += 4;
                        break;
                    case '8':
                        numbers[numIndex[2]] = numbers[numIndex[0]] == numbers[numIndex[1]] ? 1 : 0;
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