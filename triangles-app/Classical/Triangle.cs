using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrianglesApp.Classical
{
    public sealed class Triangle
    {
        private double a;
        private double b;
        private double c;

        public double A 
        { 
            get 
            { 
                return a;
            } 
            set 
            { 
                ValidateSide("A", value); 
                a = value ;
            }
        }
        public double B 
        {
            get 
            {
                return b;
            }
            set 
            {
                ValidateSide("B", value);
                b = value;
            }
        }
        public double C 
        { 
            get
            {
                return c;
            }
            set
            {
                ValidateSide("C", value);
                c = value;
            }
        }

        public double Alpha { get { return Triangle.ComputeAngle(a, b, c); } }
        public double Beta  { get { return Triangle.ComputeAngle(b, c, a); } }
        public double Gamma { get { return Triangle.ComputeAngle(a, c, b); } }

        private static void ValidateSide(string name,double side)
        {
            if (side <= 0)
                throw new ArgumentOutOfRangeException(name, "Side must be greater than 0.");
        }

        private static void ValidateAngle(double angle)
        {
            if (angle <= 0 && angle >= 180)
                throw new ArgumentOutOfRangeException("Alpha", "Angle must be in range (0; 180)");
        }

        public static double ComputeSide(double a, double b, double angle)
        {
            ValidateAngle(angle);
            double angleRad = Util.DegToRad(angle);
            return Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(angleRad));
        }

        public static double ComputeAngle(double a, double b, double c)
        {
            double angleRad = Math.Acos((a * a + b * b - c * c) / (2 * a * b));
            return Util.RadToDeg(angleRad);
        }

        public Triangle() { }

        public Triangle(double a, double b, double alpha)
        {
            this.A = a;
            this.B = b;
            this.C = Triangle.ComputeSide(a, b, alpha);
        }
    }
}
