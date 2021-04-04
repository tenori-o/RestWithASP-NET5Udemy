using RestWithASPNET5Udemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNET5Udemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        public Person FindById(long id)
        {
            return MockPerson((int) id);
        }

        public Person Update(Person person)
        {
            return person;
        }
        
        private Person MockPerson(int index)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "First name Mock",
                LastName = "Last name Mock",
                AddressName = "Address name Mock",
                GenderName = "Gender Mock"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
