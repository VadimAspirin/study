using System;

namespace Laba6 
{

	class MainLaba 
	{
		static void Main () 
		{
			Date date = new Date (1996, 2, 29);
			Pass pass = new Pass ("8hHJ992ffoA", date);
			Console.WriteLine (pass.Number);
		}
	}
	
}
