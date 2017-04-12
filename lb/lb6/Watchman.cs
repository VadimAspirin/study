using System;
using System.Collections.Generic;

namespace Laba6 
{

	class Watchman : ApplicationUser
	{
		private List<Classroom> classrooms;
		public Watchman (string loginName, string password, string firstName, string secondName, string lastName, List<Classroom> classrooms)
						 : base (loginName, password, firstName, secondName, lastName, "Watchman") 
		{
			this.classrooms = classrooms;
		}
		public List<Classroom> Classrooms
		{
			get { return classrooms; }
			set { classrooms = value; }
		}
		private void CheckExistence (string numberClassroom)
		{
			for (int i = 0; i < classrooms.Count; ++i)
				if (classrooms[i].Number == numberClassroom)
					return;
			throw new ArgumentException ("error: Кабинет несуществует");
		}
		public void KeyIssued (string numberDocument, string numberClassroom)
		{
			CheckExistence (numberClassroom);
			int i;
			for (i = 0; i < classrooms.Count; i++)
				if (classrooms[i].Number == numberClassroom)
					break;
			if (classrooms[i].TeacherHavingKey != null)
				throw new ArgumentException ("error: Кабинет занят или ключ забыли вернуть");
			for (int j = 0; j < classrooms[i].DocumentNumbers.Count; ++j)
				if (classrooms[i].DocumentNumbers[j] == numberDocument)
				{
					// По номеру документа найти Teacher и присвоить classrooms[i].TeacherHavingKey
				}
			throw new ArgumentException ("error: Нет доступа к кабинету");
		}
		public void KeyReturned (string numberClassroom)
		{
			CheckExistence (numberClassroom);
			for (int i = 0; i < classrooms.Count; i++)
			{
				if (classrooms[i].Number == numberClassroom)
				{
					if (classrooms[i].TeacherHavingKey != null)
					{
						classrooms[i].TeacherHavingKey = null;
					}
					else
					{
						throw new ArgumentException ("error: Ключ уже возвращён или небыл взят");
					}
				}
			}
		}
		public void CheckAvailabilityLocker (string numberDocument, string numberClassroom, string numberLocker)
		{
		
		}
		public Teacher CheckWhereIsKey (string numberClassroom)
		{
			CheckExistence (numberClassroom);
			for (int i = 0; i < classrooms.Count; ++i)
				if (classrooms[i].Number == numberClassroom)
					return classrooms[i].TeacherHavingKey;
			return null;
		}
	}
	
}
