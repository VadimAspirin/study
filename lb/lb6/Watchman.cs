using System;
using System.Collections.Generic;

namespace Laba6 
{

	class Watchman : ApplicationUser
	{
		private List<Classroom> classrooms;
		public Watchman (string loginName, string password, string firstName, string secondName, string lastName)
						 : base (loginName, password, firstName, secondName, lastName, "Watchman") 
		{
			classrooms = new List<Classroom>();
			// *тут должна быть загрузка с сервера/базы данных списка аудиторий*
		}
		public List<Classroom> Classrooms
		{
			get { return classrooms; }
			set { classrooms = value; }
		}
		private bool CheckExistence (string numberClassroom)
		{
			for (int i = 0; i < classrooms.Count; ++i)
				if (classrooms[i].Number == numberClassroom)
					return true;
			return false;
		}
		public bool CheckAvailabilityClassroom (string numberDocument, string numberClassroom)
		{
			if (!CheckExistence (numberClassroom))
				throw new ArgumentException ("error: Кабинет несуществует");
			bool flag = false;
			int i;
			for (i = 0; i < classrooms.Count; i++)
				if (classrooms[i].Number == numberClassroom && classrooms[i].TeacherHavingKey == null)
					flag = true;
			for (int j = 0; j < classrooms[i].DocumentNumbers.Count; ++j)
				if (classrooms[i].DocumentNumbers[j] == numberDocument && flag)
					return true;
			return false;
		}
		public Teacher CheckWhereIsKey (string numberClassroom)
		{
			if (!CheckExistence (numberClassroom))
				throw new ArgumentException ("error: Кабинет несуществует");
			for (int i = 0; i < classrooms.Count; ++i)
				if (classrooms[i].Number == numberClassroom)
					return classrooms[i].TeacherHavingKey;
			return null;
		}
	}
	
}
