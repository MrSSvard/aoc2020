using System;

namespace _5._1
{
    class Helpers
    {
        internal static int RowParser(string rowString)
        {
            int sum = 0;
            for (int x = 0; x < 7; x++)
            {
                if (rowString[x] == 'B')
                {
                    sum += Convert.ToInt32(Math.Pow(2, 6 - x));
                }
            }
            return sum;
        }

        internal static int ColumnParser(string columnString)
        {
            int sum = 0;
            for (int x = 0; x < 3; x++)
            {
                if (columnString[x] == 'R')
                {
                    sum += Convert.ToInt32(Math.Pow(2, 2 - x));
                }
            }
            return sum;
        }
    }
}