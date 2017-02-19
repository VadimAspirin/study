using System;

namespace Laba1 {

	class Point {
		public readonly double X, Y;
		public Point (double x, double y) {
			X = x;
			Y = y;
			}
		public static bool operator == (Point pointFirst, Point pointSecond) {
			return pointFirst.X == pointSecond.X && pointFirst.Y == pointSecond.Y;
			}
		public static bool operator != (Point pointFirst, Point pointSecond) {
			return pointFirst.X != pointSecond.X || pointFirst.Y != pointSecond.Y;
			}
		}
	
	class Edge {
		public readonly Point PointFirst, PointSecond;
		public Edge (Point pointFirst, Point pointSecond) {
			if (pointFirst == pointSecond)
				throw new ArgumentException ("error: Длина ребра должна быть больше 0");
			PointFirst = pointFirst;
			PointSecond = pointSecond;
			}
		public static bool operator == (Edge edgeFirst, Edge edgeSecond) {
			return edgeFirst.Length == edgeSecond.Length;
			}
		public static bool operator != (Edge edgeFirst, Edge edgeSecond) {
			return edgeFirst.Length != edgeSecond.Length;
			}
		public double Length {
			get {
				return Math.Sqrt (Math.Pow (PointSecond.X - PointFirst.X, 2) +
								  Math.Pow (PointSecond.Y - PointFirst.Y, 2));
				}
			}
		}
	
	class Triangle {
		public readonly Point PointFirst, PointSecond, PointLast;
		public readonly Edge EdgeFirst, EdgeSecond, EdgeLast;
		public Triangle (Point pointFirst, Point pointSecond, Point pointLast) {
			if (pointFirst == pointSecond || pointSecond == pointLast || pointFirst == pointLast )
				throw new ArgumentException ("error: Задан не треугольник! Две или более точек равны");
			PointFirst = pointFirst;
			PointSecond = pointSecond;
			PointLast = pointLast;
			EdgeFirst = new Edge (pointFirst, pointSecond);
			EdgeSecond = new Edge (pointSecond, pointLast);
			EdgeLast = new Edge (pointFirst, pointLast);
			}
		public double Perimeter {
		    get {
				return EdgeFirst.Length + EdgeSecond.Length + EdgeLast.Length;
				}
			}
		public double Area {
		    get {
				double p = Perimeter / 2;
				return Math.Sqrt (p * (p - EdgeFirst.Length) *
					   (p - EdgeSecond.Length) * (p - EdgeLast.Length));
				}
			}
		public bool Right {
			get {
				return ((Math.Pow (EdgeFirst.Length, 2) + Math.Pow (EdgeSecond.Length, 2)) == 
						Math.Pow (EdgeLast.Length, 2) ||
						(Math.Pow (EdgeFirst.Length, 2) + Math.Pow (EdgeLast.Length, 2)) == 
						Math.Pow (EdgeSecond.Length, 2) ||
						(Math.Pow (EdgeLast.Length, 2) + Math.Pow (EdgeSecond.Length, 2)) == 
						Math.Pow (EdgeFirst.Length, 2));
				}
			}
		public bool Isosceles {
			get {
				return (EdgeFirst == EdgeSecond || 
						EdgeFirst == EdgeLast ||
						EdgeSecond == EdgeLast);
				}
			}
		}
	
	/*  BONUS  */
	class Polygon {
		public readonly Point[] points;
		public readonly Edge[] edges;
		public Polygon (Point[] points) {
			if (points.Length <= 2)
				throw new ArgumentException ("error: Задан не многоугольник");
			for (int i = 0; i < points.Length; ++i)
				for (int j = i + 1; j < points.Length; ++j)
					if (points[i] == points[j])
						throw new ArgumentException ("error: Две или более точек многоугольника равны");
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
		public bool Equilateral {
			get {
				for (int i = 0; i < edges.Length; ++i)
					for (int j = i + 1; j < edges.Length; ++j)
						if (edges[i].Length != edges[j].Length)
							return false;
				return true;
				}
			}
		public int CountAngles {
			get {
				return points.Length;
				}
			}
		public bool Convex {
			get {
				int plus = 0, minus = 0;
				for (int i = 0, j = 1; i < points.Length; ++i, ++j) {
					if (i == points.Length - 1)
						j = 0;
					if ((points[i].X * points[j].Y - points[j].X * points[i].Y) >= 0)
						++plus;
					else
						++minus;
					}
				return ((plus == 0 && minus > 0) || (minus == 0 && plus > 0));
				}
			}
		}

	class MainLaba {
		static void Main () {
		
			Triangle[] arrayTriangle = new Triangle[7];
			arrayTriangle[0] = new Triangle (new Point (0, 0), new Point (5.1, 0), new Point (0, 5.4));
			arrayTriangle[1] = new Triangle (new Point (0, 0), new Point (6, 0), new Point (0, 6));
			arrayTriangle[2] = new Triangle (new Point (0, 0), new Point (4, 0), new Point (0, 8));
			arrayTriangle[3] = new Triangle (new Point (0, 0), new Point (5, 0), new Point (0, 5));
			arrayTriangle[4] = new Triangle (new Point (6, 2), new Point (7, 5), new Point (0, 25));
			arrayTriangle[5] = new Triangle (new Point (0, 0), new Point (4, 0), new Point (0, 4));
			arrayTriangle[6] = new Triangle (new Point (0, 0), new Point (10.6, 0), new Point (0, 10.6));
			int iRight = 0, iIsosceles = 0;
			double sumPerimeter = 0, sumArea = 0;
			
			foreach (Triangle i in arrayTriangle) {
				if (i.Right) {
					++iRight;
					sumPerimeter += i.Perimeter;
					}
				if (i.Isosceles) {
					++iIsosceles;
					sumArea += i.Area;
					}
				}
			
			Console.WriteLine ("Средний периметр всех прямоугольных треугольников {0}", sumPerimeter / iRight);
			Console.WriteLine ("Средняя площадь всех равнобедренных треугольников {0}", sumArea / iIsosceles);
			
			// Exception test
			try {
				Triangle tr = new Triangle (new Point (0, 0), new Point (0, 0), new Point (0, 5.4));
				}
			catch (Exception ex) {
				 Console.WriteLine(ex.Message);
				}
			
			// Bonus test
			Polygon polygon = new Polygon (new Point[] {new Point (0, 0), new Point (2, 0), new Point (3, 1), 
							new Point (3, 3), new Point (2, 4), new Point (0, 4), new Point (-2, 2)});
			Console.WriteLine ("Периметр: " + polygon.Perimeter);
			Console.WriteLine ("Площадь: " + polygon.Area);
			Console.WriteLine ("Равносторонний: " + polygon.Equilateral);
			Console.WriteLine ("Количество углов: " + polygon.CountAngles);
			Console.WriteLine ("Правильный: " + polygon.Convex);
			
			Console.WriteLine ("Press any key to exit.");
			Console.ReadKey ();
			}
		}
		
	}
