using System;

namespace Laba1 {
	
	class MainLaba {
		static void Main () {
		
			Triangle[] arrayTriangle = new Triangle[7];
			arrayTriangle[0] = new Triangle (new Point (0, 0), new Point (5.1, 0), new Point (0, 5.4));
			arrayTriangle[1] = new Triangle (new Point (0, 0), new Point (6, 0), new Point (0, 6));
			arrayTriangle[2] = new Triangle (new Point (0, 0), new Point (4, 0), new Point (0, 8));
			arrayTriangle[3] = new Triangle (new Point (0, 0), new Point (5, 0), new Point (0, 5));
			arrayTriangle[4] = new Triangle (new Point (6, 2), new Point (7, 5), new Point (0, 25));
			arrayTriangle[5] = new Triangle (new Point (0, 0), new Point (4, 0), new Point (0, 4));
			arrayTriangle[6] = new Triangle (new Point (0, 0), new Point (10.6, 0), new Point (0, 10.6));
			int iRight = 0, iIsosceles = 0;
			double sumPerimeter = 0, sumArea = 0;
			
			foreach (Triangle i in arrayTriangle) {
				if (i.Right) {
					++iRight;
					sumPerimeter += i.Perimeter;
					}
				if (i.Isosceles) {
					++iIsosceles;
					sumArea += i.Area;
					}
				}
			
			Console.WriteLine("Средний периметр всех прямоугольных треугольников {0}", sumPerimeter / iRight);
			Console.WriteLine("Средняя площадь всех равнобедренных треугольников {0}", sumArea / iIsosceles);
			
			Console.WriteLine("Press any key to exit.");
			Console.ReadKey();
			}
		}
	
	}
