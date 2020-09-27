using System;
using System.Collections.Generic;
using System.Text;

namespace SimuLife {

	class Name {
		public string FirstName { get; protected set; }
		public string LastName { get; protected set; }
		public Name(string firstName, string lastName) {
			FirstName = firstName;
			LastName = lastName;
		}
	}
	class TimeStamp {
		public enum Hours {
			Night,
			LateNight,
			EarlyMorning,
			Morning,
			LateMorning,
			EarlyDay,
			Day,
			LateDay,
			EarlyEvening,
			Evening,
			LateEvening,
			EarlyNight
		}
		public enum Days {
			Monday,
			Tuesday,
			Wednesday,
			Thursday,
			Friday,
			Saturday,
			Sunday
		}
		public enum Seasons {
			Winter,
			Spring,
			Summer,
			Autumn
		}
		public Hours Hour { get; protected set; }
		public Days Day { get; protected set; }
		public Seasons Season { get; protected set; }
		public uint Year { get; protected set; }
		public TimeStamp() {
			Hour = Hours.Night;
			Day = Days.Monday;
			Season = Seasons.Spring;
			Year = 420;
		}
		public TimeStamp(Hours hour, Days day, Seasons season, uint year) {
			Hour = hour;
			Day = day;
			Season = season;
			Year = year;
		}
	}

	class Simulant {
		public enum Genders {
			Female,
			Male
		}
		public Simulant ParentFemale { get; protected set; }
		public Simulant ParentMale { get; protected set; }
		public Name Name { get; protected set;}
		public TimeStamp ConceptionTimeStamp { get; protected set; }
		public TimeStamp BirthTimeStamp { get; protected set; }
		public TimeStamp DeathTimeStamp { get; protected set; }
		public Genders Gender { get; protected set; }
		public Simulant(Simulant parentFemale, Simulant parentMale) {
			ParentFemale = parentFemale;
			ParentMale = parentMale;
			Name = new Name("First Name", "Last Name");
			ConceptionTimeStamp = new TimeStamp();
			BirthTimeStamp = new TimeStamp();
			DeathTimeStamp = new TimeStamp();
			Gender = new Random().NextDouble() > 0.5 ? Genders.Female : Genders.Male;
		}
	}
}
