﻿namespace SimuLife {
	partial class TimeCard {
		public Hours   Hour		{ get; protected set; }
		public Days    Day		{ get; protected set; }
		public Seasons Season	{ get; protected set; }
		public uint    Year		{ get; protected set; }

		public const short NumHours   = 12;
		public const short NumDays    =  7;
		public const short NumSeasons =  4;

		public TimeCard (Hours hour, Days day, Seasons season, uint year) {
			Hour   = hour;
			Day    = day;
			Season = season;
			Year   = year;
		}
		public TimeCard (TimeCard time) {
			Hour   = time.Hour;
			Day    = time.Day;
			Season = time.Season;
			Year   = time.Year;
		}
	}
}