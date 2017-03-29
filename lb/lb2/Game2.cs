using System;

namespace Laba2 
{

	class Game2 : Game, IPlayable 
	{
		public Game2 (params int[] numbers) : base (numbers) {}
		public virtual void RandomizeGame () 
		{
			var rand = new Random ();
			for (int i = 0; i < numbers.GetLength(0) + numbers.GetLength(1); ++i) 
			{
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

}
