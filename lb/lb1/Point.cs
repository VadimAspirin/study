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
	
	}
