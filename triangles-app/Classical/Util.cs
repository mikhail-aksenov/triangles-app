using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrianglesApp.Classical
{
    public static class Util
    {
        public static readonly int DATA_SIZE = 3;

        public static double DegToRad(double degrees)
        {
            return degrees / 180 * Math.PI;
        }

        public static double RadToDeg(double radians)
        {
            return radians / Math.PI * 180;
        }

        public static double[] ParseRow(string row, long idx)
        {
            string[] splat = row.Split(';');

            if (splat.Length < DATA_SIZE)
            {
                throw new ArgumentException(String.Format("Not enough arguments at row {0}", idx));
            }

            double[] result = new double[DATA_SIZE];
            for (int i = 0; i < DATA_SIZE; i++)
            {
                double buf;
                if (Double.TryParse(splat[i], out buf))
                {
                    result[i] = buf;
                }
                else
                {
                    throw new FormatException(String.Format("Argument at position {0} is not a number.", i));
                }
            }

            return result;
        }
    }
}
