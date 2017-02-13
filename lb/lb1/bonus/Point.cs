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

	}
