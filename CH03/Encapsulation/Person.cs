namespace CH3.Encapsulation
{
    /// <summary>
    /// Person data structure.
    /// </summary>
    public struct Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id">Unique identifier.</param>
        /// <param name="firstName">Person's first name.</param>
        /// <param name="lastName">Person's last name.</param>
        public Person(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
