using System;

namespace Laba2 
{
	
	class MainLaba 
	{
		static void Main () 
		{
			IPlayable gm = new Game3 (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 0);
			gm.RandomizeGame();
			ConsoleGameUI CG = new ConsoleGameUI (gm);
			CG.StartGame ();
		}
	}
	
}
