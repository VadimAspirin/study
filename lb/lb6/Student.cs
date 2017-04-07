using System;

namespace Laba6 
{

	class Student : ApplicationUser
	{
		private Pass document;
		private string faculty;
		private string group;
		public Student (string loginName, string password, string firstName, string secondName, string lastName,
						Pass document, string faculty, string group)
						: base (loginName, password, firstName, secondName, lastName, "Student") 
		{
			this.document = document;
			this.faculty = faculty;
			this.group = group;
		}
		public Pass Document 
		{
			get { return document; }
			set { document = value; }
		}
		public string Faculty 
		{
			get { return faculty; }
			set { faculty = value; }
		}
		public string Group 
		{
			get { return group; }
			set { group = value; }
		}
	}
	
}
