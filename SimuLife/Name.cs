namespace SimuLife {
	class Name {
		public string FirstName { get; protected set; }
		public string LastName	{ get; protected set; }

		public Name (string firstName, string lastName) {
			FirstName = firstName;
			LastName = lastName;
		}
	}
}
