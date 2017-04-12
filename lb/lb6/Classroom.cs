using System;
using System.Collections.Generic;

namespace Laba6 
{

	class Classroom 
	{
		public readonly string Number;
		private List<string> documentNumbers;
		private List<Locker> lokers;
		private string documentTeacherHavingKey;
		public Classroom (string number, List<string> documentNumbers, List<Locker> lokers)
		{
			Number = number;
			this.documentNumbers = documentNumbers;
			this.lokers = lokers;
			documentTeacherHavingKey = "";
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
		public string DocumentTeacherHavingKey
		{
			get { return documentTeacherHavingKey; }
			set { documentTeacherHavingKey = value; }
		}
	}
	
}
