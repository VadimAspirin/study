using System;
using System.Collections.Generic;

namespace Laba2 {

	class Game3 : Game2 {
		private List<int[,]> gameStory;
		public Game3 (params int[] numbers) : base (numbers) {
			gameStory = new List<int[,]> ();
			}
		public void SaveGamePosition () {
			gameStory.Add (numbers);
			}
		public void LoadGamePosition (int countSteps) {
			numbers = gameStory[(gameStory.Count - 1) - countSteps];
			SaveGamePosition ();
			}
		public void Shift (int value) {
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
			SaveGamePosition ();
			}
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
			SaveGamePosition ();
			}
		}

	}
