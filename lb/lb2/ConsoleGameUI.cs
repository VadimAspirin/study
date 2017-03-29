using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace Laba2 
{

	class ConsoleGameUI 
	{
		private IPlayable game;
		public ConsoleGameUI (IPlayable game) 
		{
			this.game = game;
		}
		private void GetConsoleGame () 
		{
			for (int i = 0; i < game.GetLength(0); ++i) 
			{
				for (int j = 0; j < game.GetLength(1); ++j) 
				{
					Console.Write (String.Format ("{0,3:0}", game[i,j]) + " ");
				}
				Console.Write ("\n");
			}
		}
		private bool SetConsoleShift () 
		{
			try 
			{
				Console.Write ("\nПередвинуть: ");
				int number = Int32.Parse(Console.ReadLine());
				game.Shift (number);
			}
			catch (Exception) 
			{
				return false;
			}
			return true;
		}
		public void StartGame () 
		{
			while (true) 
			{
				Console.Clear();
				Console.WriteLine ("ПЯТНАШКИ\n");
				Console.WriteLine ("Для управления используйте цифры");
				Console.WriteLine ("Что бы выйти нажмите Ctrl+C\n");
				GetConsoleGame ();
				if (game.CheckVictoryGame ()) 
				{
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
	
}
