using System;

namespace Laba1 {
	
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
		public double this [int index] {
			get {
				switch (index) {
					case 0:
						return EdgeFirst.Length;
					case 1:
						return EdgeSecond.Length;
					case 2:
						return EdgeLast.Length;
					default:
						throw new IndexOutOfRangeException ("error: Неверное количество сторон треугольника");
					}
				}
			}
		public static bool operator == (Triangle triangleFirst, Triangle triangleSecond) {
			int count = 0;
			for (int i = 0; i < 3; ++i) {
				for (int j = 0; j < 3; ++j) {
					if (triangleFirst[i] == triangleSecond[j]) {
						++count;
						break;
						}
					}
				}
			return count >= 3;
			}
		public static bool operator != (Triangle triangleFirst, Triangle triangleSecond) {
			int count = 0;
			for (int i = 0; i < 3; ++i) {
				for (int j = 0; j < 3; ++j) {
					if (triangleFirst[i] == triangleSecond[j]) {
						++count;
						break;
						}
					}
				}
			return count < 3;
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
	
	}
