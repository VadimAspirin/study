using System;
using System.Collections.Generic;

namespace Laba6 
{

	class Watchman : ApplicationUser
	{
		private List<Classroom> classrooms;
		public Watchman (string loginName, string password, string firstName, string secondName, string lastName)
						 : base (loginName, password, firstName, secondName, lastName, "Watchman") {}
		public List<Classroom> Classrooms
		{
			get { return classrooms; }
			set { classrooms = value; }
		}
		private int CheckExistence (string numberClassroom)
		{
			for (int i = 0; i < classrooms.Count; ++i)
				if (classrooms[i].Number == numberClassroom)
					return i;
			throw new ArgumentException ("error: Кабинет несуществует");
		}
		public void KeyIssued (string numberDocument, string numberClassroom)
		{
			int i = CheckExistence (numberClassroom);
			if (classrooms[i].DocumentTeacherHavingKey != "")
				throw new ArgumentException ("error: Кабинет занят или ключ забыли вернуть");
			for (int j = 0; j < classrooms[i].DocumentNumbers.Count; ++j)
				if (classrooms[i].DocumentNumbers[j] == numberDocument)
				{
					classrooms[i].DocumentTeacherHavingKey = numberDocument;
					return;
				}
			throw new ArgumentException ("error: Нет доступа к кабинету");
		}
		public void KeyReturned (string numberClassroom)
		{
			int i = CheckExistence (numberClassroom);
			if (classrooms[i].DocumentTeacherHavingKey != "")
				classrooms[i].DocumentTeacherHavingKey = "";
			else
				throw new ArgumentException ("error: Ключ уже возвращён или небыл взят");
		}
		public bool CheckAvailabilityLocker (string numberDocument, string numberClassroom, string numberLocker)
		{
			int i = CheckExistence (numberClassroom);
			if (classrooms[i].Lockers.Count == 0)
				throw new ArgumentException ("error: У кабинета нет шкафов");
			int j = -1;
			for (j = 0; j < classrooms[i].Lockers.Count; i++)
				if (classrooms[i].Lockers[j].Number == numberLocker)
					break;
			if (j == -1)
				throw new ArgumentException ("error: У кабинета нет шкафа под данным номером");
			for (int y = 0; y < classrooms[i].Lockers[j].DocumentNumbers.Count; y++)
				if (classrooms[i].Lockers[j].DocumentNumbers[y] == numberDocument)
					return true;
			return false;
		}
		public string CheckWhereIsKey (string numberClassroom)
		{
			return classrooms[CheckExistence(numberClassroom)].DocumentTeacherHavingKey;
		}
	}
	
}
