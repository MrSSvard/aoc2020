using System;
using System.Collections.Generic;
using System.IO;
using System.Resources;

namespace _3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] map = File.ReadAllLines("input/input.txt");
            var mapWidth = map[0].Length;
            var paths = new List<Dictionary<string, int>>()
            {
                {
                    new Dictionary<string, int>() {
                        {"rowSpeed", 1},
                        {"columnSpeed", 1}
                    }
                },
                {
                    new Dictionary<string, int>() {
                        {"rowSpeed", 1},
                        {"columnSpeed", 3}
                    }
                },
                {
                    new Dictionary<string, int>() {
                        {"rowSpeed", 1},
                        {"columnSpeed", 5}
                    }
                },
                {
                    new Dictionary<string, int>() {
                        {"rowSpeed", 1},
                        {"columnSpeed", 7}
                    }
                },
                {
                    new Dictionary<string, int>() {
                        {"rowSpeed", 2},
                        {"columnSpeed", 1}
                    }
                }

            };

            long treeMultiplier = 1;

            foreach (Dictionary<string, int> path in paths)
            {
                long treeCount = 0;
                var steps = 0;
                for (var row = 0; row < map.Length; row += path["rowSpeed"], steps++)
                {
                    var column = (steps * path["columnSpeed"]) % mapWidth;
                    if (map[row][column] == '#')
                    {
                        treeCount++;
                    }
                }

                treeMultiplier *= treeCount;
            }
            Console.Write(treeMultiplier + "\n");
        }
    }
}
