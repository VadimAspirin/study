using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Laba6 
{

	class InputFromFile 
	{
		private static List<Dictionary<string, string>> readFileLine (string fileName)
		{	
			List<Dictionary<string, string>> readFileLine = new List<Dictionary<string, string>>();
			List<string> keys = new List<string>();
			using (StreamReader sr = new StreamReader(fileName))
			{
				for (int i = -1; true; i++)
				{	
					string buf = sr.ReadLine();
					if (buf == null)
						break;
					Regex reg = new Regex ("\\S+");
					MatchCollection regMC = reg.Matches(buf);
					if (i == -1)
					{
						for (int j = 0; j < regMC.Count; j++)
						{
							keys.Add (regMC[j].Value);
						}
					}
					else
					{
						readFileLine.Add (new Dictionary<string, string>());
						if (keys.Count != regMC.Count)
							throw new ArgumentException ("error: Некорректные данные в файле: " + fileName);
						for (int j = 0; j < regMC.Count; j++)
						{
							readFileLine[i].Add (keys[j], regMC[j].Value);
						}
					}
				}
			}
			return readFileLine;
		
		}
		private static List<string> outputLineToList (string line)
		{
			List<string> listBuf = new List<string>();
			Regex reg = new Regex ("[^,]");
			MatchCollection mc = reg.Matches(line);
			for (int i = 0; i < mc.Count; ++i)
				listBuf.Add (mc[i].Value);
			return listBuf;
		}
		public static List<Student> Students (string fileName)
		{	
			List<Dictionary<string, string>> rfl = readFileLine (fileName);
			List<Student> students = new List<Student>();
			for (int i = 0; i < rfl.Count; i++)
			{
				if (!(rfl[i].ContainsKey("loginName") && rfl[i].ContainsKey("password") && 
					  rfl[i].ContainsKey("firstName") && rfl[i].ContainsKey("secondName") && 
					  rfl[i].ContainsKey("lastName") && rfl[i].ContainsKey("faculty") && 
					  rfl[i].ContainsKey("group") && rfl[i].ContainsKey("numberPass") && 
					  rfl[i].ContainsKey("expirationTimePass")))
					throw new ArgumentException ("error: Некорректные данные в файле: " + fileName);
				Pass passUser = new Pass (rfl[i]["numberPass"], Date.StringInDate (rfl[i]["expirationTimePass"]));
				students.Add (new Student (rfl[i]["loginName"], rfl[i]["password"], rfl[i]["firstName"], 
										   rfl[i]["secondName"], rfl[i]["lastName"], passUser, 
										   rfl[i]["faculty"], rfl[i]["group"]));
			}
			return students;
		}
		public static List<Teacher> Teachers (string fileName)
		{	
			List<Dictionary<string, string>> rfl = readFileLine (fileName);
			List<Teacher> teachers = new List<Teacher>();
			for (int i = 0; i < rfl.Count; i++)
			{
				if (!(rfl[i].ContainsKey("loginName") && rfl[i].ContainsKey("password") && 
					  rfl[i].ContainsKey("firstName") && rfl[i].ContainsKey("secondName") && 
					  rfl[i].ContainsKey("lastName") && rfl[i].ContainsKey("department") && 
					  rfl[i].ContainsKey("numberPass") && rfl[i].ContainsKey("expirationTimePass")))
					throw new ArgumentException ("error: Некорректные данные в файле: " + fileName);
				Pass passUser = new Pass (rfl[i]["numberPass"], Date.StringInDate (rfl[i]["expirationTimePass"]));
				teachers.Add (new Teacher (rfl[i]["loginName"], rfl[i]["password"], rfl[i]["firstName"], 
										   rfl[i]["secondName"], rfl[i]["lastName"], passUser, 
										   rfl[i]["department"]));
			}
			return teachers;
		}
		public static List<Watchman> Watchmans (string fileNameWatchmans, string fileNameClassrooms, string fileNameLockers)
		{	
			List<Dictionary<string, string>> readFileLineWatchmans = readFileLine (fileNameWatchmans);
			List<Dictionary<string, string>> readFileLineClassrooms = readFileLine (fileNameClassrooms);
			List<Dictionary<string, string>> readFileLineLockers = readFileLine (fileNameLockers);
			List<Watchman> watchmans = new List<Watchman>();
			List<Classroom> classrooms = new List<Classroom>();
			for (int i = 0; i < readFileLineClassrooms.Count; i++)
			{
				if (!(readFileLineClassrooms[i].ContainsKey("classroomNumber") && 
					  readFileLineClassrooms[i].ContainsKey("documentNumbers")))
					throw new ArgumentException ("error: Некорректные данные в файле: " + fileNameClassrooms);
				List<Locker> lokers = new List<Locker>();
				for (int j = 0; j < readFileLineLockers.Count; j++)
				{
					if (!(readFileLineLockers[j].ContainsKey("classroomNumber") && 
						  readFileLineLockers[j].ContainsKey("lokerNumber") &&
						  readFileLineLockers[j].ContainsKey("documentNumbers")))
						throw new ArgumentException ("error: Некорректные данные в файле: " + fileNameLockers);
					if (readFileLineClassrooms[i]["classroomNumber"] == readFileLineLockers[j]["classroomNumber"])
						lokers.Add ( new Locker (readFileLineLockers[j]["lokerNumber"], 
												 outputLineToList (readFileLineLockers[j]["documentNumbers"])));
				}
				classrooms.Add ( new Classroom (readFileLineClassrooms[i]["classroomNumber"],
												outputLineToList (readFileLineClassrooms[i]["documentNumbers"]),
												lokers));
			}
			for (int i = 0; i < readFileLineWatchmans.Count; i++)
			{
				if (!(readFileLineWatchmans[i].ContainsKey("loginName") && readFileLineWatchmans[i].ContainsKey("password") && 
					  readFileLineWatchmans[i].ContainsKey("firstName") && readFileLineWatchmans[i].ContainsKey("secondName") && 
					  readFileLineWatchmans[i].ContainsKey("lastName")))
					throw new ArgumentException ("error: Некорректные данные в файле: " + fileNameWatchmans);
				watchmans.Add (new Watchman (readFileLineWatchmans[i]["loginName"], readFileLineWatchmans[i]["password"], 
											 readFileLineWatchmans[i]["firstName"], readFileLineWatchmans[i]["secondName"], 
											 readFileLineWatchmans[i]["lastName"], classrooms));
			}
			return watchmans;
		}
	}
	
}
