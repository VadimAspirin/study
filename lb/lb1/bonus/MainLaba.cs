using System;

namespace Laba1 {

	class MainLaba {
		static void Main () {

			Polygon polygon = new Polygon (new Point[] {new Point (0, 0), new Point (2, 0), new Point (3, 1), 
							new Point (3, 3), new Point (2, 4), new Point (0, 4), new Point (2, 2)});
			Console.WriteLine (polygon.Perimeter);
			Console.WriteLine (polygon.Area);
			
			Console.WriteLine("Press any key to exit.");
			Console.ReadKey();
			}
		}

	}
