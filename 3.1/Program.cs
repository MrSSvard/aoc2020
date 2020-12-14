using System;
using System.Collections.Generic;
using System.IO;

namespace _3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] map = File.ReadAllLines("input/input.txt");
            var mapWidth = map[0].Length;

            var treeCount = 0;
            for (var row = 0; row < map.Length; row++)
            {
                var column = (row * 3) % mapWidth;
                if (map[row][column] == '#')
                {
                    treeCount++;
                }
            }
            Console.Write(treeCount);
        }
    }
}
