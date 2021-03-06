using System;
using System.Collections.Generic;

namespace Laba2 
{

	class Game3 : Game2, IPlayable 
	{
		private List<int> history;
		private List<int> backHistory;
		public Game3 (params int[] numbers) : base (numbers) 
		{
			history = new List<int>();
			backHistory = new List<int>();
		}
		public override void Shift (int value) 
		{
			base.Shift (value);
			history.Add (value);
			backHistory.Clear ();
		}
		public override void RandomizeGame () 
		{
			base.RandomizeGame ();
			history.Clear ();
			backHistory.Clear ();
		}
		public void Undo () 
		{
			if (history.Count == 0)
				throw new Exception ("error: История пуста");
			backHistory.Add (history[history.Count - 1]);
			base.Shift (history[history.Count - 1]);
			history.RemoveAt (history.Count - 1);
		}
		public void Redo () 
		{
			if (backHistory.Count == 0)
				throw new Exception ("error: История пуста");
			base.Shift (backHistory[backHistory.Count - 1]);
			history.Add (backHistory[backHistory.Count - 1]);
			backHistory.RemoveAt (backHistory.Count - 1);
		}

	}

}
