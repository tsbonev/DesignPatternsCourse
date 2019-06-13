using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public interface PersonRepository
    {
        void Save(Person person);
        Person GetById(string id);
    }

    public class Person
    {
        // Creational - Lazy Singleton
        private static Person _john;
        public static Person GetJohn()
        {
            //C# equivalent of the elvis operator ?:
            return _john ?? (_john = new Person("1", "John"));
        }

        public string Id { get; }
        public string Name { get; }

        public Person(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class PersonAlreadySavedException : Exception
    {
        public string PersonId { get; }

        public PersonAlreadySavedException(string id)
        {
            PersonId = id;
        }
    }

    public class PersonNotFoundException : Exception
    {
        public string PersonId { get; }

        public PersonNotFoundException(string id)
        {
            PersonId = id;
        }
    }
}
