using System;

namespace Laba2 {

	class SquareTile {
		public readonly int Number;
		private int x, y;
		public SquareTile (int number) {
			Number = number;
			}
		public SquareTile (int number, int x, int y) {
			Number = number;
			this.x = x;
			this.y = y;
			}
		public int X {
			get { return x; }
			set { x = value; }
			}
		public int Y {
			get { return y; }
			set { y = value; }
			}
		}

	class Game {
		private SquareTile[] squareTiles;
		public Game (params int[] numbers) {
			bool flag = false;
			foreach (int i in numbers) {
				if (i == 0) {
					flag = true;
					break;
					}
				}
			if (!flag)
				throw new ArgumentException ("error: Отсутствует нулевой элемент");
			if (numbers.Length < 4 || simple (numbers.Length))
				throw new ArgumentException ("error: Невозможно создать игру по данному количеству элементов");
			squareTiles = new SquareTile[numbers.Length];
			for (int i = 0; i < squareTiles.Length; ++i)
				squareTiles[i] = new SquareTile (numbers[i]);
			newGame ();
			}
		public int this [int x, int y] {
			get {
				foreach (SquareTile i in squareTiles)
					if (i.X == x && i.Y == y)
						return i.Number;
				throw new IndexOutOfRangeException ("error: Неверно заданные координаты");
				}
			}
		private bool simple (int number) {
            for (int i = 2; i <= (int)(number / 2); ++i)
                if (number % i == 0)
                    return false;
            return true;
			}
		private void newGame () {
			int edge = 0;
			if (Math.Sqrt (squareTiles.Length) - (int)Math.Sqrt (squareTiles.Length) == 0) {
				edge = (int)Math.Sqrt (squareTiles.Length);
				}
			else {
				for (int i = 2; i < squareTiles.Length / 2; ++i) {
					if (squareTiles.Length % i == 0) {
						edge = squareTiles.Length / i;
						}
					}
				}
			// перемешать
			var rand = new Random ();
			for (int i = squareTiles.Length - 1; i >= 0; --i) {
				int j = rand.Next (i);
				SquareTile temp = squareTiles[i];
				squareTiles[i] = squareTiles[j];
				squareTiles[j] = temp;
				}
			// назначить координаты
			for (int i = 0, j = 0, count = 0; count < squareTiles.Length; ++i, ++count) {
				if (i == edge) {
					i = 0;
					++j;
					}
				squareTiles[count].X = i;
				squareTiles[count].Y = j;
				}
			}
		public SquareTile GetLocation (int value) {
			foreach (SquareTile i in squareTiles)
				if (i.Number == value)
					return i;
			throw new ArgumentException ("error: Неверно задан элемент игры");
			}
		public void Shift (int value) {
			
			}
		}

	class MainLaba {
		static void Main () {
			Game game = new Game (1, 2, 3, 4, 5, 6, 7, 8, 0);
			Console.WriteLine (game[2, 0] + " " + game[2, 1] + " " + game[2, 2]);
			Console.WriteLine (game[1, 0] + " " + game[1, 1] + " " + game[1, 2]);
			Console.WriteLine (game[0, 0] + " " + game[0, 1] + " " + game[0, 2]);

			}
		}
	
	}
// статическим полем в классе Game - считывание из csv поля и возврат Game
