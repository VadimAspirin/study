using System;
using System.Collections.Generic;

namespace Laba6 
{

	class Deanery : ApplicationUser
	{
		private List<string> applications;
		public Deanery (string loginName, string password, string firstName, string secondName, string lastName)
						: base (loginName, password, firstName, secondName, lastName, "Deanery") 
		{
			applications = new List<string>();
			// *тут должна быть загрузка с сервера/базы данных списка 
			//					запросов на восстановление пропускного документа*
		}
		public List<string> Applications
		{
			get { return applications; }
			set { applications = value; }
		}
		public void ConsiderApplication (string numberApplication)
		{
			// *тут должно быть удаление, с сервера/базы данных, логина пользователя из списка заявок*
			applications.Remove (numberApplication);
		}
	}
	
}
