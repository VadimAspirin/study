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
		private void Print () 
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
		private void Shift () 
		{
			while (true) 
			{
				try 
				{
					Console.Write ("\nПередвинуть: ");
					int number = Int32.Parse(Console.ReadLine());
					game.Shift (number);
				}
				catch (ArgumentException) 
				{
					Console.WriteLine ("Введённая костяшка не может быть перемещена!");
					continue;
				}
				catch (FormatException) 
				{
					Console.WriteLine ("Введён не номер!");
					continue;
				}
				catch (OverflowException) 
				{
					Console.WriteLine ("Введённый номер некорректен!");
					continue;
				}
				break;
			}
		}
		public void StartGame () 
		{
			while (true) 
			{
				Console.Clear();
				Console.WriteLine ("ПЯТНАШКИ\n");
				Console.WriteLine ("Для управления используйте номера");
				Console.WriteLine ("Что бы выйти нажмите Ctrl+C\n");
				Print ();
				if (game.CheckVictoryGame ()) 
				{
					Console.Clear();
					Console.WriteLine ("************************");
					Console.WriteLine ("****/ Вы победили! /****");
					Console.WriteLine ("************************");
					return;
				}
				Shift ();
			}
		}
	}
	
}
