using System;

namespace Laba2 {

	class Game2 : Game {
		public Game2 (params int[] numbers) : base (numbers) {}
		public void NewGame () {
			var rand = new Random ();
			for (int i = 0; i < numbers.GetLength(0) + numbers.GetLength(1); ++i) {
				int i1 = rand.Next (numbers.GetLength(0)),
					j1 = rand.Next (numbers.GetLength(1)),
					i2 = rand.Next (numbers.GetLength(0)),
					j2 = rand.Next (numbers.GetLength(1));
				int temp = numbers[i1,j1];
				numbers[i1,j1] = numbers[i2,j2];
				numbers[i2,j2] = temp;
				}
			}
		public bool WinGame () {
			int count = 0, x = 1;
			for (int i = 0; i < numbers.GetLength(0); ++i) {
				for (int j = 0; j < numbers.GetLength(1); ++j, ++x) {
					if (numbers[i,j] == x)
						++count;
					}
				}
			return (count == (x - 2));
			}
		}

	}
