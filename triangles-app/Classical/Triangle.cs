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
                validateSide(value); 
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
                validateSide(value);
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
                validateSide(value);
                c = value;
            }
        }

        public double Alpha { get { return Triangle.computeAngle(a, b, c); } }
        public double Beta  { get { return Triangle.computeAngle(b, c, a); } }
        public double Gamma { get { return Triangle.computeAngle(a, c, b); } }

        private static void validateSide(double side)
        {
            if (side <= 0)
                throw new ArgumentOutOfRangeException("Side must be greater than 0.");
        }

        private static void validateAngle(double angle)
        {
            if (angle <= 0 && angle >= 180)
                throw new ArgumentOutOfRangeException("Angle must be in range (0; 180)");
        }

        public static double computeSide(double a, double b, double angle)
        {
            validateAngle(angle);
            double angleRad = Util.DegToRad(angle);
            return Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(angleRad));
        }

        public static double computeAngle(double a, double b, double c)
        {
            double angleRad = Math.Acos((a * a + b * b - c * c) / (2 * a * b));
            return Util.RadToDeg(angleRad);
        }

        public Triangle() { }

        public Triangle(double a, double b, double alpha)
        {
            this.A = a;
            this.B = b;
            this.C = Triangle.computeSide(a, b, alpha);
        }
    }
}
