using System;

namespace Laba1 {

	class MainLaba {
		static void Main () {

			Polygon polygon = new Polygon (new Point[] {new Point (0, 0), new Point (2, 0), new Point (3, 1), 
							new Point (3, 3), new Point (2, 4), new Point (0, 4), new Point (-2, 2)});
			Console.WriteLine ("Периметр: " + polygon.Perimeter);
			Console.WriteLine ("Площадь: " + polygon.Area);
			Console.WriteLine ("Равносторонний: " + polygon.Equilateral);
			Console.WriteLine ("Количество углов: " + polygon.CountAngles);
			Console.WriteLine ("Правильный: " + polygon.Convex);
			
			Console.WriteLine("Press any key to exit.");
			Console.ReadKey();
			}
		}

	}
