using System;
using System.Text.RegularExpressions;

namespace Aoc19.Days
{
    public class Day11
    {
        public enum Modes
        {
            Position,
            Immediate,
            Relative
        }
        public static void BothParts(string[] args, int colorCode) // Puzzle input goes into program arguments
        {
            args = Regex.Replace(args[0], ",", " ").Split(' ');
            long[] inputNumbers = Array.ConvertAll(args, long.Parse);
            Modes[] modes = {Modes.Position, Modes.Position, Modes.Position};
            long[] numIndex = {0, 0, 0};
            long relativeIndex = 0;
            long[]
                numbers = new long[10000]; // I estimated this value and 10 000 is more than enough, 1100 seems to suffice also
            int boundary;
            if (colorCode == 0)
            {
                boundary = 1000;
            }
            else
            {
                boundary = 100;
            }
            bool[,] ispainted = new bool[boundary,boundary];
            bool[,] panels = new bool[boundary, boundary];
            int paintcount = 0;
            int[,] grid = new int[boundary, boundary];
            int gridX = boundary / 2;
            int gridY = boundary / 2;
            int color = colorCode;
            int moveX = 1;
            int moveY = 0;
            bool isturn = false;
            bool moveVal = false;

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
                            numIndex[slot] = numbers[index + slot + 1] + relativeIndex;
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
                        numbers[numIndex[0]] = color;
                        index += 2;
                        moveVal = false;
                        break;
                    case '4':
                        if (!moveVal)
                        {
                            color = Convert.ToInt32(numbers[numIndex[0]]);
                            moveVal = true;
                        }
                        else
                        {
                            if (numbers[numIndex[0]] == 0)
                            {
                                if (moveX != 0)
                                {
                                    moveY = moveX;
                                    moveX = 0;
                                }
                                else
                                {
                                    moveX = moveY * -1;
                                    moveY = 0;
                                }
                            }
                            else
                            {
                                if (moveX != 0)
                                {
                                    moveY = moveX * -1;
                                    moveX = 0;
                                }
                                else
                                {
                                    moveX = moveY;
                                    moveY = 0;
                                }
                            }

                            moveVal = false;
                            isturn = true;
                        }

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

                if (isturn)
                {
                    if (!ispainted[gridX, gridY])
                    {
                        ispainted[gridX, gridY] = true;
                        ++paintcount;
                    }
                    
                    if (color == 0)
                    {
                        panels[gridX, gridY] = false;
                    }
                    else
                    {
                        panels[gridX, gridY] = true;
                    }

                    grid[gridX, gridY] = color;
                    gridX += moveX;
                    gridY += moveY;
                    color = grid[gridX, gridY];
                    isturn = false;
                }
            }

            if (boundary == 1000)
            {
                Console.WriteLine(paintcount);
            }
            else
            {
                for (int x = 0; x < boundary; ++x)
                {
                    for (int y = 0; y < boundary; ++y)
                    {
                        if (panels[99-x, 99-y] == false)
                        {
                            Console.Write("▒");
                        }
                        else
                        {
                            Console.Write("█");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}