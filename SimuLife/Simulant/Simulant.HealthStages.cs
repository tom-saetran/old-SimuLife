namespace SimuLife {
	partial class Simulant {
		public enum HealthStages {
			Dead,
			Alive
		}

		public HealthStages HealthStage =>
			TimeCard.GetDifferenceInTicks(TimeOfDeath, Simulator.TimeNow) > 0 ?
				HealthStages.Alive : HealthStages.Dead;
	}
}
