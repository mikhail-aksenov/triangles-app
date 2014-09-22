using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TrianglesApp
{
    class Program
    {
        static void InvokeClassical(StreamReader sin, StreamWriter sou)
        { 
            string s;
            int idx = 1;
            while ((s = sin.ReadLine()) != null)
            {
                try
                {
                    double[] parsedData = Classical.Util.ParseRow(s, idx);
                    var t = new Classical.Triangle(parsedData[0], parsedData[1], parsedData[2]);
                    Console.WriteLine("Angles: alpha {0}; beta {1}; gamma {2}.", t.Alpha, t.Beta, t.Gamma);
                    sou.WriteLine(String.Format("{0};{1};{2}", t.A, t.B, t.C));
                }
                catch (ArgumentException e) { Console.WriteLine(e.Message); }
                catch (FormatException e) { Console.WriteLine(e.Message); }
            }
        }

        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("This application takes at least two arguments");
                return;
            }

            StreamReader sin = null;
            StreamWriter sou = null;
            try
            {
                sin = new StreamReader(args[0]);
                sou = new StreamWriter(args[1]);
                InvokeClassical(sin, sou);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message)
            }
            finally
            {
                if (sin != null) sin.Close();
                if (sou != null) sou.Close();
            }
        }   
    }
}
