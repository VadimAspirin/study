using System;

namespace Laba6 
{

	class Student : ApplicationUser
	{
		public Student (string loginName, string password, string firstName, string secondName, string lastName)
						: base (loginName, password, firstName, secondName, lastName, "Student") {}
	}
	
}
