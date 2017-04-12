using System;
using System.Collections.Generic;
using System.Collections;

namespace Laba6 
{
	delegate void DlgAddRequestDocumentRecovery (string loginName);	

	class SystemOfPassesAndClassroomsKeys
	{
		private List<string> requestDocumentRecovery;
		private ArrayList users;
		public SystemOfPassesAndClassroomsKeys (string loginName, string password)
		{
			requestDocumentRecovery = new List<string>();
			users = new ArrayList();
			users.AddRange (InputFromFile.Students ("./Data/Students.txt"));
			users.AddRange (InputFromFile.Teachers ("./Data/Teachers.txt"));
//			users.AddRange (InputFromFile.Students ("./Data/Watchmans.txt", "./Data/Classrooms.txt", "./Data/Lockers.txt"));
//			users.AddRange (InputFromFile.Teachers ("./Data/Securitymans.txt"));
//			users.AddRange (InputFromFile.Students ("./Data/Deanerys.txt"));
//			users.AddRange (InputFromFile.Teachers ("./Data/Admins.txt"));
			LogIn (loginName, password);
		}
		private void AddRequestDocumentRecovery (string loginName)
		{
			if (!requestDocumentRecovery.Contains (loginName))
				throw new ArgumentException ("error: Запрос на восстановление пропускного документа уже поступал от данного пользователя");
			requestDocumentRecovery.Add (loginName);
		}
		private void DelRequestDocumentRecovery (string loginName)
		{
			if (requestDocumentRecovery.Contains (loginName))
				throw new ArgumentException ("error: Запрос на восстановление пропускного документа уже был обработан или ещё не поступал от данного пользователя");
			requestDocumentRecovery.Remove (loginName);
		}
		public List<string> RequestDocumentRecovery
		{
			get { return requestDocumentRecovery; }
		}
		private void LogIn (string loginName, string password)
		{
			for (int i = 0; i < users.Count; ++i)
				if (((ApplicationUser)users[i]).LoginName == loginName && ((ApplicationUser)users[i]).Password == password)
				{
					//Присвоить найденного пользователя переменной и очистить users
					return;
				}
			throw new ArgumentException ("error: Неверный логин или пароль");
		}

	}
	
}
