using System;
using System.Collections.Generic;

namespace Laba6 
{

	class Locker 
	{
		public readonly string Number;
		private List<string> documentNumbers;
		public Locker (string number, List<string> documentNumbers)
		{
			Number = number;
			this.documentNumbers = documentNumbers;
		}
		public List<string> DocumentNumbers
		{
			get { return documentNumbers; }
			set { documentNumbers = value; }
		}
	}
	
}
