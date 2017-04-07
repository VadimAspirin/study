using System;

namespace Laba6 
{

	class Watchman : ApplicationUser
	{
		public Watchman (string loginName, string password, string firstName, string secondName, string lastName)
						 : base (loginName, password, firstName, secondName, lastName, "Watchman") {}
	}
	
}
