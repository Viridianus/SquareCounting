using System;

namespace SquareCounting
{
    public class Squares
    {
        public static bool Pythagoras(double a, double b, double c)
        {
            if (a <= 0) return false;
            if (b <= 0) return false;
            if (c < b) return Pythagoras(a, c, b);
            if (c < a) return Pythagoras(c, b, a);
            return a * a + b * b == c * c;
        }
        public static double Triangle(double a, double b, double c)
        {
            if (Pythagoras(a, b, c)) //Not really needed but since you're asking?
                if (c < b)
                    if (a < b)
                        return a * c / 2;
                    else
                        return b * c / 2;
                else if (c < a)
                    return b * c / 2;
                else return a * b / 2;
            return Math.Sqrt((a + b + c) * (a + b - c) * (a + c - b) * (b + c - a)) / 4; //Geron, 1/2 taken out of the root
        }
        public static double Circle(double r)
        {
            return Math.PI * r * r;
        }
        public static double Rectangle(double a, double b)
        {
            return a * b;
        }
        public static double Parallelogram(double a, double b, double degree, bool radians = true) //Rhombus here
        {
            if (!radians) degree = degree * Math.PI / 180;
            if (degree == Math.PI / 2) return Rectangle(a, b);
            return a * b * Math.Sin(degree);
        }
        public static double Sector(double r, double degree, bool radians = true)
        {
            if (radians) return r * r * degree / 2;
            return Circle(r) * degree / 360;
        }
        public static double ThirdSide(double a, double b, double gamma, bool radians = true)
        {
            if (!radians) gamma = gamma * Math.PI / 180;
            return Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(gamma));
        }
        public static double Square(double a)
        {
            return a * a;
        }
        public static double TrapezoidHeight(double AB, double BC, double CD, double AD)
        {
            double AbsDiff = Math.Abs(AD - BC);
            return Math.Sqrt(AB * AB - Square((AbsDiff + (AB * AB - CD * CD) / AbsDiff) / 2));
        }
        public static double Trapezoid(double AB, double BC, double CD, double AD)
        {
            return BC * AD * TrapezoidHeight(AB, BC, CD, AD) / 2;
        }
        public static double Segment(double r, double degree, bool radians = true)
        {
            if (r == 0) return 0;
            if (!radians) degree = degree * Math.PI / 180;
            while (degree > 2 * Math.PI) degree -= 2 * Math.PI;
            while (degree < 0) degree += 2 * Math.PI;
            if (degree == 0) return 0;
            if (degree == 2 * Math.PI) return Circle(r);
            if (degree > Math.PI) return Circle(r) - Segment(r, 2 * Math.PI - degree);
            if (degree == Math.PI) return Sector(r, degree);
            if (degree == Math.PI / 2) return r * r * (degree - 1) / 2;
            return Sector(r, degree) - Triangle(r, r, ThirdSide(r, r, degree));
        }
    }
}
