namespace CH3.ImmutableObjectsAndDataStructures
{
    /// <summary>
    /// Immutable object
    /// </summary>
    public class Person
    {
        private readonly int _id;
        private readonly string _firstName;
        private readonly string _lastName;

        /// <summary>
        /// Gets person's unique identifier.
        /// </summary>
        public int Id => _id;
        /// <summary>
        /// Gets person's first name.
        /// </summary>
        public string FirstName => _firstName;
        /// <summary>
        /// Gets person's last name.
        /// </summary>
        public string LastName => _lastName;
        /// <summary>
        /// Gets person's full name.
        /// </summary>
        public string FullName => $"{_firstName} {_lastName}";
        /// <summary>
        /// Gets person's full name in reverse order and
        /// separated by a comma.
        /// </summary>
        public string FullNameReversed => $"{_lastName}, {_firstName}";

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id">Person's unique identifier.</param>
        /// <param name="firstName">Person's first name.</param>
        /// <param name="lastName">Person's last name.</param>
        public Person(int id, string firstName, string lastName)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
        }
    }
}
