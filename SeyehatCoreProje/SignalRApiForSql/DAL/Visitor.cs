﻿namespace SignalRApiForSql.DAL
{

	public enum ECity
	{
		Manisa = 1,
		İstanbul = 2,
		Ankara = 3,
		Sakarya = 4,
		Antalya = 5
	}
	public class Visitor
	{
		public int VisitorID { get; set; }
		public ECity City { get; set; }
		public int CityVisitCount { get; set; }
		public DateTime? VisitDate { get; set; }

	}
}
