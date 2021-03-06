using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Laba2 
{
	
	class Game 
	{
		protected int[,] numbers;
		public Game (params int[] numbers) 
		{
			for (int i = 0; i < numbers.Length; ++i) 
			{
				bool flag = false;
				for (int j = 0; j < numbers.Length; ++j) 
				{
					if (i == numbers[j]) 
					{
						flag = true;
						break;
					}
				}
				if (!flag)
					throw new ArgumentException ("error: Пропущен один или несколько игровых элементов");
			}
			if (numbers.Length < 4 || simple (numbers.Length))
				throw new ArgumentException ("error: Невозможно создать игру по данному количеству элементов");
			int edge = 0;
			if (Math.Sqrt (numbers.Length) - (int)Math.Sqrt (numbers.Length) == 0) 
			{
				edge = (int)Math.Sqrt (numbers.Length);
			}
			else 
			{
				for (int i = 2; i < numbers.Length / 2; ++i) 
				{
					if (numbers.Length % i == 0) 
					{
						edge = numbers.Length / i;
					}
				}
			}
			this.numbers = new int[edge,numbers.Length/edge];
			for (int i = 0, count = 0; i < edge; ++i)
				for (int j = 0; j < numbers.Length/edge; ++j, ++count)
					this.numbers[i,j] = numbers[count];
		}
		public int this [int x, int y] 
		{
			get { return numbers[x,y]; }
		}
		public int GetLength (int dimension) 
		{
			return numbers.GetLength (dimension);
		}
		private bool simple (int number) 
		{
            		for (int i = 2; i <= (int)(number / 2); ++i)
                		if (number % i == 0)
                    			return false;
            		return true;
		}
		public Tuple<int,int> GetLocation (int value) 
		{
			for (int i = 0; i < numbers.GetLength(0); ++i)
				for (int j = 0; j < numbers.GetLength(1); ++j)
					if (numbers[i,j] == value)
						return Tuple.Create<int,int>(i,j);
			throw new ArgumentException ("error: Неверно задан элемент игры");
		}
		public virtual void Shift (int value) 
		{
			bool flag = false;
			int x0 = GetLocation(0).Item1,
				y0 = GetLocation(0).Item2,
				xv = GetLocation(value).Item1,
				yv = GetLocation(value).Item2;
			if (((xv - 1 ==  x0 || xv + 1 == x0) && yv == y0) || 
				((yv - 1 ==  y0 || yv + 1 == y0) && xv == x0))
				flag = true;
			if (flag) 
			{
				int temp = numbers[x0,y0];
				numbers[x0,y0] = numbers[xv,yv];
				numbers[xv,yv] = temp;
			}
			else 
			{
				throw new ArgumentException ("error: Игровой элемент не может быть перемещён");
			}
		}
		public static Game InputFromCSV (string fileName) 
		{
			string text = "";
			using (StreamReader sr = new StreamReader(fileName)) 
			{
				string buf = "";
				while (true) 
				{
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
	
}
