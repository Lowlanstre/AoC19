using System;
using System.Collections.Generic;

namespace Aoc19.Days
{
    public class Day8
    {
        public static void BothParts(string[] args)
        {
            var input = Array.ConvertAll(args[0].ToCharArray(), c => (int)Char.GetNumericValue(c));
            const int width = 25;
            const int height = 6;
            var zeroCount = 0;
            var oneCount = 0;
            var twoCount = 0;
            var wantedLayer = new Tuple<int, int,int,int>(0,int.MaxValue,0,0);
            var layers = new List<List<int>>();
            var finalPicture = new List<int>();
            for (var layer = 0; layer < input.Length/(width*height); ++layer)
            {
                var currentLayer = new List<int>();
                for (var pixel = 0; pixel < width * height; ++pixel)
                {
                    currentLayer.Add(input[(layer*height*width)+pixel]);
                    switch (input[(layer * height * width) + pixel])
                        {
                            case 0:
                                zeroCount++;
                                break;
                            case 1:
                                oneCount++;
                                break;
                            case 2:
                                twoCount++;
                                break;
                        }
                }
                layers.Add(currentLayer);
                if (zeroCount < wantedLayer.Item2)
                {
                    wantedLayer = new Tuple<int, int,int,int>(layer,zeroCount,oneCount,twoCount);
                }
                zeroCount = 0;
                oneCount = 0;
                twoCount = 0;
            }
            for (var pixel = 0; pixel < width * height; ++pixel)
            {
                foreach (var layer in layers)
                {
                    if (layer[pixel] == 0)
                    {
                        finalPicture.Add(0);
                        break;
                    }
                    if (layer[pixel] == 1)
                    {
                        finalPicture.Add(1);
                        break;
                    }
                }
            }
            Console.WriteLine("Part 1 solution is: " + (wantedLayer.Item3*wantedLayer.Item4));
            for (int i = 0; i < height; ++i)
            {
               Console.WriteLine();
                for (int wideN = 0; wideN < width; ++wideN)
                {
                    switch (finalPicture[(i * width) + wideN])
                    {
                        case 0:
                            
                            Console.Write("▒");
                            break;
                        case 1:
                            Console.Write("█");
                            break;
                        case 2:
                            break;
                    }
                }
            }
        }
    }
}