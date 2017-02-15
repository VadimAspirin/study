using System;

namespace Laba1 {
	
	/*  BONUS  */
	class Polygon {
		public readonly Point[] points;
		public readonly Edge[] edges;
		public Polygon (Point[] points) {
			if (points.Length <= 2)
				throw new Exception ("error: Задан не многоугольник");
			for (int i = 0; i < points.Length; ++i)
				for (int j = i + 1; j < points.Length; ++j)
					if (points[i] == points[j])
						throw new Exception ("error: Две или более точек многоугольника равны");
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
		
	}
