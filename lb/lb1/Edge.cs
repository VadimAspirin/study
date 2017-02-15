using System;

namespace Laba1 {
	
	class Edge {
		public readonly double Length;
		public Edge (Point pointFirst, Point pointSecond) {
			if (pointFirst == pointSecond)
				throw new Exception ("error: Длина ребра должна быть больше 0");
			Length = Math.Sqrt (Math.Pow (pointSecond.X - pointFirst.X, 2) +
								  Math.Pow (pointSecond.Y - pointFirst.Y, 2));
			}
		}
	
	}
