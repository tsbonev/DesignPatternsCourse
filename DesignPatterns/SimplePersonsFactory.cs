using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    //Creational - Method Factory
    public class SimplePersonsFactory
    {
        public static Persons NewJohnDefaultPersons()
        {
            var persistence = new PersistentPersonRepository();
            var cache = new CachedPersonRepository(persistence);
            var validator = new CompositeValidator(new List<Validator>() {new JohnValidator(), new LengthValidator(20)});
            var idGenerator = new GlobalUniqueIdGenerator();

            //Creational - Constructor Dependency Injection
            return new SimplePersons(cache, validator, idGenerator);
        }
    }
}
