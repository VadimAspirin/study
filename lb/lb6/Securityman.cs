using System;

namespace Laba6 
{

	class Securityman : ApplicationUser
	{
		public Securityman (string loginName, string password, string firstName, string secondName, string lastName)
							: base (loginName, password, firstName, secondName, lastName, "Securityman") {}
	}
	
}
