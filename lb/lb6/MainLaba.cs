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

			List<Watchman> watchmans = new List<Watchman>();
			watchmans = InputFromFile.Watchmans ("./Data/Watchmans.txt", "./Data/Classrooms.txt", "./Data/Lockers.txt");
			Console.WriteLine (watchmans[0].LoginName);
			Console.WriteLine (watchmans[1].Classrooms[1].Number);
			Console.WriteLine (watchmans[1].Classrooms[1].DocumentTeacherHavingKey == "");
			Console.WriteLine (watchmans[1].Classrooms[4].Number);
			Console.WriteLine (watchmans[1].Classrooms[4].Lockers.Count);
			
			Console.WriteLine ("-----------------------------------------");
			
			//List<object> g = new List<object>();
			ArrayList g = new ArrayList();
			object g1;
			g.Add (new Student ("anton", "udhw7w7ddwd3f", "Ерохин", "Антон", "Сергеевич", pass, "iit", "bi607"));
			g.Add (new Teacher ("ivaaan", "wef3frwewe", "Иванов", "Иван", "Иванович", pass, "iit"));
			g1 = g[1];
			Console.WriteLine (g1);
			g.Clear();
			Console.WriteLine (((ApplicationUser)g1).LoginName);
			//Console.WriteLine (g[1].Department);
			
			Console.WriteLine ("-----------------------------------------");
			
			SystemOfPassesAndClassroomsKeys sys = new SystemOfPassesAndClassroomsKeys ("ivan0212", "qwf23ef");
			Console.WriteLine(((ApplicationUser)sys.User).LoginName);
			Console.WriteLine(((ApplicationUser)sys.User).TypeUser);
			Console.WriteLine(sys.requestDocumentRecovery.Count);
			((Student)sys.User).NewPass();
			Console.WriteLine(sys.requestDocumentRecovery.Count);
			if (sys.requestDocumentRecovery.Count > 0)
				Console.WriteLine (sys.requestDocumentRecovery[0]);
			
		}
	}
	
}
