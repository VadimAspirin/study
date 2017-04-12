using System;
using System.Collections.Generic;
using System.Collections;

namespace Laba6 
{
	delegate void DlgAddRequestDocumentRecovery (string loginName);
	delegate void DlgDelRequestDocumentRecovery (string loginName);	

	class SystemOfPassesAndClassroomsKeys
	{
		private ArrayList users;
		private object user;
		private List<string> requestDocumentRecovery;
		private List<Classroom> classrooms;
		public SystemOfPassesAndClassroomsKeys (string loginName, string password)
		{
			requestDocumentRecovery = new List<string>();
			users = new ArrayList();
			classrooms = InputFromFile.Classrooms ("./Data/Classrooms.txt", "./Data/Lockers.txt");
			users.AddRange (InputFromFile.Students ("./Data/Students.txt"));
			users.AddRange (InputFromFile.Teachers ("./Data/Teachers.txt"));
			users.AddRange (InputFromFile.Watchmans ("./Data/Watchmans.txt"));
			users.AddRange (InputFromFile.Securitymans ("./Data/Securitymans.txt"));
			users.AddRange (InputFromFile.Deanerys ("./Data/Deanerys.txt"));
			users.AddRange (InputFromFile.Admins ("./Data/Admins.txt"));
			LogIn (loginName, password);
		}
		private void AddRequestDocumentRecovery (string loginName)
		{
			if (requestDocumentRecovery.Contains (loginName))
				throw new ArgumentException ("error: Запрос на восстановление пропускного документа уже поступал от данного пользователя");
			requestDocumentRecovery.Add (loginName);
		}
		private void DelRequestDocumentRecovery (string loginName)
		{
			if (!requestDocumentRecovery.Contains (loginName))
				throw new ArgumentException ("error: Запрос на восстановление пропускного документа уже был обработан или ещё не поступал от данного пользователя");
			requestDocumentRecovery.Remove (loginName);
		}
		public List<string> RequestDocumentRecovery
		{
			get { return requestDocumentRecovery; }
		}
		public object User
		{
			get { return user; }
			set { user = value; }
		}
		private void createTypeUserComponents ()
		{
			if (((ApplicationUser)user).TypeUser == "Student")
				((Student)user).StartDlgAddRequestDocumentRecovery += AddRequestDocumentRecovery;
			if (((ApplicationUser)user).TypeUser == "Teacher")
				((Teacher)user).StartDlgAddRequestDocumentRecovery += AddRequestDocumentRecovery;
			if (((ApplicationUser)user).TypeUser == "Watchman")
				((Watchman)user).Classrooms = classrooms;
			if (((ApplicationUser)user).TypeUser == "Securityman")
			{
				List<string> documentNumbers = new List<string>();
				for (int i = 0; i < users.Count; i++)
				{
					if (((ApplicationUser)users[i]).TypeUser == "Student")
						documentNumbers.Add (((Student)users[i]).Document.Number);
					if (((ApplicationUser)users[i]).TypeUser == "Teacher")
						documentNumbers.Add (((Teacher)users[i]).Document.Number);
				}
				((Securityman)user).NumbersDocuments = documentNumbers;
			}
			if (((ApplicationUser)user).TypeUser == "Deanery")
				((Deanery)user).StartDlgDelRequestDocumentRecovery += DelRequestDocumentRecovery;
		}
		private void LogIn (string loginName, string password)
		{
			for (int i = 0; i < users.Count; ++i)
				if (((ApplicationUser)users[i]).LoginName == loginName && ((ApplicationUser)users[i]).Password == password)
				{
					user = users[i];
					createTypeUserComponents ();
					return;
				}
			throw new ArgumentException ("error: Неверный логин или пароль");
		}

	}
	
}
