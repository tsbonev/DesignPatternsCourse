using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = System.Console;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = SimplePersonsFactory.NewJohnDefaultPersons();

            var savedPerson = repo.Save("Not John");
            var john = repo.Save("John");
            Console.WriteLine("{0} {1}", savedPerson.Id, savedPerson.Name);
            Console.WriteLine("{0} {1}", john.Id, john.Name);
        }
    }
}
