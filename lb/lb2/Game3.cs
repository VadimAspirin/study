using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Laba2 {

	class Game3 : Game2 {
		public Game3 (params int[] numbers) : base (numbers) {}
		public int[,] SaveGamePosition () {
			return numbers;
			}
		public void LoadGamePosition (int[,] numbers) {
			this.numbers = numbers;
			}
		}

	}
