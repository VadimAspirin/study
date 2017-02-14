using System;

namespace Laba1 {
	
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
			if (pointFirst == pointSecond || pointSecond == pointLast || pointFirst == pointLast ) {
				Console.WriteLine ("error: Задан не треугольник! Две или более точек равны");
				Environment.Exit (0);
				}
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
	
	}
