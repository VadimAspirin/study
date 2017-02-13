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
		}
	
	class Edge {
		private Point pointFirst, pointSecond;
		public Edge () {
			pointFirst = new Point ();
			pointSecond = new Point ();
			}
		public Edge (Point pointFirst, Point pointSecond) {
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
	
	class Triangle {
		private Point pointFirst, pointSecond, pointLast;
		private Edge edgeFirst, edgeSecond, edgeLast;
		public Triangle () {
			pointFirst = new Point ();
			pointSecond = new Point ();
			pointLast = new Point ();
			edgeFirst = new Edge ();
			edgeSecond = new Edge ();
			edgeLast = new Edge ();
			}
		public Triangle (Point pointFirst, Point pointSecond, Point pointLast) {
			this.pointFirst = pointFirst;
			this.pointSecond = pointSecond;
			this.pointLast = pointLast;
			edgeFirst = new Edge (pointFirst, pointSecond);
			edgeSecond = new Edge (pointSecond, pointLast);
			edgeLast = new Edge (pointFirst, pointLast);
			}
		public double Perimeter {
		    get {
			return edgeFirst.Length + edgeSecond.Length + edgeLast.Length;
					}
				}
		public double Area {
		    get {
			double p = Perimeter / 2;
			return Math.Sqrt (p * (p - edgeFirst.Length) *
							 (p - edgeSecond.Length) * (p - edgeLast.Length));
					}
				}
		public bool Right {
			get {
				if ((float)(Math.Pow (edgeFirst.Length, 2) + Math.Pow (edgeSecond.Length, 2)) == 
					(float)Math.Pow (edgeLast.Length, 2) ||
					(float)(Math.Pow (edgeFirst.Length, 2) + Math.Pow (edgeLast.Length, 2)) == 
					(float)Math.Pow (edgeSecond.Length, 2) ||
					(float)(Math.Pow (edgeLast.Length, 2) + Math.Pow (edgeSecond.Length, 2)) == 
					(float)Math.Pow (edgeFirst.Length, 2)) {
					return true;
					}
				else {
					return false;
					}
				}
			}
		public bool Isosceles {
			get {
				if (edgeFirst.Length == edgeSecond.Length || 
					edgeFirst.Length == edgeLast.Length ||
					edgeSecond.Length == edgeLast.Length) {
					return true;
					}
				else {
					return false;
					}
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
			
			Console.WriteLine("Средний периметр всех прямоугольных треугольников {0}", sumPerimeter / iRight);
			Console.WriteLine("Средняя площадь всех равнобедренных треугольников {0}", sumArea / iIsosceles);
			
			Console.WriteLine("Press any key to exit.");
			Console.ReadKey();
			}
		}
		
	}
