using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tsp
{
    class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }

    class Program
    {
        private static List<Point> points;
        public static double minLength;
        public static string shortestPath;
        public static StringBuilder sb;

        static void Main(string[] args)
        {
            Initialize();

            var begin = DateTime.Now;

            CalculateShortesPath();

            var diff = DateTime.Now - begin;

            Console.WriteLine("length: " + minLength.ToString());
            Console.WriteLine("path: " + shortestPath);
            Console.WriteLine("time (sec): " + diff.TotalSeconds.ToString());
            Console.WriteLine();

            if (sb.Length > 0)
            {
                System.IO.File.WriteAllText(@"c:\temp\tspbf.net.log", sb.ToString());
            }
        }

        private static void Initialize()
        {
            sb = new StringBuilder();
            points = new List<Point>();

            AddPoint(327, 95);
            AddPoint(389, 92);
            AddPoint(581, 152);
            AddPoint(511, 229);
            AddPoint(708, 242);
            AddPoint(280, 284);
            AddPoint(397, 311);
            AddPoint(609, 360);
            AddPoint(448, 411);
            AddPoint(259, 437);
            //AddPoint(579, 495);
            //AddPoint(427, 540);
        }

        private static void AddPoint(int x, int y)
        {
            points.Add(new Point(x, y));
        }

        private static void CalculateShortesPath()
        {
            minLength = double.PositiveInfinity;
            sb.Clear();

            var indices = new int[points.Count];

            for (int i = 0; i < indices.Length; i++)
            {
                indices[i] = i;
            }

            RecSwap(indices, 0, indices.Length - 1);
        }

        private static void RecSwap(int[] list, int k, int m)
        {
            //Sb.AppendLine(string.Format("k = {0}, m = {1}, list = {2}", k, m, PathToString(list)));

            if (k == m)
            {
                CalculatePath(list);
            }
            else
            {
                for (int i = k; i <= m; i++)
                {
                    Swap(ref list[k], ref list[i]);

                    RecSwap(list, k + 1, m);

                    Swap(ref list[k], ref list[i]);
                }
            }
        }

        private static void CalculatePath(IEnumerable<int> indices)
        {
            double path = 0;
            int prev = -1;

            foreach (var current in indices)
            {
                if (prev > -1)
                {
                    path += Distance(points[prev], points[current]);
                }

                prev = current;
            }

            var last = points[indices.Last()];
            var first = points[indices.First()];

            path += Distance(last, first);

            if (path < minLength)
            {
                minLength = path;
                shortestPath = PathToString(indices);
            }
        }

        private static double Distance(Point p, Point q)
        {
            return Distance(p.X, p.Y, q.X, q.Y);
        }

        private static double Distance(int px, int py, int qx, int qy)
        {
            return Math.Sqrt(Math.Pow(qx - px, 2) + Math.Pow(qy - py, 2));
        }

        private static string PathToString(IEnumerable<int> indices)
        {
            var sb = new StringBuilder();

            foreach (int i in indices)
            {
                sb.Append(i.ToString() + "-");
            }

            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }

        private static void Swap(ref int a, ref int b)
        {
            if (a == b) return;

            var tmp = a;
            a = b;
            b = tmp;
        }
    }
}
