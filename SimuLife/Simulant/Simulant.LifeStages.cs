namespace SimuLife {
	partial class Simulant {
		public enum LifeStages {
			Concieved,  Fetus, Baby,
			Toddler,    Child, Teen,
			YoungAdult,	Adult, OldAdult,
			Senior,     Elder, Ancient
		}
		public      LifeStages LifeStage => (int)(Simulator.Time - TimeOfBirth) switch {
			int n when n > 33600 => LifeStages.Ancient,
			int n when n > 26880 => LifeStages.Elder,
			int n when n > 20832 => LifeStages.Senior,
			int n when n > 15456 => LifeStages.OldAdult,
			int n when n > 10752 => LifeStages.Adult,
			int n when n > 6720  => LifeStages.YoungAdult,
			int n when n > 4032  => LifeStages.Teen,
			int n when n > 2016  => LifeStages.Child,
			int n when n > 672   => LifeStages.Toddler,
			int n when n > 0     => LifeStages.Baby,
			int n when n > -25   => LifeStages.Fetus,
			_					 => LifeStages.Concieved
		};
	}
}
