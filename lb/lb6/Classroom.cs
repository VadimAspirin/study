using System;
using System.Collections.Generic;

namespace Laba6 
{

	class Classroom 
	{
		public readonly string Number;
		private List<string> documentNumbers;
		private List<Locker> lokers;
		private Teacher teacherHavingKey;
		public Classroom (string number, List<string> documentNumbers, List<Locker> lokers)
		{
			Number = number;
			this.documentNumbers = documentNumbers;
			this.lokers = lokers;
			teacherHavingKey = null;
		}
		public List<string> DocumentNumbers
		{
			get { return documentNumbers; }
			set { documentNumbers = value; }
		}
		public List<Locker> Lockers
		{
			get { return lokers; }
			set { lokers = value; }
		}
		public Teacher TeacherHavingKey
		{
			get { return teacherHavingKey; }
			set { teacherHavingKey = value; }
		}
	}
	
}
