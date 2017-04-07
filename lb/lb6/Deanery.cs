using System;

namespace Laba6 
{

	class Deanery : ApplicationUser
	{
		public Deanery (string loginName, string password, string firstName, string secondName, string lastName)
						: base (loginName, password, firstName, secondName, lastName, "Deanery") {}
	}
	
}
