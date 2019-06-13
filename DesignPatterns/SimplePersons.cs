using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public interface Persons
    {
        Person Save(string name);

        Person Get(string id);
    }

    //Structural - Facade
    public class SimplePersons : Persons
    {
        private PersonRepository repository;
        private Validator validator;
        private IdGenerator idGenerator;

        public SimplePersons(PersonRepository repository, Validator validator, IdGenerator idGenerator)
        {
            this.repository = repository;
            this.validator = validator;
            this.idGenerator = idGenerator;
        }

        public Person Save(string name)
        {
            try
            {
                if (validator.Validate(name))
                {
                    var person = new Person(idGenerator.NewId(), name);
                    repository.Save(person);
                    return person;
                }


                Console.WriteLine("Name not valid. Returning John.");
                return Person.GetJohn();
            }
            catch (PersonAlreadySavedException e)
            {
                Console.WriteLine("Person with id {0} already saved. Returning John.", e.PersonId);
                return Person.GetJohn();
            }
        }

        public Person Get(string id)
        {
            try
            {
                return repository.GetById(id);
            }
            catch (PersonNotFoundException)
            {
                Console.WriteLine("Not found person, returning John.");
                return Person.GetJohn();
            }
        }
    }

    public interface IdGenerator
    {
        string NewId();
    }

    public class GlobalUniqueIdGenerator : IdGenerator
    {
        public string NewId()
        {
            return Guid.NewGuid().ToString();
        }
    }

    public interface Validator
    {
        bool Validate(string name);
    }

    public class LengthValidator : Validator
    {
        private int maxLength;

        public LengthValidator(int maxLength)
        {
            this.maxLength = maxLength;
        }

        public bool Validate(string name)
        {
            return name.Length <= maxLength;
        }
    }

    public class JohnValidator : Validator
    {
        public bool Validate(string name)
        {
            return !name.ToLower().Equals("john");
        }
    }

    //Structural - Composite
    public class CompositeValidator : Validator
    {
        private List<Validator> validators;

        public CompositeValidator(List<Validator> validators)
        {
            this.validators = new List<Validator>();
            this.validators.AddRange(validators);
        }


        public bool Validate(string name)
        {
            bool valid;

            foreach (var validator in validators)
            {
                valid = validator.Validate(name);
                if (!valid) return false;
            }

            return true;
        }
    }
}
