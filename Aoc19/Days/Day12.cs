using System;
using System.Collections.Generic;
namespace Aoc19.Days
{
    public class Planet
    {
        public Planet(int t_X, int t_Y, int t_Z)
        {
            x = t_X;
            y = t_Y;
            z = t_Z;
        }

        public void move()
        {
            x += velX;
            y += velY;
            z += velZ;
        }
        public int x;
        public int y;
        public int z;
        public int velX = 0;
        public int velY = 0;
        public int velZ = 0;
    }
    public class Day12
    {
        public static void BothParts() // Puzzle input goes into program arguments
        {
            var totalenergy = 0;
            var planets = new List<Planet>();
            var Io = new Planet(1, -4, 3);
            var Europa = new Planet(-14, 9, -4);
            var Ganymede = new Planet(-4, -6, 7);
            var Callisto = new Planet(6, -9, -11);
            int[] IoStart = {1, -4, 3};
            int[] EuropaStart = {-14, 9, -4};
            int[] GanymedeStart = {-4, -6, 7};
            int[] CallistoStart = {6, -9, -11};
            var planetStarts = new List<int[]> {IoStart, EuropaStart, GanymedeStart, CallistoStart};
            planets.Add(Io);
            planets.Add(Europa);
            planets.Add(Ganymede);
            planets.Add(Callisto);
            var intervals = new int[3];


            for (int timestep = 0; timestep < 1000000; ++timestep)
            {
                for (int x = 0; x < planets.Count; ++x)
                {
                    for (int y = x + 1; y < planets.Count; ++y)
                    {
                        if (planets[x].x > planets[y].x)
                        {
                            planets[x].velX--;
                            planets[y].velX++;
                        }
                        else if (planets[x].x < planets[y].x)
                        {
                            planets[x].velX++;
                            planets[y].velX--;
                        }

                        if (planets[x].y > planets[y].y)
                        {
                            planets[x].velY--;
                            planets[y].velY++;
                        }
                        else if (planets[x].y < planets[y].y)
                        {
                            planets[x].velY++;
                            planets[y].velY--;
                        }

                        if (planets[x].z > planets[y].z)
                        {
                            planets[x].velZ--;
                            planets[y].velZ++;
                        }
                        else if (planets[x].z < planets[y].z)
                        {
                            planets[x].velZ++;
                            planets[y].velZ--;
                        }
                    }
                    // Solve for X
                    if (timestep != 0 && planets[0].x == planetStarts[0][0] && planets[1].x == planetStarts[1][0] && planets[2].x == planetStarts[2][0] && planets[3].x == planetStarts[3][0])
                    {
                        if(intervals[0] == 0)
                            intervals[0] = timestep+1;
                    }
                    // Solve for Y
                    if (timestep != 0 && planets[0].y == planetStarts[0][1] && planets[1].y == planetStarts[1][1] && planets[2].y == planetStarts[2][1] && planets[3].y == planetStarts[3][1])
                    {
                        if(intervals[1] == 0)
                            intervals[1] = timestep+1;
                    }
                    // Solve for Z
                    if (timestep != 0 && planets[0].z == planetStarts[0][2] && planets[1].z == planetStarts[1][2] && planets[2].z == planetStarts[2][2] && planets[3].z == planetStarts[3][2])
                    {
                        if(intervals[2] == 0)
                            intervals[2] = timestep+1;
                    }
                }
                foreach (var planet in planets)
                {
                    planet.move();
                }

                if (timestep == 999)
                {
                    foreach (var planet in planets)
                    {
                        totalenergy += (Math.Abs(planet.x) + Math.Abs(planet.y) + Math.Abs(planet.z)) *
                                       (Math.Abs(planet.velX) + Math.Abs(planet.velY) + Math.Abs(planet.velZ));
                    }
                }
            }
            Console.WriteLine("Part 1: " + totalenergy + " Part 2 : " + intervals[0] + " " + intervals[1] + " " + intervals[2] + " Just find the lcm of those numbers");
        }
    }
} 