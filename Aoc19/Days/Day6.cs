using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc19.Days
{
    public class Day6
    {
        public static int Part1(string[] args)
        {
            int answer = 0;
            bool HasParent = true;
            bool unique = true;
            List<string> unsorted = args.ToList();
            List<string> planets = new List<string>();
            List<Tuple<string,int>> orbitlist = new List<Tuple<string,int>>();
            for(int index = 0;index < unsorted.Count;++index)
            {
                HasParent = false;
                for(int j = 0; j < unsorted.Count;++j)
                {
                    if (unsorted[index].Substring(0,3) == unsorted[j].Substring(4,3) && index != j)
                    {
                        HasParent = true;
                        break;
                    }
                }
                Console.WriteLine(index);
                if (!HasParent)
                {
                    planets.Add(unsorted[index]);
                    unsorted.Remove(unsorted[index]);
                    index = -1;
                }
            }
            foreach (var planet in planets)
            {
                unique = true;
                foreach(var orbiter in orbitlist) 
                {
                    if (planet.Substring(0, 3) == orbiter.Item1)
                    {
                        unique = false;
                        break;
                    }
                }
                if (unique)
                {
                    orbitlist.Add(Tuple.Create(planet.Substring(0, 3), 0));
                }
                foreach (var orbiter in orbitlist)
                {
                    if (planet.Substring(0, 3) == orbiter.Item1)
                    {
                        orbitlist.Add(Tuple.Create(planet.Substring(4,3), orbiter.Item2+1));
                        break;
                    }
                }
            }
            foreach (var orbiter in orbitlist)
            {
                answer += orbiter.Item2;
            }

            return answer;
        }

        public static int Part2(string[] args)
        {
            int answer = 0;
            bool HasParent = true;
            bool unique = true;
            List<string> unsorted = args.ToList();
            List<string> planets = new List<string>();
            List<Tuple<string, int, List<string>>> orbitlist = new List<Tuple<string, int, List<string>>>();
            for (int index = 0; index < unsorted.Count; ++index)
            {
                HasParent = false;
                for (int j = 0; j < unsorted.Count; ++j)
                {
                    if (unsorted[index].Substring(0, 3) == unsorted[j].Substring(4, 3) && index != j)
                    {
                        HasParent = true;
                        break;
                    }
                }

                Console.WriteLine("Remaining size of sort:" + unsorted.Count);
                if (!HasParent)
                {
                    planets.Add(unsorted[index]);
                    unsorted.Remove(unsorted[index]);
                    index = -1;
                }
            }

            foreach (var planet in planets)
            {
                unique = true;
                foreach (var orbiter in orbitlist)
                {
                    if (planet.Substring(0, 3) == orbiter.Item1)
                    {
                        unique = false;
                        break;
                    }
                }

                if (unique)
                {
                    orbitlist.Add(Tuple.Create(planet.Substring(0, 3), 0, new List<string>()));
                    orbitlist[orbitlist.Count - 1].Item3.Add(planet.Substring(0, 3));
                }

                foreach (var orbiter in orbitlist)
                {
                    if (planet.Substring(0, 3) == orbiter.Item1)
                    {
                        orbitlist.Add(Tuple.Create(planet.Substring(4, 3), orbiter.Item2 + 1, orbiter.Item3.ToList()));
                        orbitlist[orbitlist.Count - 1].Item3.Add(planet.Substring(4, 3));
                        break;
                    }
                }
            }

            foreach (var orbiter in orbitlist)
            {
                answer += orbiter.Item2;
            }
            Console.WriteLine(answer);
            int closest = 0;
            foreach (var orbiter in orbitlist)
            {
                if (orbiter.Item1 == "YOU")
                {
                    Console.WriteLine("Your distance: " + orbiter.Item2);
                    foreach (var santa in orbitlist)
                    {
                        if (santa.Item1 == "SAN")
                        {
                            Console.WriteLine("Santa distance: " + santa.Item2);
                            foreach (var santastop in santa.Item3)
                            {
                                foreach (var youstop in orbiter.Item3)
                                {
                                    if (youstop == santastop)
                                    {
                                        foreach (var thingy in orbitlist)
                                        {
                                            if (thingy.Item1 == santastop)
                                            {
                                                if (thingy.Item2 > closest)
                                                {
                                                    closest = thingy.Item2;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            return orbiter.Item2 + santa.Item2 - (closest + 1) * 2;
                        }
                    }
                }
            }
            return 0;
        }
    }
}