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
		public override void Shift (int value) {
			base.Shift (value);
			SaveGamePosition ();
			}

		}

	}
