using System;

namespace Laba1 {

	class Point {
		public readonly double X, Y;
		public Point () {
			X = 0;
			Y = 0;
			}
		public Point (double x, double y) {
			X = x;
			Y = y;
			}
		public static bool operator == (Point pointFirst, Point pointSecond) {
			if (pointFirst.X == pointSecond.X && pointFirst.Y == pointSecond.Y)
				return true;
			return false;
			}
		public static bool operator != (Point pointFirst, Point pointSecond) {
			if (pointFirst.X != pointSecond.X || pointFirst.Y != pointSecond.Y)
				return true;
			return false;
			}
		}
	
	class Edge {
		private Point pointFirst, pointSecond;
		public Edge () {
			pointFirst = new Point ();
			pointSecond = new Point ();
			}
		public Edge (Point pointFirst, Point pointSecond) {
			if (pointFirst == pointSecond) {
				Console.WriteLine ("error: Длина ребра должна быть больше 0");
				Environment.Exit (0);
				}
			this.pointFirst = pointFirst;
			this.pointSecond = pointSecond;
			}
		public double Length {
			get {
				return Math.Sqrt (Math.Pow (pointSecond.X - pointFirst.X, 2) +
								  Math.Pow (pointSecond.Y - pointFirst.Y, 2));
				}
			}
		}
	
	class Polygon {
		private Point[] points;
		private Edge[] edges;
		public Polygon (Point[] points) {
			this.points = points;
			edges = new Edge[points.Length];
			for (int i = 0; ; ++i) {
				if (i == edges.Length - 1) {
					edges[i] = new Edge (points[i], points[0]);
					break;
					}
				edges[i] = new Edge (points[i], points[i+1]);
				}
			}
		public double Perimeter {
		    get {
				double sum = 0;
				foreach (Edge i in edges)
					sum += i.Length;
				return sum;
				}
			}
		public double Area {
		    get {
				double buf1 = 0, buf2 = 0;
				for (int i = 0; ; ++i) {
					if (i == points.Length - 1) {
						buf1+= points[i].X * points[0].Y;
						break;
						}
					buf1 += points[i].X * points[i+1].Y;
					}
				for (int i = 0; ; ++i) {
					if (i == points.Length - 1) {
						buf2+= points[i].Y * points[0].X;
						break;
						}
					buf2 += points[i].Y * points[i+1].X;
					}
				return (buf1 - buf2) / 2;
				}
			}
		}

	class MainLaba {
		static void Main () {

			Polygon polygon = new Polygon (new Point[] {new Point (0, 0), new Point (2, 0), new Point (3, 1), 
							new Point (3, 3), new Point (2, 4), new Point (0, 4), new Point (2, 2)});
			Console.WriteLine (polygon.Perimeter);
			Console.WriteLine (polygon.Area);
			
			Console.WriteLine("Press any key to exit.");
			Console.ReadKey();
			}
		}
		
	}
