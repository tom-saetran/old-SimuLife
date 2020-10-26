namespace SimuLife {
	static class Simulator {

		public static uint Time { get; private set; }
		public static TimeCard TimeNow => TimeCard.GetTimeCardFromTicks(Time);

		static Simulator () {
			Time = TimeCard.GetTicksFromTimeCard(new TimeCard(0,0,0,420));
		}

		public enum Events {
			AdvanceTime,
			NewYear,
			Spring,
			MidSummer,
			Harvest,
			Christmas
		}
		public static void StartEvent (Events _event) {
			switch (_event) {
				case Events.AdvanceTime:
					Time++;
					break;
			}
		}
	}
}
