using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH06_RhinoMocks
{
    public class PersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public void LookupPerson(Person person)
        {
            _personRepository.GetPersonByName(person.Name);
        }
    }
}
