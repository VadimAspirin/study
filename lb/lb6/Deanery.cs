using System;
using System.Collections.Generic;

namespace Laba6 
{

	class Deanery : ApplicationUser
	{
		public event DlgDelRequestDocumentRecovery StartDlgDelRequestDocumentRecovery;
		
		public Deanery (string loginName, string password, string firstName, string secondName, string lastName)
						: base (loginName, password, firstName, secondName, lastName, "Deanery") {}
		public void ConsiderApplication (string numberApplication)
		{
			StartDlgDelRequestDocumentRecovery (numberApplication);
		}
	}
	
}
