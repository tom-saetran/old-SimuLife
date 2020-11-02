namespace SimuLife {
	partial class Simulant {
		public enum Genders {
			Female,
			Male
		}
		public      Genders Gender { get; }

		public enum IQs {
			SeverelyRetarded,
			Retarded,
			SlightlyRetarded,
			Normal,
			High,
			VeryHigh,
			Genious,
			Savant,
			Omnipotent
		}
		public      IQs IQ => IQLevel switch {
			ushort n when n > 220 => IQs.Omnipotent,
			ushort n when n > 185 => IQs.Savant,
			ushort n when n > 165 => IQs.Genious,
			ushort n when n > 135 => IQs.VeryHigh,
			ushort n when n > 115 => IQs.High,
			ushort n when n > 80  => IQs.Normal,
			ushort n when n > 65  => IQs.SlightlyRetarded,
			ushort n when n > 45  => IQs.Retarded,
			_                     => IQs.SeverelyRetarded
		};
	}
}

