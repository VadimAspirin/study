using System;

namespace Laba6 
{

	class Teacher : ApplicationUser
	{
		public Teacher (string loginName, string password, string firstName, string secondName, string lastName)
						: base (loginName, password, firstName, secondName, lastName, "Teacher") {}
	}
	
}
