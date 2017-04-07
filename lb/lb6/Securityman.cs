using System;
using System.Collections.Generic;

namespace Laba6 
{

	class Securityman : ApplicationUser
	{
		private List<string> numbersDocuments;
		public Securityman (string loginName, string password, string firstName, string secondName, string lastName)
							: base (loginName, password, firstName, secondName, lastName, "Securityman")
		{
			numbersDocuments = new List<string>();
			// *тут должна быть загрузка с сервера/базы данных списка номеров пропускных документов*
		}
		public List<string> NumbersDocuments
		{
			get { return numbersDocuments; }
			set { numbersDocuments = value; }
		}
		public bool CheckDocument (string numberDocument)
		{
			for (int i = 0; i < numbersDocuments.Count; ++i)
				if (numbersDocuments[i] == numberDocument)
					return true;
			return false;
		}
	}
	
}
