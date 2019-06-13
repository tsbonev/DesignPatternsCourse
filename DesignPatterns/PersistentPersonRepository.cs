using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class PersistentPersonRepository : PersonRepository
    {
        private Dictionary<string, Person> persistentPersons;

        public PersistentPersonRepository()
        {
            persistentPersons = new Dictionary<string, Person>();
        }

        public void Save(Person person)
        {
            try
            {
                persistentPersons.Add(person.Id, person);
            }
            catch (ArgumentException e)
            {
                throw new PersonAlreadySavedException(person.Id);
            }
        }

        public Person GetById(string id)
        {
            try
            {
                return persistentPersons[id];
            }
            catch (KeyNotFoundException e)
            {
                throw new PersonNotFoundException(id);
            }
        }
    }
}
