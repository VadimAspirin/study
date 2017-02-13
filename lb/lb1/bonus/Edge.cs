using System;

namespace Laba1 {

	class Edge {
		private Point pointFirst, pointSecond;
		public Edge () {
			pointFirst = new Point ();
			pointSecond = new Point ();
			}
		public Edge (Point pointFirst, Point pointSecond) {
			if (pointFirst == pointSecond) {
				Console.WriteLine ("error: Длина ребра должна быть больше 0");
				Environment.Exit (0);
				}
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

	}
