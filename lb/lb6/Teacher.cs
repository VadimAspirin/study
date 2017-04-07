using System;

namespace Laba6 
{

	class Teacher : ApplicationUser
	{
		private Pass document;
		private string department;
		public Teacher (string loginName, string password, string firstName, string secondName, string lastName,
						Pass document, string department)
						: base (loginName, password, firstName, secondName, lastName, "Teacher") 
		{
			this.document = document;
			this.department = department;
		}
		public Pass Document 
		{
			get { return document; }
			set { document = value; }
		}
		public string Department 
		{
			get { return department; }
			set { department = value; }
		}
		public void NewPass ()
		{
			// *тут должна быть запись, на сервера/базу данных, логина пользователя в список заявок*
		}
	}
	
}
