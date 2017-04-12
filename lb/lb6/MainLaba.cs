using System;
using System.Collections.Generic;
using System.Collections;

namespace Laba6 
{

	class MainLaba 
	{
		static void Main () 
		{
			Date date = new Date (1996, 2, 29);
			Pass pass = new Pass ("8hHJ992ffoA", date);
			Console.WriteLine (pass.Number);
			
			List<string> teacherNumbers = new List<string>(){"8hHJ992ffoA", "98jhHDW5th2"};
			List<Locker> lokers = new List<Locker>();
			lokers.Add (new Locker ("k1", teacherNumbers));
			Classroom classroom = new Classroom ("n1", teacherNumbers, lokers);
			Console.WriteLine (classroom.Lockers[0].DocumentNumbers[1]);
			classroom.TeacherHavingKey = new Teacher ("ivaaan", "wef3frwewe", "Иванов", "Иван", "Иванович", pass, "iit");
			Console.WriteLine (classroom.TeacherHavingKey.FirstName);
			
			ArrayList users = new ArrayList();
			users.Add (new Teacher ("ivaaan", "wef3frwewe", "Иванов", "Иван", "Иванович", pass, "iit"));
			users.Add (new Student ("anton", "udhw7w7ddwd3f", "Ерохин", "Антон", "Сергеевич", pass, "iit", "bi607"));
			Console.WriteLine (((Teacher)users[0]).Department);
			Console.WriteLine (((Student)users[1]).Group);
			Console.WriteLine (((ApplicationUser)users[0]).LoginName);
			
			List<string> xxx = teacherNumbers;
			Console.WriteLine (xxx.Count);
			teacherNumbers.Add ("123");
			Console.WriteLine (xxx.Count);
			var xx = new Date (1996, 2, 29);
			Console.WriteLine (xx.Year);
			
			Console.WriteLine ("-----------------------------------------");

			List<Teacher> teachers = new List<Teacher>();
			teachers = InputFromFile.Teachers ("./Data/Teachers.txt");
			Console.WriteLine (teachers[1].Document.Number);
			Console.WriteLine (teachers[1].Document.ExpirationTime.Year);
			Console.WriteLine (teachers[2].Department);
			
			Console.WriteLine ("-----------------------------------------");

			List<Watchman> watchmans = new List<Watchman>();
			watchmans = InputFromFile.Watchmans ("./Data/Watchmans.txt", "./Data/Classrooms.txt", "./Data/Lockers.txt");
			Console.WriteLine (watchmans[0].LoginName);
			Console.WriteLine (watchmans[1].Classrooms[1].Number);
			Console.WriteLine (watchmans[1].Classrooms[1].TeacherHavingKey == null);
			Console.WriteLine (watchmans[1].Classrooms[4].Number);
			Console.WriteLine (watchmans[1].Classrooms[4].Lockers.Count);
			watchmans[1].KeyReturned ("a13");
		}
	}
	
}
