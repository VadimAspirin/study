using System;
using System.Collections.Generic;
using System.Collections;

namespace Laba6 
{

	class Admin : ApplicationUser
	{
		private ArrayList users;
		private List<Classroom> classrooms;
		public Admin (string loginName, string password, string firstName, string secondName, string lastName)
					  : base (loginName, password, firstName, secondName, lastName, "Admin") 
		{
			users = new ArrayList();
			// *тут должна быть загрузка с сервера/базы данных списка пользователей*
			classrooms = new List<Classroom>();
			// *тут должна быть загрузка с сервера/базы данных списка аудиторий*
		}
		public ArrayList Users
		{
			get { return users; }
			set { users = value; }
		}
		public List<Classroom> Classrooms
		{
			get { return classrooms; }
			set { classrooms = value; }
		}
		public void AddUser (ArrayList data)
		{
			// *тут должна быть загрузка на сервер/базу данных нового пользователя*
		}
		public void DelUser (string loginName)
		{
			// *тут должно быть удаление с сервера/базы данных пользователя*
		}
		public void ChangeUser (string loginName, ArrayList data)
		{
			DelUser (loginName);
			AddUser (data);
		}
		public void ChangeAvailabilityClassroom (ArrayList data)
		{
			// *тут должна быть загрузка на сервер/базу данных изменённых данных аудитории*
		}
	}
	
}
