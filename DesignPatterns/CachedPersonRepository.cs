using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    //Behavioral - Chain of Responsibility
    public class CachedPersonRepository : PersonRepository
    {
        private Dictionary<string, Person> cachedPersons;
        private PersonRepository origin;

        public CachedPersonRepository(PersonRepository origin)
        {
            this.origin = origin;
            cachedPersons = new Dictionary<string, Person>();
        }

        public void Save(Person person)
        {
            origin.Save(person);
            cachedPersons.Add(person.Id, person);
        }

        public Person GetById(string id)
        {
            if (!cachedPersons.TryGetValue(id, out var person))
            {
                person = origin.GetById(id);
                cachedPersons.Add(person.Id, person);
            }

            return person;
        }
    }
}
