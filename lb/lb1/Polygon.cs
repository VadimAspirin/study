using System;

namespace Laba1 {
	
	/*  BONUS  */
	class Polygon {
		public readonly Point[] Points;
		public readonly Edge[] Edges;
		public Polygon (Point[] points) {
			if (points.Length <= 2)
				throw new ArgumentException ("error: Задан не многоугольник");
			for (int i = 0; i < points.Length; ++i)
				for (int j = i + 1; j < points.Length; ++j)
					if (points[i] == points[j])
						throw new ArgumentException ("error: Две или более точек многоугольника равны");
			Points = points;
			Edges = new Edge[Points.Length];
			for (int i = 0; ; ++i) {
				if (i == Edges.Length - 1) {
					Edges[i] = new Edge (Points[i], Points[0]);
					break;
					}
				Edges[i] = new Edge (Points[i], Points[i+1]);
				}
			}
		public double this [int index] {
			get {
				if (index >= Edges.Length || index < 0)
					throw new IndexOutOfRangeException ("error: Неверное количество сторон многоугольника");
				return Edges[index].Length;
				}
			}
		public static bool operator == (Polygon triangleFirst, Polygon triangleSecond) {
			if (triangleFirst.CountAngles != triangleSecond.CountAngles)
				return false;
			int count = 0;
			for (int i = 0; i < triangleFirst.CountAngles; ++i) {
				for (int j = 0; j < triangleFirst.CountAngles; ++j) {
					if (triangleFirst[i] == triangleSecond[j]) {
						++count;
						break;
						}
					}
				}
			return count >= triangleFirst.CountAngles;
			}
		public static bool operator != (Polygon triangleFirst, Polygon triangleSecond) {
			if (triangleFirst.CountAngles != triangleSecond.CountAngles)
				return true;
			int count = 0;
			for (int i = 0; i < triangleFirst.CountAngles; ++i) {
				for (int j = 0; j < triangleFirst.CountAngles; ++j) {
					if (triangleFirst[i] == triangleSecond[j]) {
						++count;
						break;
						}
					}
				}
			return count < triangleFirst.CountAngles;
			}
		public double Perimeter {
		    get {
				double sum = 0;
				foreach (Edge i in Edges)
					sum += i.Length;
				return sum;
				}
			}
		public double Area {
		    get {
				double buf1 = 0, buf2 = 0;
				for (int i = 0; ; ++i) {
					if (i == Points.Length - 1) {
						buf1 += Points[i].X * Points[0].Y;
						buf2 += Points[i].Y * Points[0].X;
						break;
						}
					buf1 += Points[i].X * Points[i+1].Y;
					buf2 += Points[i].Y * Points[i+1].X;
					}
				return (buf1 - buf2) / 2;
				}
			}
		public bool Equilateral {
			get {
				for (int i = 0; i < Edges.Length; ++i)
					for (int j = i + 1; j < Edges.Length; ++j)
						if (Edges[i].Length != Edges[j].Length)
							return false;
				return true;
				}
			}
		public int CountAngles {
			get {
				return Points.Length;
				}
			}
		public bool Convex {
			get {
				int plus = 0, minus = 0;
				for (int i = 0, j = 1; i < Points.Length; ++i, ++j) {
					if (i == Points.Length - 1)
						j = 0;
					if ((Points[i].X * Points[j].Y - Points[j].X * Points[i].Y) >= 0)
						++plus;
					else
						++minus;
					}
				return ((plus == 0 && minus > 0) || (minus == 0 && plus > 0));
				}
			}
		}
		
	}
