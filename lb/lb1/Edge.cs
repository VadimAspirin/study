using System;

namespace Laba1 {
	
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
	
	}
