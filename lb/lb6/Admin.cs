using System;

namespace Laba6 
{

	class Admin : ApplicationUser
	{
		public Admin (string loginName, string password, string firstName, string secondName, string lastName)
					  : base (loginName, password, firstName, secondName, lastName, "Admin") {}
	}
	
}
