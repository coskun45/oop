using System;

namespace PraktikumsAufgabe1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Point myPoint1 = new Point(2, 2); 
            //Point myPoint2 = new Point(-4, -4); 
            //myPoint2 = -myPoint2; 
            //myPoint1 *= 2; 
            //if (myPoint2 == myPoint1) { Console.WriteLine("identical points"); }

            Polygon myLine = new Polygon(new Point(2, 1), new Point(2, 2), new Point(3, 3)); 
            myLine[0] = new Point(1, 1); 
            Console.WriteLine("polygon points: "); 
            for (int i = 0; i < myLine.NumberPoints; i++) { Console.WriteLine(myLine[i]); }
            Console.WriteLine($"Length Polygon: {(double)myLine}"); 
            Point myPoint3 = new Point(200, 200);
        }
    }
    class Point
    {
        int x;
        public int X { get { return x; } }
        public int Y { get { return y; } }
        int y;
        const int MaxX = 100;
        const int MaxY = 100;
        public Point(int x,int y)
        {
            if ((x>=-MaxX && x<=MaxX)&& (y >= -MaxY && y <= MaxY))
            {
                this.x = x;
                this.y = y;
            }
            else
            {
                Console.WriteLine("coordinate out of range");
                System.Environment.Exit(-1);
            }
        }

        public static Point operator -(Point point)
        {
            return new Point(-1 * point.x, -1 * point.y);
        }
        public static Point operator *(Point p, int c)
        {
            return new Point(c * p.x, c * p.y);
        }
        public static bool operator ==(Point a,Point b)
        {
            if (a.x==b.x&&b.x==b.y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(Point a, Point b)
        {
            if (a.x == b.x && b.x == b.y)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public override string ToString()
        {
            return $"x: {x} y: {y} ";
        }
    }
    class Polygon
    {
        Point[] arr;
        Point point;
        readonly int numberPoints;
        public int NumberPoints { get { return arr.Length; } }

        public Polygon(params Point[] feld)
        {
            arr = new Point[feld.Length];
            this.arr = feld;
            numberPoints = feld.Length;
            
        }

        public Point this[int idx]
        {
            get
            {
                if (idx>=NumberPoints)
                {
                    Console.WriteLine("index out of range");
                    System.Environment.Exit(-1);
                    return null;
                }
                else
                {
                    return arr[idx];

                }
            }
            set
            {
                if (idx <= arr.Length)
                {
                    arr[idx] = value;
                }
                else
                {
                    Console.WriteLine("index out of range");
                    System.Environment.Exit(-1);
                }

            }
        }
        public static explicit operator double(Polygon poly)
        {
            double sum = 0;
            for (int i = poly.NumberPoints - 1; i > 0; i--)
            {
                sum += Math.Sqrt(Math.Pow(poly[i].X - poly[i - 1].X, 2) + Math.Pow(poly[i].Y - poly[i - 1].Y, 2));

            }
            return sum;
        }


    }
}
