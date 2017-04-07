using System;

namespace Laba6 
{

	class Date 
	{
		private int year;
		private int month;
		private int day;
		public Date (int year, int month, int day)
		{
			if (year < 1)
			{
				throw new ArgumentException ("error: Неверно задана дата");
			}
			if (month == 1 || month == 3 || month == 5 || month == 7 || 
				month == 8 || month == 10 || month == 12) 
			{ 
				// 31 день
				if (day > 31 || day < 1) 
				{
					throw new ArgumentException ("error: Неверно задана дата");
				}
			}
			else if (month == 4 || month == 6 || month == 9 || month == 11) 
			{ 	// 30 дней
				if (day > 30 || day < 1) 
				{
					throw new ArgumentException ("error: Неверно задана дата");
				}
			}
			// февраль
			else if (month == 2) 
			{
				//високосный год
				if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0) 
				{
					if (day > 29 || day < 1) 
					{
						throw new ArgumentException ("error: Неверно задана дата");
					}
				}
				//не високосный год
				else 
				{
					if (day > 28 || day < 1) 
					{
						throw new ArgumentException ("error: Неверно задана дата");
					}
				}
			}
			else 
			{
				throw new ArgumentException ("error: Неверно задана дата");
			}
			this.year = year;
			this.month = month;
			this.day = day;
		}
		public int Year
		{
			get { return year; }
		}
		public int Month
		{
			get { return month; }
		}
		public int Day
		{
			get { return day; }
		}
	}
	
}
