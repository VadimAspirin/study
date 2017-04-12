using System;

namespace Laba6 
{

	class Pass 
	{
		public readonly string Number;
		private Date expirationTime;
		public Pass (string number, Date expirationTime)
		{
			Number = number;
			this.expirationTime = expirationTime;
		}
		public Date ExpirationTime 
		{
			get { return expirationTime; }
			set { expirationTime = value; }
		}
	}
}
