using System.Collections.Generic;
using System.Text;

namespace SimuLife {
	static class Simulator {
		public static Time TimeNow	{ get; private set; }
		public static Time TimeNext { get; private set; }
		
		static Simulator() {
			TimeNow  = new Time(Time.Hours.Night,     Time.Days.Monday, Time.Seasons.Winter, 420);
			TimeNext = new Time(Time.Hours.LateNight, Time.Days.Monday, Time.Seasons.Winter, 420);
		}
	}
}
