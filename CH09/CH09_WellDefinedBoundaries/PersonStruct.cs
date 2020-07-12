namespace CH09_WellDefinedBoundaries
{
    public struct PersonStruct
    {
        private readonly string _firstName;
        private readonly string _lastName;

        public PersonStruct(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public string FirstName => _firstName;
        public string LastName => _lastName;
    }
}
