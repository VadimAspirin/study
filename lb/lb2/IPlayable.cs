using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace Laba2 {

	interface IPlayable {
		void RandomizeGame ();
		bool CheckVictoryGame ();
		void Shift (int value);
		
		int GetLength (int dimension);
		int this [int x, int y] { get; }
		}
	
	}
