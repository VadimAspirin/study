using System;

namespace Laba6 
{

	class ApplicationUser 
	{
		protected string loginName;
		protected string password;
		protected string firstName;
		protected string secondName;
		protected string lastName;
		protected string typeUser;
		public ApplicationUser (string loginName, string password, string firstName, 
								string secondName, string lastName, string typeUser) 
		{
			this.loginName = loginName;
			this.password = password;
			this.firstName = firstName;
			this.secondName = secondName;
			this.lastName = lastName;
			this.typeUser = typeUser;
		}
		public static ApplicationUser InputFromFile (string fileName)
		{
			
		}
		public string LoginName 
		{
			get { return loginName; }
			set { loginName = value; }
		}
		public string Password 
		{
			get { return password; }
			set { password = value; }
		}
		public string FirstName 
		{
			get { return firstName; }
			set { firstName = value; }
		}
		public string SecondName 
		{
			get { return secondName; }
			set { secondName = value; }
		}
		public string LastName 
		{
			get { return lastName; }
			set { lastName = value; }
		}
		public string TypeUser 
		{
			get { return typeUser; }
			set { typeUser = value; }
		}
	}

}
