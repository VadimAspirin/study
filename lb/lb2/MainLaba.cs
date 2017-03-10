using System;

namespace Laba2 {
	
	class MainLaba {
		static void Main () {
			Game game = new Game (1, 2, 3, 4, 5, 6, 7, 8, 0);
			
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
			// test input from csv
			Game game1 = Game.InputFromCSV ("15.csv");
			Console.Write ("\n");
			for (int i = 0; i < game1.GetLength(0); ++i) {
				for (int j = 0; j < game1.GetLength(1); ++j) {
					Console.Write (game1[i,j] + " ");
					}
				Console.Write ("\n");
				}
			
			// TEST (15)2-3
			Game3 game3 = new Game3 (1, 2, 3, 4, 5, 6, 7, 8, 0);
			game3.NewGame(); // начать игру (перемешать)
			int[,] buf = game3.SaveGamePosition(); // сохранить положение
			//game3.Shift (6); // сделать ход
			Console.WriteLine (game3.WinGame()); // вы победили?
			game3.LoadGamePosition (buf); // загрузить положение
			
			
			}
		}
	
	}
