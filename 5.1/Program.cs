using System;
using System.IO;

namespace _5._1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream filestream = new FileStream("input/input.txt", FileMode.Open, FileAccess.Read);
            using (StreamReader reader = new StreamReader(filestream))
            {
                var highestID = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var rowString = line.Substring(0, 7);
                    var columnString = line.Substring(7);
                    int row = Helpers.RowParser(rowString);
                    int column = Helpers.ColumnParser(columnString);

                    var iD = 8 * row + column;
                    highestID = highestID < iD ? iD : highestID;
                }
                Console.WriteLine(highestID);
            }
        }
    }
}
