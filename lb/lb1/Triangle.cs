using System;

namespace Laba1 {
	
	class Triangle {
		public readonly Point PointFirst, PointSecond, PointThird;
		public readonly Edge EdgeFirst, EdgeSecond, EdgeThird;
		public Triangle (Point pointFirst, Point pointSecond, Point pointThird) {
			if (pointFirst == pointSecond || pointSecond == pointThird || pointFirst == pointThird )
				throw new ArgumentException ("error: Задан не треугольник! Две или более точек равны");
			PointFirst = pointFirst;
			PointSecond = pointSecond;
			PointThird = pointThird;
			EdgeFirst = new Edge (pointFirst, pointSecond);
			EdgeSecond = new Edge (pointSecond, pointThird);
			EdgeThird = new Edge (pointFirst, pointThird);
			}
		public double this [int index] {
			get {
				switch (index) {
					case 0:
						return EdgeFirst.Length;
					case 1:
						return EdgeSecond.Length;
					case 2:
						return EdgeThird.Length;
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
			return !(triangleFirst == triangleSecond);
			}
		public double Perimeter {
		    get {
				return EdgeFirst.Length + EdgeSecond.Length + EdgeThird.Length;
				}
			}
		public double Area {
		    get {
				double p = Perimeter / 2;
				return Math.Sqrt (p * (p - EdgeFirst.Length) *
					   (p - EdgeSecond.Length) * (p - EdgeThird.Length));
				}
			}
		public bool Right {
			get {
				return ((Math.Pow (EdgeFirst.Length, 2) + Math.Pow (EdgeSecond.Length, 2)) == 
						Math.Pow (EdgeThird.Length, 2) ||
						(Math.Pow (EdgeFirst.Length, 2) + Math.Pow (EdgeThird.Length, 2)) == 
						Math.Pow (EdgeSecond.Length, 2) ||
						(Math.Pow (EdgeThird.Length, 2) + Math.Pow (EdgeSecond.Length, 2)) == 
						Math.Pow (EdgeFirst.Length, 2));
				}
			}
		public bool Isosceles {
			get {
				return (EdgeFirst == EdgeSecond || 
						EdgeFirst == EdgeThird ||
						EdgeSecond == EdgeThird);
				}
			}
		}
	
	}
