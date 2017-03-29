using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace Laba2 {

	class Game {
		protected int[,] numbers;
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
			int edge = 0;
			if (Math.Sqrt (numbers.Length) - (int)Math.Sqrt (numbers.Length) == 0) {
				edge = (int)Math.Sqrt (numbers.Length);
				}
			else {
				for (int i = 2; i < numbers.Length / 2; ++i) {
					if (numbers.Length % i == 0) {
						edge = numbers.Length / i;
						}
					}
				}
			this.numbers = new int[edge,numbers.Length/edge];
			for (int i = 0, count = 0; i < edge; ++i)
				for (int j = 0; j < numbers.Length/edge; ++j, ++count)
					this.numbers[i,j] = numbers[count];
			}
		public int this [int x, int y] {
			get { return numbers[x,y]; }
			}
		public int GetLength (int dimension) {
			return numbers.GetLength (dimension);
			}
		private bool simple (int number) {
            for (int i = 2; i <= (int)(number / 2); ++i)
                if (number % i == 0)
                    return false;
            return true;
			}
		public Tuple<int,int> GetLocation (int value) {
			for (int i = 0; i < numbers.GetLength(0); ++i)
				for (int j = 0; j < numbers.GetLength(1); ++j)
					if (numbers[i,j] == value)
						return Tuple.Create<int,int>(i,j);
			throw new ArgumentException ("error: Неверно задан элемент игры");
			}
		public virtual void Shift (int value) {
			bool flag = false;
			int x0 = GetLocation(0).Item1,
				y0 = GetLocation(0).Item2,
				xv = GetLocation(value).Item1,
				yv = GetLocation(value).Item2;
			if (((xv - 1 ==  x0 || xv + 1 == x0) && yv == y0) || 
				((yv - 1 ==  y0 || yv + 1 == y0) && xv == x0))
				flag = true;
			if (flag) {
				int temp = numbers[x0,y0];
				numbers[x0,y0] = numbers[xv,yv];
				numbers[xv,yv] = temp;
				}
			else {
				throw new ArgumentException ("error: Игровой элемент не может быть перемещён");
				}
			}
		public static Game InputFromCSV (string fileName) {
			string text = "";
			using (StreamReader sr = new StreamReader(fileName)) {
				string buf = "";
				while (true) {
					buf = sr.ReadLine();
					if (buf == null)
						break;
					text += buf + ";";
					}
				}
			Regex reg = new Regex ("\\d+");
			MatchCollection allNums = reg.Matches(text);
			int[] numbers = new int[allNums.Count];
			for (int i = 0; i < numbers.Length; ++i)
				numbers[i] = int.Parse (allNums[i].Value);
			return new Game (numbers);
			}
		}
	
	class Game2 : Game, IPlayable {
		public Game2 (params int[] numbers) : base (numbers) {}
		public void RandomizeGame () {
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
			int count = 0;
			for (int i = 2; i < numbers.GetLength(0) * numbers.GetLength(1); ++i)
				for (int j = i + 1; j < numbers.GetLength(0) * numbers.GetLength(1); ++j)
					if (GetLocation(i).Item1 <= GetLocation(j).Item1 && 
						GetLocation(i).Item2 <= GetLocation(j).Item2)
						++count;
			if (((GetLocation(0).Item1 + 1) + count)%2 == 0)
				RandomizeGame ();
			if (CheckVictoryGame())
				RandomizeGame ();
			}
		public bool CheckVictoryGame () {
			if (numbers[numbers.GetLength(0) - 1, numbers.GetLength(1) - 1] != 0)
				return false;
			for (int i = 0, x = 1; i < numbers.GetLength(0); ++i)
				for (int j = 0; j < numbers.GetLength(1) && x < numbers.GetLength(0) * numbers.GetLength(1); ++j, ++x)
					if (!(numbers[i,j] == x))
						return false;
			return true;
			}
		}
	
	class Game3 : Game2, IPlayable {
		private List<int> history;
		private List<int> backHistory;
		public Game3 (params int[] numbers) : base (numbers) {
			history = new List<int>();
			backHistory = new List<int>();
			}
		public override void Shift (int value) {
			base.Shift (value);
			history.Add (value);
			backHistory.Clear ();
			}
		public void Undo () {
			if (history.Count == 0)
				throw new Exception ("error: История пуста");
			backHistory.Add (history[history.Count - 1]);
			base.Shift (history[history.Count - 1]);
			history.RemoveAt (history.Count - 1);
			}
		public void Redo () {
			if (backHistory.Count == 0)
				throw new Exception ("error: История пуста");
			base.Shift (backHistory[backHistory.Count - 1]);
			history.Add (backHistory[backHistory.Count - 1]);
			backHistory.RemoveAt (backHistory.Count - 1);
			}

		}
	
	interface IPlayable {
		void RandomizeGame ();
		bool CheckVictoryGame ();
		void Shift (int value);
		
		int GetLength (int dimension);
		int this [int x, int y] { get; }
		}
	
	class ConsoleGameUI {
		private IPlayable game;
		public ConsoleGameUI (IPlayable game) {
			this.game = game;
			}
		private void GetConsoleGame () {
			for (int i = 0; i < game.GetLength(0); ++i) {
				for (int j = 0; j < game.GetLength(1); ++j) {
					//Console.Write (game[i,j] + " ");
					Console.Write (String.Format ("{0,3:0}", game[i,j]) + " ");
					}
				Console.Write ("\n");
				}
			}
		private bool SetConsoleShift () {
			try {
				Console.Write ("\nПередвинуть: ");
				int number = Int32.Parse(Console.ReadLine());
				game.Shift (number);
				}
			catch (Exception) {
				return false;
				}
			return true;
			}
		public void StartGame () {
			while (true) {
				Console.Clear();
				Console.WriteLine ("ПЯТНАШКИ\n");
				Console.WriteLine ("Для управления используйте цифры");
				Console.WriteLine ("Что бы выйти нажмите Ctrl+C\n");
				GetConsoleGame ();
				if (game.CheckVictoryGame ()) {
					Console.Clear();
					Console.WriteLine ("************************");
					Console.WriteLine ("****/ Вы победили! /****");
					Console.WriteLine ("************************");
					return;
					}
				SetConsoleShift ();
				}
			}
		}

	class MainLaba {
		static void Main () {
/*			Console.WriteLine ("------------Basic_functions-test--------------");
			Game3 game = new Game3 (1, 2, 3, 4, 5, 6, 7, 8, 0);
			Console.WriteLine (game.CheckVictoryGame());
//			game.RandomizeGame();
//			Console.WriteLine (game.CheckVictoryGame());
			
			for (int i = 0; i < game.GetLength(0); ++i) {
				for (int j = 0; j < game.GetLength(1); ++j) {
					Console.Write (game[i,j] + " ");
					}
				Console.Write ("\n");
				}

			Console.Write ("(6)\n");
			game.Shift (6);
			for (int i = 0; i < game.GetLength(0); ++i) {
				for (int j = 0; j < game.GetLength(1); ++j) {
					Console.Write (game[i,j] + " ");
					}
				Console.Write ("\n");
				}
			
			Console.Write ("(5)\n");
			game.Shift (5);
			for (int i = 0; i < game.GetLength(0); ++i) {
				for (int j = 0; j < game.GetLength(1); ++j) {
					Console.Write (game[i,j] + " ");
					}
				Console.Write ("\n");
				}
				
			Console.Write ("(2)\n");
			game.Shift (2);
			for (int i = 0; i < game.GetLength(0); ++i) {
				for (int j = 0; j < game.GetLength(1); ++j) {
					Console.Write (game[i,j] + " ");
					}
				Console.Write ("\n");
				}
			
			Console.WriteLine ("---------------Undo-Redo-test-----------------");
			game.Undo ();
			game.Undo ();
			game.Undo ();
			game.Redo ();
			game.Redo ();
			game.Redo ();
			game.Undo ();
			game.Undo ();
			game.Undo ();
			game.Redo ();
			for (int i = 0; i < game.GetLength(0); ++i) {
				for (int j = 0; j < game.GetLength(1); ++j) {
					Console.Write (game[i,j] + " ");
					}
				Console.Write ("\n");
				}
			
				
//			game.LoadGamePosition (0);
//			Console.Write ("На шаг назад\n");
//			
//			for (int i = 0; i < game.GetLength(0); ++i) {
//				for (int j = 0; j < game.GetLength(1); ++j) {
//					Console.Write (game[i,j] + " ");
//					}
//				Console.Write ("\n");
//				}
			
			// test input from csv
			Game game1 = Game.InputFromCSV ("15.csv");
			Console.Write ("\n");
			for (int i = 0; i < game1.GetLength(0); ++i) {
				for (int j = 0; j < game1.GetLength(1); ++j) {
					Console.Write (game1[i,j] + " ");
					}
				Console.Write ("\n");
				}
			
			Console.WriteLine ("--------------IPlayable-test------------------");
			List<IPlayable> games = new List<IPlayable>();
			games.Add (new Game3 (1, 2, 3, 4, 5, 6, 7, 8, 0));
			Console.WriteLine (games[0].CheckVictoryGame());
			games[0].RandomizeGame();
			Console.WriteLine (games[0].CheckVictoryGame());
			games.Add (new Game2 (1, 3, 2, 4, 5, 6, 7, 8, 0));
			Console.WriteLine (games[1].CheckVictoryGame());
			Console.WriteLine (games[1][0,2]);
*/			
//			Console.WriteLine ("------------ConsoleGameUI-test----------------");
			IPlayable gm = new Game3 (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 0);
			gm.RandomizeGame();
			ConsoleGameUI CG = new ConsoleGameUI (gm);
			CG.StartGame ();
			}
		}
	
	}

//Проверка csv на корректность данных и их расположния
//Point класс
//Класс с 2 массивами - для двойной индексации
