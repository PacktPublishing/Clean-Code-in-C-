using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH08_ThreadSafety
{
    public readonly struct ImmutablePerson
    {
        public ImmutablePerson(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}
